Public Module ReportPrinter
    Private tbl As DataTable
    Private ttl As String, subTtl As String, school As String
    Private rowIdx As Integer, pageNo As Integer
    Private colX() As Single, colW() As Single

    Private Function Fmt(v As Object, t As Type) As String
        If v Is Nothing OrElse v Is DBNull.Value Then Return ""
        If t Is GetType(Double) OrElse t Is GetType(Decimal) Then Return Convert.ToDecimal(v).ToString("N2")
        Return v.ToString()
    End Function

    Public Sub PrintTable(title As String, subtitle As String, dt As DataTable, owner As IWin32Window, Optional landscape As Boolean = False)
        tbl = dt : ttl = title : subTtl = subtitle : school = Db.SchoolName()
        Using doc As New PrintDocument(), prev As New PrintPreviewDialog()
            doc.DefaultPageSettings.Landscape = landscape
            AddHandler doc.BeginPrint, Sub(s, e)
                                           rowIdx = 0
                                           pageNo = 0
                                       End Sub
            AddHandler doc.PrintPage, AddressOf DrawPage
            prev.Document = doc
            prev.WindowState = FormWindowState.Maximized
            prev.ShowDialog(owner)
        End Using
        AuditLogger.LogOnly("REPORT", title, "", "Preview opened, " & dt.Rows.Count & " rows")
    End Sub

    Private Sub Layout(width As Single, left As Single)
        Dim n As Integer = tbl.Columns.Count
        Dim wts(n - 1) As Single
        For i = 0 To n - 1
            wts(i) = Math.Max(6, tbl.Columns(i).ColumnName.Length)
            For r = 0 To Math.Min(tbl.Rows.Count, 200) - 1
                wts(i) = Math.Max(wts(i), Math.Min(28, Fmt(tbl.Rows(r)(i), tbl.Columns(i).DataType).Length))
            Next
        Next
        Dim total As Single = wts.Sum()
        ReDim colX(n - 1)
        ReDim colW(n - 1)
        Dim x As Single = left
        For i = 0 To n - 1
            colW(i) = wts(i) / total * width
            colX(i) = x
            x += colW(i)
        Next
    End Sub

    Private Sub DrawPage(sender As Object, e As PrintPageEventArgs)
        Dim g As Graphics = e.Graphics
        Dim m As Rectangle = e.MarginBounds
        pageNo += 1
        Layout(m.Width, m.Left)
        Dim y As Single = m.Top
        Using fT As New Font("Segoe UI", 15, FontStyle.Bold), fS As New Font("Segoe UI", 9), fH As New Font("Segoe UI", 9, FontStyle.Bold),
              hdr As New SolidBrush(Theme.Primary), shade As New SolidBrush(Color.FromArgb(248, 250, 252)), ink As New SolidBrush(Color.Black), muted As New SolidBrush(Theme.Muted)
            g.DrawString(school, fT, ink, m.Left, y)
            y += 30
            g.DrawString(ttl, fH, ink, m.Left, y)
            y += 20
            If subTtl <> "" Then
                g.DrawString(subTtl, fS, muted, m.Left, y)
                y += 20
            End If
            y += 6
            Dim rowH As Single = 22
            g.FillRectangle(hdr, m.Left, y, m.Width, rowH)
            Using sfL As New StringFormat With {.Trimming = StringTrimming.EllipsisCharacter, .FormatFlags = StringFormatFlags.NoWrap}
                Using sfR As New StringFormat With {.Trimming = StringTrimming.EllipsisCharacter, .FormatFlags = StringFormatFlags.NoWrap, .Alignment = StringAlignment.Far}
                    Using white As New SolidBrush(Color.White)
                        For i = 0 To tbl.Columns.Count - 1
                            g.DrawString(tbl.Columns(i).ColumnName, fH, white, New RectangleF(colX(i) + 3, y + 3, colW(i) - 6, rowH), If(IsNumeric(tbl.Columns(i).DataType), sfR, sfL))
                        Next
                    End Using
                    y += rowH
                    While rowIdx < tbl.Rows.Count AndAlso y + rowH < m.Bottom - 24
                        If rowIdx Mod 2 = 1 Then g.FillRectangle(shade, m.Left, y, m.Width, rowH)
                        For i = 0 To tbl.Columns.Count - 1
                            g.DrawString(Fmt(tbl.Rows(rowIdx)(i), tbl.Columns(i).DataType), fS, ink, New RectangleF(colX(i) + 3, y + 3, colW(i) - 6, rowH), If(IsNumeric(tbl.Columns(i).DataType), sfR, sfL))
                        Next
                        y += rowH
                        rowIdx += 1
                    End While
                End Using
            End Using
            g.DrawString("Page " & pageNo & "   ·   printed " & Now.ToString("dd MMM yyyy HH:mm") & " by " & Session.UserName, fS, muted, m.Left, m.Bottom - 16)
        End Using
        e.HasMorePages = rowIdx < tbl.Rows.Count
    End Sub

    Private Function IsNumeric(t As Type) As Boolean
        Return t Is GetType(Double) OrElse t Is GetType(Decimal) OrElse t Is GetType(Long) OrElse t Is GetType(Integer)
    End Function
End Module

Public Class StatementDialog
    Inherits Form
    Private ReadOnly dt As DataTable
    Private ReadOnly docTitle As String
    Private ReadOnly docSub As String

    Public Sub New(studentId As String)
        Dim st As DataRow = Db.Query("SELECT * FROM (" & Db.StudentSql & ") WHERE Id = @p0", studentId).Rows(0)
        Dim pid As String = Convert.ToString(Db.Scalar("SELECT IFNULL(PersonId, Id) FROM Students WHERE Id = @p0", studentId))
        Dim tot As DataRow = Db.Query("SELECT IFNULL(SUM(Fee), 0) AS f, IFNULL(SUM(Paid), 0) AS p FROM (" & Db.StudentSql & ") WHERE Id IN (SELECT Id FROM Students WHERE IFNULL(PersonId, Id) = @p0)", pid).Rows(0)
        Dim fee = Convert.ToDecimal(tot("f")), paid = Convert.ToDecimal(tot("p"))
        docTitle = "Fee statement: " & st("Name").ToString() & " (" & studentId & ")"
        docSub = "All terms     Fee " & fee.ToString("N2") & "     Paid " & paid.ToString("N2") & "     Balance " & (fee - paid).ToString("N2")
        dt = Db.Query("SELECT IFNULL(p.Batch, p.Id) AS Receipt, s.Class, s.Term, p.PaidOn AS Date, p.Amount, p.Method, IFNULL(p.Ref, '') AS Reference, p.ByUser AS ReceivedBy, CASE WHEN p.Voided = 1 THEN 'Voided' ELSE 'Valid' END AS Status FROM Payments p JOIN Students s ON s.Id = p.StudentId WHERE IFNULL(s.PersonId, s.Id) = @p0 ORDER BY p.PaidOn, p.Id", pid)

        Text = "Statement · " & st("Name").ToString()
        Font = Theme.BaseFont
        ClientSize = New Size(Theme.S(860), Theme.S(540))
        StartPosition = FormStartPosition.CenterParent
        MinimizeBox = False : ShowInTaskbar = False
        BackColor = Color.White
        Padding = New Padding(Theme.S(20))
        Dim head As New Label With {.Dock = DockStyle.Top, .Height = Theme.S(70), .Text = docTitle & vbCrLf & docSub, .Font = Theme.BoldFont}
        Dim g As New DataGridView
        Theme.StyleGrid(g)
        AddHandler Shown, Sub(sender As Object, e As EventArgs)
                              g.DataSource = dt
                              Theme.FitColumns(g)
                              If g.Columns.Contains("Amount") Then
                                  g.Columns("Amount").DefaultCellStyle.Format = "N2"
                                  g.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                              End If
                          End Sub
        Dim bPrint = Theme.Btn("Print statement", True, 160)
        Dim bClose = Theme.Btn("Close", False, 100)
        Controls.Add(g)
        Controls.Add(head)
        Controls.Add(ButtonBar(bClose, bPrint))
        AddHandler bPrint.Click, Sub() ReportPrinter.PrintTable(docTitle, docSub, dt, Me)
        AddHandler bClose.Click, Sub() Close()
        AddHandler g.CellPainting, Sub(sender As Object, e As DataGridViewCellPaintingEventArgs)
                                       If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso g.Columns(e.ColumnIndex).Name = "Status" Then Theme.PaintStatus(e)
                                   End Sub
        Theme.Polish(Me)
    End Sub
End Class

Public Class ReportsView
    Inherits UserControl
    Private ReadOnly dgv As New DataGridView
    Private ReadOnly cboReport As ComboBox = Theme.Combo(260, "Arrears list", "Collection summary by class", "Daily collections")
    Private ReadOnly cboTerm As ComboBox = Theme.Combo(140, "All terms", "Term 1", "Term 2", "Term 3")
    Private dt As DataTable
    Private reportName As String = ""
    Private ReadOnly summary As New FlowLayoutPanel With {.Dock = DockStyle.Top, .AutoSize = True, .AutoSizeMode = AutoSizeMode.GrowAndShrink, .WrapContents = True, .Padding = New Padding(0, 0, 0, Theme.S(10))}
    Private ReadOnly tileA As New MiniStat With {.Dock = DockStyle.None, .Size = New Size(Theme.S(220), Theme.S(60)), .Margin = New Padding(0, 0, Theme.S(12), Theme.S(6))}
    Private ReadOnly tileB As New MiniStat With {.Dock = DockStyle.None, .Size = New Size(Theme.S(220), Theme.S(60)), .Margin = New Padding(0, 0, Theme.S(12), Theme.S(6))}
    Private ReadOnly tileC As New MiniStat With {.Dock = DockStyle.None, .Size = New Size(Theme.S(220), Theme.S(60)), .Margin = New Padding(0, 0, Theme.S(12), Theme.S(6))}

    Public Sub New()
        Dock = DockStyle.Fill
        BackColor = Theme.PageBg
        Theme.StyleGrid(dgv)
        Dim bar As New FlowLayoutPanel With {.Dock = DockStyle.Top, .AutoSize = True, .Padding = New Padding(0, 0, 0, Theme.S(10))}
        summary.Controls.AddRange(New Control() {tileA, tileB, tileC})
        bar.Controls.Add(Theme.Lbl("Report"))
        bar.Controls.Add(cboReport)
        bar.Controls.Add(Theme.Lbl("Term"))
        bar.Controls.Add(cboTerm)
        Dim bPrint = Theme.Btn("Print", True, 100)
        Dim bCsv = Theme.Btn("Export CSV", False, 120)
        bar.Controls.Add(bPrint)
        bar.Controls.Add(bCsv)
        Dim card = Theme.CardPanel()
        card.Controls.Add(dgv)
        card.Controls.Add(summary)
        card.Controls.Add(bar)
        Controls.Add(card)
        Controls.Add(New Label With {.Text = "Reports", .Font = Theme.TitleFont, .Dock = DockStyle.Top, .Height = Theme.S(52), .TextAlign = ContentAlignment.MiddleLeft})
        AddHandler dgv.CellPainting, Sub(sender As Object, e As DataGridViewCellPaintingEventArgs)
                                         If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso dgv.Columns(e.ColumnIndex).Name = "Status" Then Theme.PaintStatus(e)
                                     End Sub
        Theme.Polish(Me)
        AddHandler cboReport.SelectedIndexChanged, AddressOf Build
        AddHandler cboTerm.SelectedIndexChanged, AddressOf Build
        AddHandler bPrint.Click, Sub() ReportPrinter.PrintTable(reportName, "Term: " & cboTerm.SelectedItem.ToString(), dt, FindForm(), True)
        AddHandler bCsv.Click, Sub() Helpers.ExportView(New DataView(dt), "report")
        AddHandler Load, Sub(sender As Object, e As EventArgs) Build(Nothing, Nothing)
    End Sub

    Private Sub Build(s As Object, e As EventArgs)
        Try
            BuildCore()
        Catch ex As Exception
            MessageBox.Show("The report could not be built: " & ex.Message, "Reports")
        End Try
    End Sub

    Private Sub BuildCore()
        Dim all As Boolean = cboTerm.SelectedIndex <= 0
        Dim args() As Object = If(all, New Object() {}, New Object() {cboTerm.SelectedItem.ToString()})
        Dim w As String = If(all, "", " AND Term = @p0")
        Select Case cboReport.SelectedIndex
            Case 0
                reportName = "Arrears list"
                dt = Db.Query("SELECT Id, Name, Class, Term, Phone AS GuardianPhone, Fee, Paid, Balance, Status FROM (" & Db.StudentSql & ") WHERE Balance > 0" & w & " ORDER BY Class, Name", args)
            Case 1
                reportName = "Collection summary by class"
                dt = Db.Query("SELECT Class, Term, COUNT(*) AS Students, SUM(Fee) AS Expected, SUM(Paid) AS Collected, SUM(Balance) AS Outstanding, ROUND(100.0 * SUM(Paid) / SUM(Fee), 1) AS PercentCollected FROM (" & Db.StudentSql & ") WHERE 1 = 1" & w & " GROUP BY Class, Term ORDER BY Term, Class", args)
            Case Else
                reportName = "Daily collections (last 60 days with payments)"
                dt = Db.Query("SELECT SUBSTR(PaidOn, 1, 10) AS Date, COUNT(*) AS Payments, SUM(Amount) AS Collected FROM Payments WHERE Voided = 0 GROUP BY SUBSTR(PaidOn, 1, 10) ORDER BY Date DESC LIMIT 60")
        End Select
        dgv.DataSource = dt
        ShowSummary()
        Theme.FitColumns(dgv)
        For Each c As DataGridViewColumn In dgv.Columns
            If c.ValueType Is GetType(Double) Then
                c.DefaultCellStyle.Format = "N2"
                c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Next
    End Sub

    Private Function ColSum(col As String) As Decimal
        If dt Is Nothing OrElse Not dt.Columns.Contains(col) Then Return 0
        Dim v = dt.Compute("SUM(" & col & ")", "")
        If v Is Nothing OrElse v Is DBNull.Value Then Return 0
        Return Convert.ToDecimal(v)
    End Function

    ' Headline figures worked out from the rows of the report that is on screen
    Private Sub ShowSummary()
        Select Case cboReport.SelectedIndex
            Case 0
                tileA.Caption = "Students owing" : tileA.SetValue(dt.Rows.Count.ToString())
                tileB.Caption = "Fees for these students" : tileB.SetValue(Theme.Money(ColSum("Fee")))
                tileC.Caption = "Total outstanding" : tileC.SetValue(Theme.Money(ColSum("Balance")), If(ColSum("Balance") > 0, Theme.Danger, Theme.Ink))
            Case 1
                tileA.Caption = "Expected" : tileA.SetValue(Theme.Money(ColSum("Expected")))
                tileB.Caption = "Collected" : tileB.SetValue(Theme.Money(ColSum("Collected")), Theme.Ok)
                tileC.Caption = "Outstanding" : tileC.SetValue(Theme.Money(ColSum("Outstanding")), If(ColSum("Outstanding") > 0, Theme.Danger, Theme.Ink))
            Case Else
                tileA.Caption = "Days shown" : tileA.SetValue(dt.Rows.Count.ToString())
                tileB.Caption = "Payments" : tileB.SetValue(ColSum("Payments").ToString("N0"))
                tileC.Caption = "Collected" : tileC.SetValue(Theme.Money(ColSum("Collected")), Theme.Ok)
        End Select
    End Sub
End Class
