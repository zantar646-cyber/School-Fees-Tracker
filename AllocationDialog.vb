' Lets the cashier see, and adjust, how one payment is shared across a pupil's terms
Public Class AllocationDialog
    Private recs As List(Of Alloc)
    Private dt As DataTable
    Private loaded As Boolean
    Public Plan As List(Of Alloc)
    Public Total As Decimal

    Public Sub New()
        InitializeComponent()
        Theme.Polish(Me)
        Animator.FadeIn(Me)
        Theme.StyleGrid(dgv)
        dgv.ReadOnly = False
        dgv.SelectionMode = DataGridViewSelectionMode.CellSelect
    End Sub

    Public Sub New(studentId As String, seed As List(Of Alloc), studentName As String)
        Me.New()
        recs = seed
        lblSummary.Text = studentName & ": the payment is shared over the terms below, oldest first. Change the amounts in the last column if needed. Terms marked 'not registered yet' are created when you confirm."
    End Sub

    Private Sub AllocationDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If DesignMode OrElse recs Is Nothing Then Return
        dt = New DataTable
        dt.Columns.Add("Term", GetType(String))
        dt.Columns.Add("Status", GetType(String))
        dt.Columns.Add("Fee", GetType(Double))
        dt.Columns.Add("Paid", GetType(Double))
        dt.Columns.Add("Balance", GetType(Double))
        dt.Columns.Add("ThisPayment", GetType(Double))
        For Each r In recs
            dt.Rows.Add(r.Term, If(r.IsNew, "Not registered yet", "Registered"), CDbl(r.Fee), CDbl(r.Paid), CDbl(r.Balance), CDbl(r.Pay))
        Next
        dgv.DataSource = dt
        For Each c As DataGridViewColumn In dgv.Columns
            c.ReadOnly = (c.Name <> "ThisPayment")
            If c.ValueType Is GetType(Double) Then
                c.DefaultCellStyle.Format = "N2"
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
        dgv.Columns("ThisPayment").HeaderText = "This payment"
        dgv.Columns("ThisPayment").DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF4E8")
        Theme.FitColumns(dgv)
        loaded = True
        Recalc()
    End Sub

    Private Function PayOf(row As DataRow) As Decimal
        If row("ThisPayment") Is DBNull.Value Then Return 0D
        Return Math.Round(Convert.ToDecimal(row("ThisPayment")), 2)
    End Function

    Private Sub Recalc()
        If Not loaded Then Return
        Dim t As Decimal = 0
        For Each r As DataRow In dt.Rows
            t += PayOf(r)
        Next
        lblTotal.Text = "Total payment: " & Theme.Money(t)
    End Sub

    Private Sub dgv_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEndEdit
        Recalc()
    End Sub

    Private Sub dgv_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgv.DataError
        lblMsg.Text = "Enter a number, for example 400.00"
        e.ThrowException = False
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        dgv.EndEdit()
        Dim t As Decimal = 0
        For i = 0 To dt.Rows.Count - 1
            Dim pay As Decimal = PayOf(dt.Rows(i))
            If pay < 0 Then lblMsg.Text = recs(i).Term & ": the amount cannot be negative." : Return
            If pay > recs(i).Balance Then lblMsg.Text = recs(i).Term & ": more than the balance of " & Theme.Money(recs(i).Balance) & "." : Return
            recs(i).Pay = pay
            t += pay
        Next
        If t <= 0 Then lblMsg.Text = "Enter an amount for at least one term." : Return
        Plan = recs
        Total = t
        DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub
End Class
