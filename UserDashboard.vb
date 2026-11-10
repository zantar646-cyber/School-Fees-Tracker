Public Class UserDashboard
    Private currentId As String
    Private currentBalance As Decimal
    Private payDlg As PaymentModal

    Public Sub New()
        InitializeComponent()
        Theme.StyleGrid(dgvToday)
        cboMethod.SelectedIndex = 0
        Theme.Polish(Me)
        Theme.Polish(pnlPay)
        AddHandler txtAmount.Enter, Sub(s, e) pnlAmount.BorderColor = Theme.Primary
        AddHandler txtAmount.Leave, Sub(s, e) pnlAmount.BorderColor = Theme.BorderStrong
        pnlAmount.BorderColor = Theme.BorderStrong
    End Sub

    Private Sub UserDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If DesignMode Then Return
        svStudents.CompactColumns = True
        lblNoReceipts.BringToFront()
        lblNoReceipts.Text = "No payments yet today." & vbCrLf & "Pick a student on the left to record one."
        lblDate.Text = Now.ToString("dddd, d MMMM yyyy")
        Refresh2()
    End Sub

    Private Sub Refresh2()
        Dim today = Now.ToString("yyyy-MM-dd")
        Dim t = Db.Query("SELECT COUNT(*) AS n, IFNULL(SUM(Amount), 0) AS a FROM Payments WHERE Voided = 0 AND PaidOn LIKE @p0", today & "%").Rows(0)
        scToday.SetValue(Theme.Money(Convert.ToDecimal(t("a"))), Theme.Ok)
        scCount.SetValue(t("n").ToString())
        Dim owing = Db.Scalar("SELECT COUNT(*) FROM (" & Db.StudentSql & ") WHERE Balance > 0").ToString()
        scOwing.SetValue(owing, If(owing = "0", Theme.Ink, Theme.Danger))
        Dim all = Db.Query("SELECT COUNT(*) AS n, IFNULL(SUM(Fee), 0) AS f, IFNULL(SUM(Paid), 0) AS p FROM (" & Db.StudentSql & ")").Rows(0)
        Dim totalFee = Convert.ToDecimal(all("f")), totalPaid = Convert.ToDecimal(all("p"))
        scOwing.SubText = "of " & all("n").ToString() & " students"
        If totalFee > 0 Then
            Dim pct As Integer = CInt(Math.Round(totalPaid / totalFee * 100))
            scProgress.SetValue(pct & "%")
            scProgress.SetProgress(pct)
            scProgress.SubText = Theme.Money(totalPaid) & " of " & Theme.Money(totalFee)
        Else
            scProgress.SetValue("0%")
            scProgress.SetProgress(0)
            scProgress.SubText = "No fees set yet"
        End If
        dgvToday.DataSource = Db.Query("SELECT IFNULL(p.Batch, p.Id) AS Receipt, s.Name AS Student, s.Term, p.Amount, p.Method, SUBSTR(p.PaidOn, 12, 5) AS Time, p.ByUser AS ReceivedBy FROM Payments p JOIN Students s ON s.Id = p.StudentId WHERE p.Voided = 0 AND p.PaidOn LIKE @p0 ORDER BY p.PaidOn DESC", today & "%")
        If dgvToday.Columns.Contains("Amount") Then
            dgvToday.Columns("Amount").DefaultCellStyle.Format = "N2"
            dgvToday.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
        Theme.FitColumns(dgvToday)
        lblNoReceipts.Visible = (dgvToday.Rows.Count = 0)
        LoadStudent(svStudents.SelectedId)
    End Sub

    Private Sub svStudents_SelectedChanged(id As String) Handles svStudents.SelectedChanged
        LoadStudent(id)
    End Sub

    Private Sub svStudents_DataChanged() Handles svStudents.DataChanged
        Refresh2()
    End Sub

    Private Sub LoadStudent(id As String)
        currentId = id
        txtAmount.Clear()
        If id Is Nothing Then
            lblStudent.Text = "Select a student from the table"
            lblInfo.Text = ""
            msFee.SetValue("-") : msPaid.SetValue("-") : msBal.SetValue("-")
            btnRecord.Enabled = False : btnLast.Enabled = False : btnFull.Enabled = False
            Return
        End If
        Dim r = Db.Query("SELECT * FROM (" & Db.StudentSql & ") WHERE Id = @p0", id).Rows(0)
        currentBalance = Convert.ToDecimal(r("Balance"))
        lblStudent.Text = r("Name").ToString()
        lblInfo.Text = id & "  ·  " & r("Class").ToString() & "  ·  " & r("Term").ToString()
        msFee.SetValue(Theme.Money(Convert.ToDecimal(r("Fee"))))
        msPaid.SetValue(Theme.Money(Convert.ToDecimal(r("Paid"))), Theme.Ok)
        msBal.SetValue(Theme.Money(currentBalance), If(currentBalance > 0, Theme.Danger, Theme.Ok))
        btnRecord.Enabled = currentBalance > 0
        btnFull.Enabled = currentBalance > 0
        btnLast.Enabled = Payments.LastReceiptFor(id) IsNot Nothing
        UpdateAfter()
    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged
        UpdateAfter()
    End Sub

    Private Sub UpdateAfter()
        Dim a As Decimal
        If currentId IsNot Nothing AndAlso Decimal.TryParse(txtAmount.Text, a) AndAlso a > 0 Then
            If a > currentBalance Then
                lblAfter.Text = "Extra goes to other terms"
                lblAfter.ForeColor = Theme.Accent
            Else
                lblAfter.Text = "Balance after: " & Theme.Money(currentBalance - a)
                lblAfter.ForeColor = Theme.Muted
            End If
        Else
            lblAfter.Text = ""
        End If
    End Sub

    Private Sub btnNewPayment_Click(sender As Object, e As EventArgs) Handles btnNewPayment.Click
        If svStudents.SelectedId Is Nothing Then
            MessageBox.Show("Select a student in the table first, then click + Record Payment.", "Record payment", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        LoadStudent(svStudents.SelectedId)
        txtRef.Clear()
        Using dlg As New PaymentModal(pnlPay)
            payDlg = dlg
            dlg.AcceptButton = btnRecord
            dlg.CancelButton = btnCancelPay
            AddHandler dlg.Shown, Sub(s, ev) txtAmount.Focus()
            dlg.ShowDialog(FindForm())
            payDlg = Nothing
            ' hand the panel back before the window is disposed
            pnlPay.Visible = False
            Controls.Add(pnlPay)
        End Using
    End Sub

    Private Sub btnCancelPay_Click(sender As Object, e As EventArgs) Handles btnCancelPay.Click
        If payDlg IsNot Nothing Then payDlg.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnFull_Click(sender As Object, e As EventArgs) Handles btnFull.Click
        txtAmount.Text = currentBalance.ToString("0.00")
    End Sub

    Private Sub btnRecord_Click(sender As Object, e As EventArgs) Handles btnRecord.Click
        Dim a As Decimal
        If currentId Is Nothing Then Return
        If Not Decimal.TryParse(txtAmount.Text, a) OrElse a <= 0 Then MessageBox.Show("Enter an amount greater than zero.") : Return
        Dim plan As List(Of Alloc)
        Try
            plan = Payments.AutoPlan(currentId, a)
        Catch ex As InvalidOperationException
            MessageBox.Show(ex.Message, "Payment not saved")
            Return
        End Try
        Dim paying = plan.Where(Function(x) x.Pay > 0).ToList()
        ' one existing term record: save straight away; otherwise let the cashier review the split
        If paying.Count <> 1 OrElse paying(0).IsNew OrElse paying(0).StudentId <> currentId Then
            plan = ReviewPlan(plan)
            If plan Is Nothing Then Return
        End If
        Submit(plan)
    End Sub

    Private Sub btnTerms_Click(sender As Object, e As EventArgs) Handles btnTerms.Click
        If currentId Is Nothing Then MessageBox.Show("Select a student first.") : Return
        Dim a As Decimal = 0
        Decimal.TryParse(txtAmount.Text, a)
        Dim plan As List(Of Alloc)
        Try
            plan = Payments.AutoPlan(currentId, Math.Max(a, 0D))
        Catch ex As InvalidOperationException
            MessageBox.Show(ex.Message, "Payment not saved")
            Return
        End Try
        plan = ReviewPlan(plan)
        If plan Is Nothing Then Return
        Submit(plan)
    End Sub

    Private Function ReviewPlan(seed As List(Of Alloc)) As List(Of Alloc)
        Using d As New AllocationDialog(currentId, seed, lblStudent.Text)
            If d.ShowDialog(FindForm()) <> DialogResult.OK Then Return Nothing
            Return d.Plan
        End Using
    End Function

    Private Sub Submit(plan As List(Of Alloc))
        Try
            Dim rcp = Payments.RecordMulti(currentId, plan, cboMethod.SelectedItem.ToString(), txtRef.Text.Trim())
            txtRef.Clear()
            If MessageBox.Show("Payment recorded (" & rcp & "). Print the receipt now?", "Payment saved", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ReceiptPrinter.PrintReceipt(rcp, FindForm())
            End If
        Catch ex As InvalidOperationException
            MessageBox.Show(ex.Message, "Payment not saved")
            Return
        End Try
        svStudents.Reload()
        Refresh2()
        If payDlg IsNot Nothing Then payDlg.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Dim r = Payments.LastReceiptFor(currentId)
        If r IsNot Nothing Then ReceiptPrinter.PrintReceipt(r, FindForm())
    End Sub

    Private Sub btnReprint_Click(sender As Object, e As EventArgs) Handles btnReprint.Click
        If dgvToday.CurrentRow Is Nothing Then Return
        ReceiptPrinter.PrintReceipt(dgvToday.CurrentRow.Cells("Receipt").Value.ToString(), FindForm())
        Refresh2()
    End Sub
End Class
