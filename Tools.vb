Public Class RefundDialog
    Inherits Form
    Private ReadOnly txtAmount As TextBox = Theme.Txt(200)
    Private ReadOnly txtReason As TextBox = Theme.Txt(300)
    Private ReadOnly lblMsg As New Label With {.Dock = DockStyle.Top, .Height = Theme.S(30), .ForeColor = Theme.Danger}
    Private ReadOnly maxAmount As Decimal
    Public Amount As Decimal
    Public Reason As String = ""

    Public Sub New(receiptNo As String, original As Decimal)
        maxAmount = original
        Text = "Refund / adjust " & receiptNo
        Font = Theme.BaseFont
        ClientSize = New Size(Theme.S(500), Theme.S(330))
        StartPosition = FormStartPosition.CenterParent
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False : MinimizeBox = False : ShowInTaskbar = False
        BackColor = Color.White
        Padding = New Padding(Theme.S(20))
        Dim info As New Label With {.Dock = DockStyle.Top, .Height = Theme.S(80), .ForeColor = Theme.Muted,
            .Text = "Receipt " & receiptNo & " was for " & Theme.Money(original) & ". A refund is recorded as a new negative entry; the original payment stays on record and the student's balance goes up."}
        Dim t = FormTable()
        AddRow(t, "Refund amount (GH" & Theme.Cedi & ")", txtAmount)
        AddRow(t, "Reason (required)", txtReason)
        Dim ok = Theme.Btn("Record refund", True, 150)
        Dim cancel = Theme.Btn("Cancel", False, 100)
        Controls.Add(lblMsg)
        Controls.Add(t)
        Controls.Add(info)
        Controls.Add(ButtonBar(cancel, ok))
        AddHandler ok.Click, AddressOf Save
        AddHandler cancel.Click, Sub() DialogResult = DialogResult.Cancel
        Theme.Polish(Me)
    End Sub

    Private Sub Save(sender As Object, e As EventArgs)
        Dim a As Decimal
        If Not Decimal.TryParse(txtAmount.Text, a) OrElse a <= 0 Then lblMsg.Text = "Enter an amount greater than zero." : Return
        If a > maxAmount Then lblMsg.Text = "The refund cannot be more than the original payment." : Return
        If txtReason.Text.Trim() = "" Then lblMsg.Text = "A reason is required." : Return
        Amount = a
        Reason = txtReason.Text.Trim()
        DialogResult = DialogResult.OK
    End Sub
End Class

Public Class RolloverDialog
    Inherits Form
    Private ReadOnly cboFrom As ComboBox = Theme.Combo(200, "Term 1", "Term 2", "Term 3")
    Private ReadOnly cboTo As ComboBox = Theme.Combo(200, "Term 1", "Term 2", "Term 3")
    Private ReadOnly chkPromote As New CheckBox With {.Text = "Promote classes (JHS 1 to JHS 2, JHS 2 to JHS 3; JHS 3 students leave)", .AutoSize = True, .MaximumSize = New Size(Theme.S(420), 0)}

    Public Sub New()
        Text = "Term rollover"
        Font = Theme.BaseFont
        ClientSize = New Size(Theme.S(500), Theme.S(380))
        StartPosition = FormStartPosition.CenterParent
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False : MinimizeBox = False : ShowInTaskbar = False
        BackColor = Color.White
        Padding = New Padding(Theme.S(20))
        cboTo.SelectedIndex = 1
        Dim info As New Label With {.Dock = DockStyle.Top, .Height = Theme.S(90), .ForeColor = Theme.Muted,
            .Text = "Creates new student records in the target term for everyone in the source term, using the fee from Fee settings. Students already registered in the target term are skipped. Unpaid balances do not carry over."}
        Dim t = FormTable()
        AddRow(t, "From term", cboFrom)
        AddRow(t, "To term", cboTo)
        AddRow(t, "", chkPromote)
        Dim ok = Theme.Btn("Review and create", True, 190)
        Dim cancel = Theme.Btn("Cancel", False, 100)
        Controls.Add(t)
        Controls.Add(info)
        Controls.Add(ButtonBar(cancel, ok))
        AddHandler ok.Click, AddressOf Run
        AddHandler cancel.Click, Sub() DialogResult = DialogResult.Cancel
        Theme.Polish(Me)
    End Sub

    Private Function NextClass(c As String) As String
        Select Case c
            Case "JHS 1" : Return "JHS 2"
            Case "JHS 2" : Return "JHS 3"
        End Select
        Return Nothing
    End Function

    Private Sub Run(sender As Object, e As EventArgs)
        Dim fromT As String = cboFrom.SelectedItem.ToString(), toT As String = cboTo.SelectedItem.ToString()
        If fromT = toT Then MessageBox.Show("Choose two different terms.") : Return
        Dim src As DataTable = Db.Query("SELECT Name, Class, Guardian, Phone, IFNULL(PersonId, Id) AS PersonId FROM Students WHERE Term = @p0 ORDER BY Id", fromT)
        Dim plan As New List(Of String())
        Dim dup As Integer = 0, leaving As Integer = 0, noFee As Integer = 0
        For Each r As DataRow In src.Rows
            Dim cls As String = r("Class").ToString()
            If chkPromote.Checked Then
                cls = NextClass(cls)
                If cls Is Nothing Then
                    leaving += 1
                    Continue For
                End If
            End If
            If Db.SuggestedFee(cls, toT) <= 0 Then
                noFee += 1
                Continue For
            End If
            Dim exists As Integer = Convert.ToInt32(Db.Scalar("SELECT COUNT(*) FROM Students WHERE LOWER(Name) = LOWER(@p0) AND Class = @p1 AND Term = @p2", r("Name").ToString(), cls, toT))
            If exists > 0 Then
                dup += 1
                Continue For
            End If
            plan.Add(New String() {r("Name").ToString(), cls, r("Guardian").ToString(), r("Phone").ToString(), r("PersonId").ToString()})
        Next
        If plan.Count = 0 Then
            MessageBox.Show("Nothing to create. (" & dup & " already exist, " & leaving & " leaving, " & noFee & " without a fee.)", "Term rollover")
            Return
        End If
        If MessageBox.Show("Create " & plan.Count & " student record(s) in " & toT & "?" & vbCrLf & dup & " already exist and will be skipped; " & leaving & " are leaving (JHS 3)." & vbCrLf & "Unpaid balances do not carry over.", "Confirm term rollover", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Dim firstId As String = Nothing, lastId As String = Nothing
        Using tx As New Tx()
            For Each p In plan
                Dim fee As Decimal = Convert.ToDecimal(tx.Scalar("SELECT Fee FROM FeeSettings WHERE Class = @p0 AND Term = @p1", p(1), toT))
                Dim id As String = Db.NextNumber(tx, "Students", "STU", 3)
                tx.Exec("INSERT INTO Students(Id, Name, Class, Term, Guardian, Phone, Fee, Created, PersonId) VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)",
                        id, p(0), p(1), toT, p(2), p(3), fee, Now.ToString("yyyy-MM-dd HH:mm:ss"), If(p(4) = "", id, p(4)))
                If firstId Is Nothing Then firstId = id
                lastId = id
            Next
            AuditLogger.Log(tx, "TERM ROLLOVER", fromT & " to " & toT, "", plan.Count & " students created (" & firstId & " to " & lastId & "), promote classes: " & chkPromote.Checked)
            tx.Commit()
        End Using
        MessageBox.Show(plan.Count & " student record(s) created in " & toT & ".", "Term rollover")
        DialogResult = DialogResult.OK
    End Sub
End Class

Public Module ImportService
    Private Function ParseLine(line As String) As List(Of String)
        Dim res As New List(Of String)
        Dim sb As New StringBuilder()
        Dim inQ As Boolean = False
        Dim i As Integer = 0
        While i < line.Length
            Dim ch As Char = line(i)
            If inQ Then
                If ch = """"c Then
                    If i + 1 < line.Length AndAlso line(i + 1) = """"c Then
                        sb.Append(""""c)
                        i += 1
                    Else
                        inQ = False
                    End If
                Else
                    sb.Append(ch)
                End If
            ElseIf ch = """"c Then
                inQ = True
            ElseIf ch = ","c Then
                res.Add(sb.ToString())
                sb.Clear()
            Else
                sb.Append(ch)
            End If
            i += 1
        End While
        res.Add(sb.ToString())
        Return res
    End Function

    Public Sub ImportStudents(owner As IWin32Window)
        MessageBox.Show("Choose a CSV file with these columns, with headings in the first row:" & vbCrLf & vbCrLf & "Name, Class, Term, Guardian, Phone" & vbCrLf & "(an optional 6th column, Fee, overrides the standard fee)", "Import students")
        Using ofd As New OpenFileDialog With {.Filter = "CSV files (*.csv)|*.csv"}
            If ofd.ShowDialog(owner) <> DialogResult.OK Then Return
            Dim lines() As String = File.ReadAllLines(ofd.FileName)
            Dim imported As Integer = 0
            Dim problems As New List(Of String)
            Dim firstId As String = Nothing, lastId As String = Nothing
            Using tx As New Tx()
                For i = 1 To lines.Length - 1
                    If lines(i).Trim() = "" Then Continue For
                    Dim f As List(Of String) = ParseLine(lines(i))
                    Dim rowNo As Integer = i + 1
                    If f.Count < 3 Then
                        problems.Add("Row " & rowNo & ": needs at least Name, Class and Term")
                        Continue For
                    End If
                    Dim name As String = f(0).Trim()
                    Dim cls As String = System.Text.RegularExpressions.Regex.Replace(f(1).Trim().ToUpper(), "^JHS\s*(\d)$", "JHS $1")
                    Dim term As String = System.Text.RegularExpressions.Regex.Replace(f(2).Trim().ToLower(), "^term\s*(\d)$", "Term $1")
                    Dim guardian As String = If(f.Count > 3, f(3).Trim(), "")
                    Dim phone As String = If(f.Count > 4, f(4).Trim(), "")
                    If name = "" OrElse name.Length > 100 Then
                        problems.Add("Row " & rowNo & ": missing or too long name")
                        Continue For
                    End If
                    If Not {"JHS 1", "JHS 2", "JHS 3"}.Contains(cls) Then
                        problems.Add("Row " & rowNo & ": class must be JHS 1, JHS 2 or JHS 3")
                        Continue For
                    End If
                    If Not {"Term 1", "Term 2", "Term 3"}.Contains(term) Then
                        problems.Add("Row " & rowNo & ": term must be Term 1, Term 2 or Term 3")
                        Continue For
                    End If
                    If phone <> "" AndAlso Not System.Text.RegularExpressions.Regex.IsMatch(phone, "^[0-9+ ]{9,15}$") Then
                        problems.Add("Row " & rowNo & ": phone number format")
                        Continue For
                    End If
                    Dim fee As Decimal = 0
                    If f.Count > 5 AndAlso f(5).Trim() <> "" Then
                        If Not Decimal.TryParse(f(5), fee) OrElse fee <= 0 Then
                            problems.Add("Row " & rowNo & ": fee must be a positive number")
                            Continue For
                        End If
                    Else
                        Dim sf = tx.Scalar("SELECT Fee FROM FeeSettings WHERE Class = @p0 AND Term = @p1", cls, term)
                        fee = If(sf Is Nothing, 0D, Convert.ToDecimal(sf))
                    End If
                    If fee <= 0 Then
                        problems.Add("Row " & rowNo & ": no fee set for " & cls & ", " & term)
                        Continue For
                    End If
                    If Convert.ToInt32(tx.Scalar("SELECT COUNT(*) FROM Students WHERE LOWER(Name) = LOWER(@p0) AND Class = @p1 AND Term = @p2", name, cls, term)) > 0 Then
                        problems.Add("Row " & rowNo & ": " & name & " is already registered for " & cls & ", " & term)
                        Continue For
                    End If
                    Dim id As String = Db.NextNumber(tx, "Students", "STU", 3)
                    tx.Exec("INSERT INTO Students(Id, Name, Class, Term, Guardian, Phone, Fee, Created, PersonId) VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)",
                            id, name, cls, term, guardian, phone, Math.Round(fee, 2), Now.ToString("yyyy-MM-dd HH:mm:ss"), If(Db.FindPersonId(tx, name, phone), id))
                    If firstId Is Nothing Then firstId = id
                    lastId = id
                    imported += 1
                Next
                If imported > 0 Then
                    AuditLogger.Log(tx, "IMPORT STUDENTS", Path.GetFileName(ofd.FileName), "", imported & " students imported (" & firstId & " to " & lastId & "), " & problems.Count & " rows skipped")
                    tx.Commit()
                End If
            End Using
            Dim msg As String = imported & " student(s) imported, " & problems.Count & " row(s) skipped."
            If problems.Count > 0 Then msg &= vbCrLf & vbCrLf & String.Join(vbCrLf, problems.Take(12))
            If problems.Count > 12 Then msg &= vbCrLf & "..."
            MessageBox.Show(msg, "Import students")
        End Using
    End Sub
End Module
