Public Class PaymentsView
    Private loaded As Boolean

    Public Sub New()
        InitializeComponent()
        Theme.Polish(Me)
        Theme.StyleGrid(dgv)
    End Sub

    Private Sub PaymentsView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If DesignMode Then Return
        lblEmpty.BringToFront()
        btnVoid.Visible = Session.IsAdmin
        btnRefund.Visible = Session.IsAdmin
        Reload()
        loaded = True
    End Sub

    Private Sub Reload()
        Dim dt = Db.Query("SELECT p.Id AS Receipt, p.PaidOn AS Date, p.StudentId, s.Name AS Student, s.Class, s.Term, p.Amount, p.Method, IFNULL(p.Ref, '') AS Reference, p.ByUser AS ReceivedBy, CASE WHEN p.Voided = 1 THEN 'Voided' ELSE 'Valid' END AS Status, IFNULL(p.VoidReason, '') AS VoidReason FROM Payments p JOIN Students s ON s.Id = p.StudentId ORDER BY p.PaidOn DESC, p.Id DESC")
        dgv.DataSource = New DataView(dt)
        If dgv.Columns.Contains("Amount") Then
            dgv.Columns("Amount").DefaultCellStyle.Format = "N2"
            dgv.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
        Theme.FitColumns(dgv)
        ApplyFilter()
    End Sub

    Private Sub Filters_Changed(sender As Object, e As EventArgs) Handles txtSearch.TextChanged, chkVoided.CheckedChanged
        ApplyFilter()
    End Sub

    Private Sub ApplyFilter()
        Dim dv = TryCast(dgv.DataSource, DataView)
        If dv Is Nothing Then Return
        Dim f As New List(Of String)
        Dim q = txtSearch.Text.Trim()
        If q <> "" Then f.Add("(Receipt LIKE '%" & Theme.Esc(q) & "%' OR Student LIKE '%" & Theme.Esc(q) & "%' OR StudentId LIKE '%" & Theme.Esc(q) & "%')")
        If Not chkVoided.Checked Then f.Add("Status = 'Valid'")
        dv.RowFilter = String.Join(" AND ", f)
        lblEmpty.Visible = (dv.Count = 0)
        lblEmpty.Text = If(dv.Table.Rows.Count = 0, "No payments recorded yet.", "No payments match your search.")
    End Sub

    Private Sub dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgv.CellFormatting
        If e.RowIndex < 0 Then Return
        If dgv.Rows(e.RowIndex).Cells("Status").Value.ToString() = "Voided" Then
            e.CellStyle.ForeColor = Theme.Muted
            e.CellStyle.Font = New Font(Theme.BaseFont, FontStyle.Strikeout)
        End If
    End Sub

    Private Sub dgv_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgv.CellPainting
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 OrElse dgv.Columns(e.ColumnIndex).Name <> "Status" Then Return
        Theme.PaintStatus(e)
    End Sub

    Private Sub btnReprint_Click(sender As Object, e As EventArgs) Handles btnReprint.Click
        If dgv.CurrentRow IsNot Nothing Then ReceiptPrinter.PrintReceipt(dgv.CurrentRow.Cells("Receipt").Value.ToString(), FindForm())
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Helpers.ExportView(CType(dgv.DataSource, DataView), "payments")
    End Sub

    Private Sub btnRefund_Click(sender As Object, e As EventArgs) Handles btnRefund.Click
        If Not Session.IsAdmin OrElse dgv.CurrentRow Is Nothing Then Return
        Dim rcp = dgv.CurrentRow.Cells("Receipt").Value.ToString()
        If dgv.CurrentRow.Cells("Status").Value.ToString() = "Voided" OrElse dgv.CurrentRow.Cells("Method").Value.ToString() = "Refund" Then
            MessageBox.Show("Select a valid payment (not a voided payment or a refund).")
            Return
        End If
        Using d As New RefundDialog(rcp, Convert.ToDecimal(dgv.CurrentRow.Cells("Amount").Value))
            If d.ShowDialog(FindForm()) <> DialogResult.OK Then Return
            Try
                Payments.Refund(rcp, d.Amount, d.Reason)
            Catch ex As InvalidOperationException
                MessageBox.Show(ex.Message, "Refund not saved")
            End Try
        End Using
        Reload()
    End Sub

    Private Sub btnVoid_Click(sender As Object, e As EventArgs) Handles btnVoid.Click
        If Not Session.IsAdmin OrElse dgv.CurrentRow Is Nothing Then Return
        Dim rcp = dgv.CurrentRow.Cells("Receipt").Value.ToString()
        If dgv.CurrentRow.Cells("Status").Value.ToString() = "Voided" Then MessageBox.Show("This payment is already voided.") : Return
        Using d As New ReasonDialog("Void payment?", rcp & " · " & dgv.CurrentRow.Cells("Student").Value.ToString() & " · GH" & Theme.Cedi & " " & Convert.ToDecimal(dgv.CurrentRow.Cells("Amount").Value).ToString("N2") & vbCrLf & "The whole receipt (every term on it) stays on record but stops counting toward balances.", "Reason (required)", "Void payment", True)
            If d.ShowDialog(FindForm()) <> DialogResult.OK Then Return
            Try
                Payments.Void(rcp, d.Value)
            Catch ex As InvalidOperationException
                MessageBox.Show(ex.Message)
            End Try
        End Using
        Reload()
    End Sub
End Class
