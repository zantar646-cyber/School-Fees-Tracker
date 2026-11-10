Public Class AuditView
    Private loaded As Boolean

    Public Sub New()
        InitializeComponent()
        Theme.Polish(Me)
        Theme.StyleGrid(dgv)
    End Sub

    Private Sub AuditView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If DesignMode Then Return
        lblNote.Text = "Read-only log. Each entry is chained to the one before it; use Verify log to check it. A copy is kept in audit.log."
        Dim dt = Db.Query("SELECT Time, UserName AS [User], Action, Record, OldValue AS [Before], NewValue AS [After], IFNULL(Reason, '') AS Reason FROM AuditLog ORDER BY Id DESC LIMIT 5000")
        dgv.DataSource = New DataView(dt)
        cboAction.Items.Add("All actions")
        For Each r As DataRow In Db.Query("SELECT DISTINCT Action FROM AuditLog ORDER BY Action").Rows
            cboAction.Items.Add(r("Action").ToString())
        Next
        cboAction.SelectedIndex = 0
        dgv.Columns("Time").FillWeight = 80
        Theme.FitColumns(dgv, Theme.S(220))
        loaded = True
        ApplyFilter()
    End Sub

    Private Sub Filters_Changed(sender As Object, e As EventArgs) Handles txtSearch.TextChanged, cboAction.SelectedIndexChanged, dtp.ValueChanged
        ApplyFilter()
    End Sub

    Private Sub ApplyFilter()
        If Not loaded Then Return
        Dim dv = TryCast(dgv.DataSource, DataView)
        If dv Is Nothing OrElse cboAction.SelectedItem Is Nothing Then Return
        Dim f As New List(Of String)
        Dim q = Theme.Esc(txtSearch.Text.Trim())
        If q <> "" Then f.Add("([User] LIKE '%" & q & "%' OR Record LIKE '%" & q & "%' OR [Before] LIKE '%" & q & "%' OR [After] LIKE '%" & q & "%' OR Reason LIKE '%" & q & "%')")
        If cboAction.SelectedIndex > 0 Then f.Add("Action = '" & cboAction.SelectedItem.ToString().Replace("'", "''") & "'")
        If dtp.Checked Then f.Add("Time LIKE '" & dtp.Value.ToString("yyyy-MM-dd") & "%'")
        dv.RowFilter = String.Join(" AND ", f)
        lblCount.Text = dv.Count & " entries"
    End Sub

    Private Sub dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgv.CellFormatting
        If e.RowIndex < 0 Then Return
        Dim a = dgv.Rows(e.RowIndex).Cells("Action").Value.ToString()
        If a.StartsWith("DELETE") Then
            e.CellStyle.BackColor = ColorTranslator.FromHtml("#FBDDD9")
        ElseIf a.StartsWith("VOID") OrElse a.StartsWith("REFUND") OrElse a = "LOGIN FAILED" Then
            e.CellStyle.BackColor = ColorTranslator.FromHtml("#FDEBCB")
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Helpers.ExportView(CType(dgv.DataSource, DataView), "audit_log")
    End Sub

    Private Sub btnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        Dim ok As Boolean
        Dim msg As String = AuditLogger.Verify(ok)
        MessageBox.Show(msg, "Verify audit log", MessageBoxButtons.OK, If(ok, MessageBoxIcon.Information, MessageBoxIcon.Warning))
    End Sub

    Private Sub btnFolder_Click(sender As Object, e As EventArgs) Handles btnFolder.Click
        Process.Start(New ProcessStartInfo("explorer.exe", """" & Db.DataDir & """") With {.UseShellExecute = True})
    End Sub
End Class
