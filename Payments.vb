Public Class Alloc
    Public StudentId As String      ' Nothing when the term is not registered yet
    Public Term As String
    Public Fee As Decimal
    Public Paid As Decimal
    Public Pay As Decimal
    Public IsNew As Boolean
    Public ReadOnly Property Balance As Decimal
        Get
            Return Math.Round(Fee - Paid, 2)
        End Get
    End Property
End Class

Public Module Payments
    Public Function Record(studentId As String, amount As Decimal, method As String, ref As String) As String
        amount = Math.Round(amount, 2)
        If amount <= 0 Then Throw New InvalidOperationException("Enter an amount greater than zero.")
        Using tx As New Tx()
            Dim s = Db.Query("SELECT Name, Fee FROM Students WHERE Id = @p0", studentId)
            If s.Rows.Count = 0 Then Throw New InvalidOperationException("Student not found.")
            Dim fee As Decimal = Convert.ToDecimal(s.Rows(0)("Fee"))
            Dim paid As Decimal = Math.Round(Convert.ToDecimal(tx.Scalar("SELECT IFNULL(SUM(Amount), 0) FROM Payments WHERE StudentId = @p0 AND Voided = 0", studentId)), 2)
            Dim balance As Decimal = fee - paid
            If amount > balance Then Throw New InvalidOperationException("The amount is more than the balance of " & Theme.Money(balance) & ".")
            Dim rcp = Db.NextNumber(tx, "Payments", "RCP", 4)
            tx.Exec("INSERT INTO Payments(Id, StudentId, Amount, Method, Ref, PaidOn, ByUser, Batch) VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p0)",
                    rcp, studentId, amount, method, ref, Now.ToString("yyyy-MM-dd HH:mm:ss"), Session.UserName)
            AuditLogger.Log(tx, "PAYMENT", rcp & " · " & studentId & " · " & s.Rows(0)("Name").ToString(),
                            "Balance " & balance.ToString("N2"), "Balance " & (balance - amount).ToString("N2") & " (paid " & amount.ToString("N2") & ", " & method & ")")
            tx.Commit()
            Return rcp
        End Using
    End Function

    ' Voids a whole receipt (every term line that was paid on it)
    Public Sub Void(receiptNo As String, reason As String)
        Using tx As New Tx()
            Dim b = tx.Scalar("SELECT IFNULL(Batch, Id) FROM Payments WHERE Id = @p0", receiptNo)
            Dim batch As String = If(b Is Nothing, receiptNo, b.ToString())
            Dim p = Db.Query("SELECT StudentId, Amount FROM Payments WHERE IFNULL(Batch, Id) = @p0 AND Voided = 0", batch)
            If p.Rows.Count = 0 Then Throw New InvalidOperationException("This receipt is already voided.")
            Dim total As Decimal = 0
            For Each r As DataRow In p.Rows
                total += Convert.ToDecimal(r("Amount"))
            Next
            tx.Exec("UPDATE Payments SET Voided = 1, VoidReason = @p0 WHERE IFNULL(Batch, Id) = @p1 AND Voided = 0", reason, batch)
            AuditLogger.Log(tx, "VOID PAYMENT", batch & " · " & p.Rows(0)("StudentId").ToString(),
                            "Valid, " & p.Rows.Count & " line(s), total " & total.ToString("N2"), "Voided", reason)
            tx.Commit()
        End Using
    End Sub

    Private ReadOnly TermNames() As String = {"Term 1", "Term 2", "Term 3"}

    ' The pupil's term records for this class, plus later terms that are not registered yet
    Public Function TermRecords(studentId As String) As List(Of Alloc)
        Dim st = Db.Query("SELECT Class, IFNULL(PersonId, Id) AS PersonId FROM Students WHERE Id = @p0", studentId)
        If st.Rows.Count = 0 Then Throw New InvalidOperationException("Student not found.")
        Dim cls As String = st.Rows(0)("Class").ToString()
        Dim pid As String = st.Rows(0)("PersonId").ToString()
        Dim rows = Db.Query("SELECT Id, Term, Fee, Paid FROM (" & Db.StudentSql & ") WHERE Class = @p0 AND (Id = @p2 OR Id IN (SELECT Id FROM Students WHERE IFNULL(PersonId, Id) = @p1)) ORDER BY Term", cls, pid, studentId)
        Dim list As New List(Of Alloc)
        Dim maxIdx As Integer = -1
        For Each r As DataRow In rows.Rows
            Dim a As New Alloc With {.StudentId = r("Id").ToString(), .Term = r("Term").ToString(), .Fee = Convert.ToDecimal(r("Fee")), .Paid = Convert.ToDecimal(r("Paid"))}
            list.Add(a)
            maxIdx = Math.Max(maxIdx, Array.IndexOf(TermNames, a.Term))
        Next
        For i = maxIdx + 1 To TermNames.Length - 1
            Dim fee As Decimal = Db.SuggestedFee(cls, TermNames(i))
            If fee > 0 Then list.Add(New Alloc With {.Term = TermNames(i), .Fee = fee, .Paid = 0, .IsNew = True})
        Next
        Return list
    End Function

    ' Spreads an amount over the oldest unpaid terms first, then on to later terms
    Public Function AutoPlan(studentId As String, amount As Decimal) As List(Of Alloc)
        amount = Math.Round(amount, 2)
        Dim recs = TermRecords(studentId)
        Dim remaining As Decimal = amount
        For Each r In recs
            If remaining <= 0 Then Exit For
            If r.Balance <= 0 Then Continue For
            r.Pay = Math.Min(r.Balance, remaining)
            remaining -= r.Pay
        Next
        If remaining > 0 Then Throw New InvalidOperationException("That is more than all the remaining fees for this class (" & Theme.Money(amount - remaining) & ").")
        Return recs
    End Function

    ' Records one receipt that can cover several terms. Later terms that are not registered yet are created.
    Public Function RecordMulti(studentId As String, plan As List(Of Alloc), method As String, ref As String) As String
        Dim lines = plan.Where(Function(x) x.Pay > 0).ToList()
        If lines.Count = 0 Then Throw New InvalidOperationException("Enter an amount greater than zero.")
        Using tx As New Tx()
            Dim st = Db.Query("SELECT Name, Class, Guardian, Phone, IFNULL(PersonId, Id) AS PersonId FROM Students WHERE Id = @p0", studentId)
            If st.Rows.Count = 0 Then Throw New InvalidOperationException("Student not found.")
            Dim name As String = st.Rows(0)("Name").ToString()
            Dim cls As String = st.Rows(0)("Class").ToString()
            Dim guardian As String = st.Rows(0)("Guardian").ToString()
            Dim phone As String = st.Rows(0)("Phone").ToString()
            Dim pid As String = st.Rows(0)("PersonId").ToString()
            Dim batch As String = Db.NextNumber(tx, "Payments", "RCP", 4)
            Dim total As Decimal = 0
            Dim before As New List(Of String), after As New List(Of String)
            Dim n As Integer = 0
            For Each a In lines
                Dim pay As Decimal = Math.Round(a.Pay, 2)
                Dim sid As String = a.StudentId
                If a.IsNew Then
                    If Convert.ToInt32(tx.Scalar("SELECT COUNT(*) FROM Students WHERE IFNULL(PersonId, Id) = @p0 AND Class = @p1 AND Term = @p2", pid, cls, a.Term)) > 0 Then
                        Throw New InvalidOperationException(a.Term & " was registered in the meantime. Please start the payment again.")
                    End If
                    Dim fv = tx.Scalar("SELECT Fee FROM FeeSettings WHERE Class = @p0 AND Term = @p1", cls, a.Term)
                    Dim fee As Decimal = If(fv Is Nothing, 0D, Convert.ToDecimal(fv))
                    If fee <= 0 Then Throw New InvalidOperationException("No fee is set for " & cls & ", " & a.Term & ".")
                    sid = Db.NextNumber(tx, "Students", "STU", 3)
                    tx.Exec("INSERT INTO Students(Id, Name, Class, Term, Guardian, Phone, Fee, Created, PersonId) VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)",
                            sid, name, cls, a.Term, guardian, phone, fee, Now.ToString("yyyy-MM-dd HH:mm:ss"), pid)
                    AuditLogger.Log(tx, "REGISTER STUDENT", sid & " · " & name, "", cls & ", " & a.Term & ", fee " & fee.ToString("N2") & " (created for an advance payment)")
                    a.Fee = fee
                    a.Paid = 0
                Else
                    ' re-check the balance inside the transaction
                    a.Fee = Convert.ToDecimal(tx.Scalar("SELECT Fee FROM Students WHERE Id = @p0", sid))
                    a.Paid = Math.Round(Convert.ToDecimal(tx.Scalar("SELECT IFNULL(SUM(Amount), 0) FROM Payments WHERE StudentId = @p0 AND Voided = 0", sid)), 2)
                End If
                If pay > a.Balance Then Throw New InvalidOperationException(a.Term & ": the amount is more than the balance of " & Theme.Money(a.Balance) & ".")
                n += 1
                Dim lineId As String = If(n = 1, batch, batch & "-" & n)
                tx.Exec("INSERT INTO Payments(Id, StudentId, Amount, Method, Ref, PaidOn, ByUser, Batch) VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7)",
                        lineId, sid, pay, method, ref, Now.ToString("yyyy-MM-dd HH:mm:ss"), Session.UserName, batch)
                before.Add(a.Term & " balance " & a.Balance.ToString("N2"))
                after.Add(a.Term & " paid " & pay.ToString("N2") & ", balance " & (a.Balance - pay).ToString("N2"))
                total += pay
            Next
            AuditLogger.Log(tx, "PAYMENT", batch & " · " & studentId & " · " & name, String.Join("; ", before), String.Join("; ", after) & " (total " & total.ToString("N2") & ", " & method & ")")
            tx.Commit()
            Return batch
        End Using
    End Function

    ' A refund is a new negative payment linked to the original receipt; the original stays on record
    Public Function Refund(receiptNo As String, amount As Decimal, reason As String) As String
        amount = Math.Round(amount, 2)
        If amount <= 0 Then Throw New InvalidOperationException("Enter an amount greater than zero.")
        Using tx As New Tx()
            Dim p = Db.Query("SELECT StudentId, Amount, Voided, Method FROM Payments WHERE Id = @p0", receiptNo)
            If p.Rows.Count = 0 Then Throw New InvalidOperationException("Receipt not found.")
            If Convert.ToInt32(p.Rows(0)("Voided")) = 1 OrElse p.Rows(0)("Method").ToString() = "Refund" Then Throw New InvalidOperationException("Only a valid payment can be refunded.")
            Dim orig As Decimal = Convert.ToDecimal(p.Rows(0)("Amount"))
            Dim sid As String = p.Rows(0)("StudentId").ToString()
            Dim refunded As Decimal = Convert.ToDecimal(tx.Scalar("SELECT IFNULL(SUM(-Amount), 0) FROM Payments WHERE Method = 'Refund' AND Voided = 0 AND Ref LIKE @p0", "Refund of " & receiptNo & ":%"))
            If amount > orig - refunded Then Throw New InvalidOperationException("You can refund at most " & Theme.Money(orig - refunded) & " on this receipt.")
            Dim rcp = Db.NextNumber(tx, "Payments", "RCP", 4)
            tx.Exec("INSERT INTO Payments(Id, StudentId, Amount, Method, Ref, PaidOn, ByUser, Batch) VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p0)",
                    rcp, sid, -amount, "Refund", "Refund of " & receiptNo & ": " & reason, Now.ToString("yyyy-MM-dd HH:mm:ss"), Session.UserName)
            AuditLogger.Log(tx, "REFUND", rcp & " · " & sid, "Receipt " & receiptNo & " paid " & orig.ToString("N2"), "Refunded " & amount.ToString("N2"), reason)
            tx.Commit()
            Return rcp
        End Using
    End Function

    Public Function LastReceiptFor(studentId As String) As String
        Dim v = Db.Scalar("SELECT IFNULL(Batch, Id) FROM Payments WHERE StudentId = @p0 AND Voided = 0 ORDER BY PaidOn DESC, Id DESC LIMIT 1", studentId)
        Return If(v Is Nothing, Nothing, v.ToString())
    End Function
End Module

Public Module ReceiptPrinter
    Private lines As List(Of KeyValuePair(Of String, String))
    Private copyLabel As String
    Private school As String

    Public Sub PrintReceipt(receiptNo As String, owner As IWin32Window)
        Dim bv = Db.Scalar("SELECT IFNULL(Batch, Id) FROM Payments WHERE Id = @p0", receiptNo)
        Dim batch As String = If(bv Is Nothing, receiptNo, bv.ToString())
        Dim dt = Db.Query("SELECT p.Id, p.StudentId, p.Amount, p.Method, p.Ref, p.PaidOn, p.ByUser, p.Voided, p.PrintCount, s.Name, s.Class, s.Term, s.Fee FROM Payments p JOIN Students s ON s.Id = p.StudentId WHERE IFNULL(p.Batch, p.Id) = @p0 ORDER BY p.Id", batch)
        If dt.Rows.Count = 0 Then Return
        Dim valid As New List(Of DataRow)
        Dim maxPrints As Integer = 0
        For Each r As DataRow In dt.Rows
            maxPrints = Math.Max(maxPrints, Convert.ToInt32(r("PrintCount")))
            If Convert.ToInt32(r("Voided")) = 0 Then valid.Add(r)
        Next
        If valid.Count = 0 Then
            MessageBox.Show("This payment was voided, so no receipt can be printed.", "Receipt")
            Return
        End If
        Dim first = valid(0)
        Dim isReprint As Boolean = maxPrints > 0
        copyLabel = If(isReprint, "REPRINT", "Original copy")
        school = Db.SchoolName()
        lines = New List(Of KeyValuePair(Of String, String)) From {
            New KeyValuePair(Of String, String)("Receipt no.", batch),
            New KeyValuePair(Of String, String)("Date", Convert.ToDateTime(first("PaidOn")).ToString("dd MMM yyyy, HH:mm")),
            New KeyValuePair(Of String, String)("Student", first("Name").ToString()),
            New KeyValuePair(Of String, String)("Student ID", first("StudentId").ToString()),
            New KeyValuePair(Of String, String)("Class", first("Class").ToString()),
            New KeyValuePair(Of String, String)("Method", first("Method").ToString()),
            New KeyValuePair(Of String, String)("Reference", If(first("Ref").ToString() = "", "-", first("Ref").ToString()))
        }
        Dim total As Decimal = 0
        For Each r In valid
            Dim paidSoFar = Math.Round(Convert.ToDecimal(Db.Scalar("SELECT SUM(Amount) FROM Payments WHERE StudentId = @p0 AND Voided = 0 AND (PaidOn < @p1 OR (PaidOn = @p1 AND Id <= @p2))", r("StudentId"), r("PaidOn"), r("Id"))), 2)
            Dim fee = Convert.ToDecimal(r("Fee"))
            Dim amt = Convert.ToDecimal(r("Amount"))
            total += amt
            lines.Add(New KeyValuePair(Of String, String)(r("Term").ToString(), Theme.Money(amt) & "  (balance " & (fee - paidSoFar).ToString("N2") & ")"))
        Next
        If valid.Count > 1 Then lines.Add(New KeyValuePair(Of String, String)("Total paid", Theme.Money(total)))
        lines.Add(New KeyValuePair(Of String, String)("Received by", first("ByUser").ToString()))
        Using doc As New PrintDocument(), prev As New PrintPreviewDialog()
            AddHandler doc.PrintPage, AddressOf DrawPage
            prev.Document = doc
            prev.WindowState = FormWindowState.Maximized
            prev.ShowDialog(owner)
        End Using
        Using tx As New Tx()
            tx.Exec("UPDATE Payments SET PrintCount = PrintCount + 1 WHERE IFNULL(Batch, Id) = @p0", batch)
            AuditLogger.Log(tx, If(isReprint, "REPRINT RECEIPT", "PRINT RECEIPT"), batch & " · " & first("StudentId").ToString())
            tx.Commit()
        End Using
    End Sub

    Private Sub DrawPage(sender As Object, e As PrintPageEventArgs)
        Dim g = e.Graphics
        Dim x As Single = 60, y As Single = 60, w As Single = 420
        Using hdr As New SolidBrush(Theme.Primary), white As New SolidBrush(Color.White), ink As New SolidBrush(Theme.Ink), muted As New SolidBrush(Theme.Muted)
            Using f1 As New Font("Segoe UI", 16, FontStyle.Bold), f2 As New Font("Segoe UI", 10), f3 As New Font("Segoe UI", 11), f4 As New Font("Segoe UI", 11, FontStyle.Bold)
                g.FillRectangle(hdr, x, y, w, 56)
                Dim c As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
                g.DrawString(school, f1, white, New RectangleF(x, y, w, 56), c)
                y += 66
                g.DrawString("Official Fees Receipt  ·  " & copyLabel, f2, muted, New RectangleF(x, y, w, 24), c)
                y += 34
                Using pen As New Pen(Color.Gray) With {.DashStyle = Drawing2D.DashStyle.Dash}
                    For Each kv In lines
                        g.DrawString(kv.Key, f3, muted, x, y)
                        Dim rf As New StringFormat With {.Alignment = StringAlignment.Far}
                        g.DrawString(kv.Value, f4, ink, New RectangleF(x + 120, y, w - 120, 24), rf)
                        y += 28
                        g.DrawLine(pen, x, y - 3, x + w, y - 3)
                    Next
                End Using
                y += 40
                g.DrawString("Signature: ______________________", f3, ink, x, y)
                y += 40
                g.DrawString("Keep this receipt as proof of payment.", f2, muted, New RectangleF(x, y, w, 24), c)
            End Using
        End Using
        e.HasMorePages = False
    End Sub
End Module
