Public Class AdminDashboard
    Private loaded As Boolean

    Public Sub New()
        InitializeComponent()
        Theme.Polish(Me)
        Theme.StyleGrid(dgvActivity)
        dgvActivity.ColumnHeadersVisible = False
        dgvActivity.DefaultCellStyle.SelectionBackColor = Color.White
        dgvActivity.DefaultCellStyle.SelectionForeColor = Theme.Ink
        dgvActivity.RowTemplate.Height = Theme.S(54)
        dgvActivity.AlternatingRowsDefaultCellStyle.BackColor = Color.White
        dgvActivity.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.White
        dgvActivity.AlternatingRowsDefaultCellStyle.SelectionForeColor = Theme.Ink
        AddHandler dgvActivity.CellPainting, AddressOf ActivityPainting
        cboTerm.SelectedIndex = 0
    End Sub

    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If DesignMode Then Return
        svStudents.ShowTermFilter = False
        svStudents.CompactColumns = True
        loaded = True
        LoadStats()
    End Sub

    Private Sub cboTerm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTerm.SelectedIndexChanged
        If Not loaded Then Return
        svStudents.TermFilter = cboTerm.SelectedItem.ToString()
        LoadStats()
    End Sub

    Private Sub svStudents_DataChanged() Handles svStudents.DataChanged
        If loaded Then LoadStats()
    End Sub

    Private Function Pct(part As Decimal, total As Decimal) As Integer
        If total <= 0 Then Return 0
        Return CInt(Math.Round(part / total * 100))
    End Function

    Public Sub LoadStats()
        Dim all As Boolean = cboTerm.SelectedIndex <= 0
        Dim term As String = cboTerm.SelectedItem.ToString()
        Dim args() As Object = If(all, New Object() {}, New Object() {term})
        Dim w As String = If(all, "", " WHERE Term = @p0")
        Dim t = Db.Query("SELECT COUNT(*) AS n, IFNULL(SUM(Fee), 0) AS fee, IFNULL(SUM(Paid), 0) AS paid FROM (" & Db.StudentSql & ")" & w, args).Rows(0)
        Dim fee = Convert.ToDecimal(t("fee")), paid = Convert.ToDecimal(t("paid"))
        scStudents.SetValue(t("n").ToString())
        scExpected.SetValue(Theme.Money(fee))
        scCollected.SetValue(Theme.Money(paid), Theme.Ok)
        Dim collectedPct As Integer = Pct(paid, fee)
        scCollected.SetProgress(collectedPct)
        scCollected.SubText = collectedPct & "% of expected fees"
        scOutstanding.SetValue(Theme.Money(fee - paid), If(fee - paid > 0, Theme.Danger, Theme.Ink))

        Dim items As New List(Of KeyValuePair(Of String, Integer))
        For Each r As DataRow In Db.Query("SELECT Class, SUM(Fee) AS f, SUM(Paid) AS p FROM (" & Db.StudentSql & ")" & w & " GROUP BY Class ORDER BY Class", args).Rows
            Dim p = Math.Max(0, Math.Min(100, Pct(Convert.ToDecimal(r("p")), Convert.ToDecimal(r("f")))))
            items.Add(New KeyValuePair(Of String, Integer)(r("Class").ToString() & " · " & p & "%", p))
        Next
        bcClass.SetItems(items)

        items = New List(Of KeyValuePair(Of String, Integer))
        ' Refunds are stored as negative payments with the method "Refund". They are not a way of paying, so the
        ' method shares are worked out from money received only, and refunds are shown separately underneath.
        Dim msql = "SELECT p.Method, SUM(p.Amount) AS a FROM Payments p JOIN Students s ON s.Id = p.StudentId WHERE p.Voided = 0 AND p.Method <> 'Refund'" & If(all, "", " AND s.Term = @p0") & " GROUP BY p.Method ORDER BY a DESC"
        Dim md = Db.Query(msql, args)
        Dim total As Decimal = 0
        For Each r As DataRow In md.Rows
            total += Convert.ToDecimal(r("a"))
        Next
        For Each r As DataRow In md.Rows
            Dim p = Pct(Convert.ToDecimal(r("a")), total)
            items.Add(New KeyValuePair(Of String, Integer)(r("Method").ToString() & " · " & p & "%", p))
        Next
        bcMethod.SetItems(items)
        Dim refunds As Decimal = Convert.ToDecimal(Db.Scalar("SELECT IFNULL(SUM(-p.Amount), 0) FROM Payments p JOIN Students s ON s.Id = p.StudentId WHERE p.Voided = 0 AND p.Method = 'Refund'" & If(all, "", " AND s.Term = @p0"), args))
        If refunds > 0 Then
            bcMethod.SetFooter("Refunds issued: " & Theme.Money(refunds) & " (not included above)", Theme.DangerText)
        Else
            bcMethod.SetFooter("No refunds issued")
        End If

        items = New List(Of KeyValuePair(Of String, Integer))
        Dim n = Convert.ToInt32(t("n"))
        For Each r As DataRow In Db.Query("SELECT Status, COUNT(*) AS c FROM (" & Db.StudentSql & ")" & w & " GROUP BY Status ORDER BY Status", args).Rows
            Dim c = Convert.ToInt32(r("c"))
            Dim sp As Integer = Pct(c, n)
            items.Add(New KeyValuePair(Of String, Integer)(r("Status").ToString() & " · " & c & " (" & sp & "%)", sp))
        Next
        bcStatus.SetItems(items)
        bcStatus.SetFooter(n & " student records" & If(all, "", " in " & term))
        LoadActivity()
    End Sub

    Private Sub LoadActivity()
        dgvActivity.DataSource = Db.Query("SELECT Time, UserName AS Who, Action FROM AuditLog ORDER BY Id DESC LIMIT 14")
        If dgvActivity.Columns.Count >= 3 Then
            ' one drawn column shows all three pieces of information; Time and Who stay available for painting
            dgvActivity.Columns("Time").Visible = False
            dgvActivity.Columns("Who").Visible = False
            dgvActivity.Columns("Action").FillWeight = 100
            For Each r As DataGridViewRow In dgvActivity.Rows
                r.Cells("Action").ToolTipText = Convert.ToString(r.Cells("Time").Value) & "  ·  " & Convert.ToString(r.Cells("Who").Value)
            Next
        End If
    End Sub

    ' Each entry: a small coloured dot, the action, then who did it and when (full date and time)
    Private Sub ActivityPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 OrElse dgvActivity.Columns(e.ColumnIndex).Name <> "Action" Then Return
        e.Paint(e.CellBounds, DataGridViewPaintParts.Background Or DataGridViewPaintParts.Border)
        Dim row As DataGridViewRow = dgvActivity.Rows(e.RowIndex)
        Dim action As String = Convert.ToString(row.Cells("Action").Value)
        Dim who As String = Convert.ToString(row.Cells("Who").Value)
        Dim whenText As String = Theme.FriendlyTime(Convert.ToString(row.Cells("Time").Value))
        Dim title As String = If(action = "", "", Char.ToUpper(action(0)) & action.Substring(1).ToLower())
        Dim dot As Integer = Theme.S(8)
        Dim x As Integer = e.CellBounds.X + Theme.S(4)
        Dim tx As Integer = x + dot + Theme.S(10)
        Dim w As Integer = Math.Max(10, e.CellBounds.Right - tx - Theme.S(4))
        Dim f1 As TextFormatFlags = TextFormatFlags.Left Or TextFormatFlags.VerticalCenter Or TextFormatFlags.EndEllipsis Or TextFormatFlags.NoPadding Or TextFormatFlags.NoPrefix Or TextFormatFlags.SingleLine
        Dim h1 As Integer = TextRenderer.MeasureText("Ag", Theme.BoldFont).Height
        Dim h2 As Integer = TextRenderer.MeasureText("Ag", Theme.SmallFont).Height
        Dim top As Integer = e.CellBounds.Y + (e.CellBounds.Height - h1 - h2 - Theme.S(1)) \ 2
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Using b As New SolidBrush(Theme.ActivityColor(action))
            e.Graphics.FillEllipse(b, x, top + (h1 - dot) \ 2, dot, dot)
        End Using
        TextRenderer.DrawText(e.Graphics, title, Theme.BoldFont, New Rectangle(tx, top, w, h1), Theme.Ink, f1)
        TextRenderer.DrawText(e.Graphics, If(who = "", whenText, who & "  ·  " & whenText), Theme.SmallFont, New Rectangle(tx, top + h1 + Theme.S(1), w, h2), Theme.Muted, f1)
        e.Handled = True
    End Sub
End Class
