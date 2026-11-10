Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Module Theme
    ' ---- Palette -----------------------------------------------------------------------------
    Public ReadOnly Primary As Color = ColorTranslator.FromHtml("#4F46E5")       ' indigo: primary actions, active states
    Public ReadOnly PrimaryHover As Color = ColorTranslator.FromHtml("#4338CA")
    Public ReadOnly PrimaryDown As Color = ColorTranslator.FromHtml("#3730A3")
    Public ReadOnly PrimarySoft As Color = ColorTranslator.FromHtml("#EEF2FF")
    Public ReadOnly PrimarySoftDown As Color = ColorTranslator.FromHtml("#E0E7FF")
    Public ReadOnly Dark As Color = ColorTranslator.FromHtml("#211C49")          ' deep navy: sidebar
    Public ReadOnly NavActive As Color = ColorTranslator.FromHtml("#312B80")     ' indigo wash on navy (active item)
    Public ReadOnly NavHover As Color = ColorTranslator.FromHtml("#2B2562")
    Public ReadOnly PageBg As Color = ColorTranslator.FromHtml("#F8FAFC")        ' application background
    Public ReadOnly Tile As Color = ColorTranslator.FromHtml("#F1F5F9")          ' small tiles inside cards
    Public ReadOnly Ink As Color = ColorTranslator.FromHtml("#1E293B")
    Public ReadOnly Muted As Color = ColorTranslator.FromHtml("#64748B")
    Public ReadOnly Border As Color = ColorTranslator.FromHtml("#E2E8F0")
    Public ReadOnly BorderStrong As Color = ColorTranslator.FromHtml("#CBD5E1")
    Public ReadOnly Danger As Color = ColorTranslator.FromHtml("#DC2626")        ' outstanding balances, errors
    Public ReadOnly Warn As Color = ColorTranslator.FromHtml("#D97706")          ' part paid
    Public ReadOnly Ok As Color = ColorTranslator.FromHtml("#16A34A")            ' paid
    ' Darker text shades of the status colours (readable at small sizes) and their soft backgrounds
    Public ReadOnly OkText As Color = ColorTranslator.FromHtml("#15803D")
    Public ReadOnly WarnText As Color = ColorTranslator.FromHtml("#B45309")
    Public ReadOnly DangerText As Color = ColorTranslator.FromHtml("#B91C1C")
    Public ReadOnly OkSoft As Color = ColorTranslator.FromHtml("#DCFCE7")
    Public ReadOnly WarnSoft As Color = ColorTranslator.FromHtml("#FEF3C7")
    Public ReadOnly DangerSoft As Color = ColorTranslator.FromHtml("#FEE2E2")
    Public ReadOnly Accent As Color = ColorTranslator.FromHtml("#B45309")        ' small amber notes

    ' ---- Typography (Segoe UI throughout) ------------------------------------------------------
    Public ReadOnly BaseFont As New Font("Segoe UI", 10)
    Public ReadOnly SmallFont As New Font("Segoe UI", 9)
    Public ReadOnly BoldFont As New Font("Segoe UI Semibold", 10)
    Public ReadOnly TitleFont As New Font("Segoe UI Semibold", 20)
    Public ReadOnly Cedi As String = ChrW(&H20B5)
    Private dpiScale As Single = 0

    ' Scales a design pixel value to the current screen DPI
    Public Function S(n As Integer) As Integer
        If dpiScale = 0 Then
            Using g As Graphics = Graphics.FromHwnd(IntPtr.Zero)
                dpiScale = g.DpiX / 96.0F
            End Using
        End If
        Return CInt(Math.Round(n * dpiScale))
    End Function

    ' ---- Colour helpers --------------------------------------------------------------------------
    Public Function Blend(a As Color, b As Color, amountOfB As Single) As Color
        If a.IsEmpty Then Return b
        Dim t As Single = Math.Max(0F, Math.Min(1F, amountOfB))
        Return Color.FromArgb(255, CInt(a.R + (b.R - a.R) * t), CInt(a.G + (b.G - a.G) * t), CInt(a.B + (b.B - a.B) * t))
    End Function

    ' A very light version of a colour (for icon badges)
    Public Function Tint(c As Color, amount As Single) As Color
        Return Blend(c, Color.White, amount)
    End Function

    ' ---- Status chips ----------------------------------------------------------------------------
    Public Function StatusBack(status As String) As Color
        Select Case status
            Case "Paid in full", "Valid" : Return OkSoft
            Case "Part paid" : Return WarnSoft
            Case "Owing" : Return DangerSoft
            Case "Voided" : Return Tile
        End Select
        Return Tile
    End Function

    Public Function StatusColor(status As String) As Color
        Select Case status
            Case "Paid in full", "Valid" : Return OkText
            Case "Part paid" : Return WarnText
            Case "Owing" : Return DangerText
            Case "Voided" : Return ColorTranslator.FromHtml("#475569")
        End Select
        Return Ink
    End Function

    Public Function StatusDot(status As String) As Color
        Select Case status
            Case "Paid in full", "Valid" : Return Ok
            Case "Part paid" : Return Warn
            Case "Owing" : Return Danger
        End Select
        Return Muted
    End Function

    ' Paints a grid cell as a rounded status chip (soft background, coloured dot, readable text).
    ' Call from a grid's CellPainting handler for the "Status" column.
    Public Sub PaintStatus(e As DataGridViewCellPaintingEventArgs)
        If e.RowIndex < 0 OrElse e.Value Is Nothing Then Return
        e.Paint(e.CellBounds, DataGridViewPaintParts.Background Or DataGridViewPaintParts.Border)
        Dim txt As String = e.Value.ToString()
        Dim f As Font = SmallFontBold()
        Dim sz As Size = TextRenderer.MeasureText(txt, f, New Size(Integer.MaxValue, Integer.MaxValue), TextFormatFlags.NoPadding)
        Dim h As Integer = S(24)
        Dim dot As Integer = S(7)
        Dim w As Integer = Math.Min(sz.Width + S(34), e.CellBounds.Width - S(12))
        Dim rc As New Rectangle(e.CellBounds.X + S(10), e.CellBounds.Y + (e.CellBounds.Height - h) \ 2, w, h)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Using path = RoundedRect(rc, h \ 2), br As New SolidBrush(StatusBack(txt))
            e.Graphics.FillPath(br, path)
        End Using
        Using br As New SolidBrush(StatusDot(txt))
            e.Graphics.FillEllipse(br, rc.X + S(10), rc.Y + (h - dot) \ 2, dot, dot)
        End Using
        Dim tr As New Rectangle(rc.X + S(10) + dot + S(6), rc.Y, Math.Max(1, rc.Width - S(10) - dot - S(6) - S(8)), rc.Height)
        TextRenderer.DrawText(e.Graphics, txt, f, tr, StatusColor(txt), TextFormatFlags.Left Or TextFormatFlags.VerticalCenter Or TextFormatFlags.EndEllipsis Or TextFormatFlags.NoPadding Or TextFormatFlags.NoPrefix)
        e.Handled = True
    End Sub

    Private chipFont As Font
    Private Function SmallFontBold() As Font
        If chipFont Is Nothing Then chipFont = New Font("Segoe UI Semibold", 9)
        Return chipFont
    End Function

    ' Subtle indicator colour for an audit-log action (activity feed)
    Public Function ActivityColor(action As String) As Color
        Select Case If(action, "").ToUpper()
            Case "SIGN-IN" : Return Ok
            Case "SIGN-OUT", "SESSION TIMEOUT" : Return BorderStrong
            Case "LOGIN FAILED", "DELETE STUDENT", "VOID PAYMENT" : Return Danger
            Case "REFUND" : Return Warn
            Case "PAYMENT", "REGISTER STUDENT", "EDIT STUDENT", "TERM ROLLOVER", "IMPORT STUDENTS" : Return Primary
        End Select
        Return Color.FromArgb(148, 163, 184)
    End Function

    ' "2026-11-05 08:45:12" -> "Today, 08:45", "Yesterday, 08:45" or "5 Nov 2026, 08:45"
    Public Function FriendlyTime(stamp As String) As String
        Dim d As DateTime
        If Not DateTime.TryParse(stamp, Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, d) Then Return stamp
        If d.Date = DateTime.Now.Date Then Return "Today, " & d.ToString("HH:mm")
        If d.Date = DateTime.Now.Date.AddDays(-1) Then Return "Yesterday, " & d.ToString("HH:mm")
        Return d.ToString("d MMM yyyy, HH:mm", Globalization.CultureInfo.InvariantCulture)
    End Function

    Public Function RoundedRect(rc As Rectangle, radius As Integer) As GraphicsPath
        radius = Math.Max(1, Math.Min(radius, Math.Min(rc.Width, rc.Height) \ 2))
        Dim d As Integer = radius * 2
        Dim p As New GraphicsPath()
        p.AddArc(rc.X, rc.Y, d, d, 180, 90)
        p.AddArc(rc.Right - d, rc.Y, d, d, 270, 90)
        p.AddArc(rc.Right - d, rc.Bottom - d, d, d, 0, 90)
        p.AddArc(rc.X, rc.Bottom - d, d, d, 90, 90)
        p.CloseFigure()
        Return p
    End Function

    Public Function Money(v As Decimal) As String
        Return "GH" & Cedi & " " & v.ToString("N2")
    End Function

    ' ---- Small control factories (used by the screens that are built in code) ----------------------
    Public Function Lbl(text As String, Optional bold As Boolean = False, Optional muted As Boolean = False) As Label
        Dim l As New Label With {.Text = text, .AutoSize = True, .Margin = New Padding(0, 8, 8, 2)}
        l.Font = If(bold, BoldFont, BaseFont)
        l.ForeColor = If(muted, Theme.Muted, Ink)
        Return l
    End Function

    Public Function Btn(text As String, Optional isPrimary As Boolean = True, Optional width As Integer = 130) As RoundButton
        Dim b As New RoundButton With {.Text = text, .Height = S(36), .Width = S(width), .Margin = New Padding(0, 4, 8, 4)}
        b.Font = If(isPrimary, BoldFont, BaseFont)
        b.FlatAppearance.BorderColor = If(isPrimary, Primary, BorderStrong)
        b.BackColor = If(isPrimary, Primary, Color.White)
        b.ForeColor = If(isPrimary, Color.White, Primary)
        b.FlatAppearance.MouseOverBackColor = If(isPrimary, PrimaryHover, PrimarySoft)
        b.FlatAppearance.MouseDownBackColor = If(isPrimary, PrimaryDown, PrimarySoftDown)
        Return b
    End Function

    Public Function DangerBtn(text As String, Optional width As Integer = 130) As RoundButton
        Dim b As RoundButton = Btn(text, False, width)
        b.ForeColor = Danger
        b.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#FCA5A5")
        b.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#FEF2F2")
        b.FlatAppearance.MouseDownBackColor = DangerSoft
        Return b
    End Function

    Public Function Txt(Optional width As Integer = 220) As TextBox
        Return New TextBox With {.Width = S(width), .Margin = New Padding(2, 3, 8, 6), .BorderStyle = BorderStyle.FixedSingle}
    End Function

    Public Function Combo(width As Integer, ParamArray items() As String) As ComboBox
        Dim c As New ComboBox With {.Width = S(width), .DropDownStyle = ComboBoxStyle.DropDownList, .Margin = New Padding(2, 3, 8, 6), .FlatStyle = FlatStyle.Flat, .BackColor = Color.White}
        c.Items.AddRange(items)
        If c.Items.Count > 0 Then c.SelectedIndex = 0
        Return c
    End Function

    ' ---- Tables ------------------------------------------------------------------------------------
    Public Sub StyleGrid(g As DataGridView)
        g.Dock = DockStyle.Fill
        g.EnableHeadersVisualStyles = False
        g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        g.ColumnHeadersDefaultCellStyle.BackColor = Tile
        g.ColumnHeadersDefaultCellStyle.ForeColor = Muted
        g.ColumnHeadersDefaultCellStyle.Font = SmallFontBold()
        g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Tile
        g.ColumnHeadersDefaultCellStyle.SelectionForeColor = Muted
        g.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        g.ColumnHeadersDefaultCellStyle.Padding = New Padding(S(12), 0, S(10), 0)
        g.ColumnHeadersHeight = S(40)
        g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        g.DefaultCellStyle.BackColor = Color.White
        g.DefaultCellStyle.ForeColor = Ink
        g.DefaultCellStyle.Font = BaseFont
        g.DefaultCellStyle.Padding = New Padding(S(12), 0, S(10), 0)
        g.DefaultCellStyle.SelectionBackColor = PrimarySoft
        g.DefaultCellStyle.SelectionForeColor = Ink
        g.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FAFBFD")
        g.AlternatingRowsDefaultCellStyle.SelectionBackColor = PrimarySoft
        g.AlternatingRowsDefaultCellStyle.SelectionForeColor = Ink
        g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        g.GridColor = ColorTranslator.FromHtml("#EEF2F6")
        g.RowHeadersVisible = False
        g.AllowUserToAddRows = False
        g.AllowUserToDeleteRows = False
        g.AllowUserToResizeRows = False
        g.ReadOnly = True
        g.MultiSelect = False
        g.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        g.BorderStyle = BorderStyle.None
        g.BackgroundColor = Color.White
        g.RowTemplate.Height = S(42)
        g.ShowCellToolTips = True
    End Sub

    ' Makes sure no column is narrower than its heading or its widest value (up to a limit),
    ' so text is never cut off; if the columns do not fit, the grid scrolls sideways instead.
    ' Runs after the grid has been created and laid out, because changing column widths earlier can fail.
    Public Sub FitColumns(g As DataGridView, Optional maxPx As Integer = 0)
        If g Is Nothing OrElse g.IsDisposed Then Return
        If maxPx = 0 Then maxPx = S(260)
        If g.IsHandleCreated Then
            g.BeginInvoke(New Action(Sub() FitColumnsNow(g, maxPx)))
        Else
            Dim h As EventHandler = Nothing
            h = Sub(sender As Object, e As EventArgs)
                    RemoveHandler g.HandleCreated, h
                    g.BeginInvoke(New Action(Sub() FitColumnsNow(g, maxPx)))
                End Sub
            AddHandler g.HandleCreated, h
        End If
    End Sub

    Private Sub FitColumnsNow(g As DataGridView, maxPx As Integer)
        If g.IsDisposed OrElse g.Columns.Count = 0 Then Return
        For Each c As DataGridViewColumn In g.Columns
            If Not c.Visible Then Continue For
            Try
                ' numbers line up on the right, and so do their headings
                If c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight Then
                    c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
                Dim w As Integer = TextRenderer.MeasureText(c.HeaderText, SmallFontBold()).Width + S(32)
                Dim n As Integer = 0
                For Each r As DataGridViewRow In g.Rows
                    If n >= 60 Then Exit For
                    Dim v As String = Convert.ToString(r.Cells(c.Index).FormattedValue)
                    If v <> "" Then
                        Dim extra As Integer = If(c.Name = "Status", S(52), S(32))
                        w = Math.Max(w, TextRenderer.MeasureText(v, If(c.Name = "Status", SmallFontBold(), BaseFont)).Width + extra)
                    End If
                    n += 1
                Next
                c.MinimumWidth = Math.Min(w, maxPx)
            Catch
                ' leave this column at its default width rather than failing
            End Try
        Next
    End Sub

    Public Function CardPanel() As Surface
        Return New Surface With {.Padding = New Padding(S(16), S(14), S(16), S(16)), .Margin = New Padding(0, 0, S(10), S(10)), .Dock = DockStyle.Fill}
    End Function

    Public Function Esc(s As String) As String
        Return s.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]").Replace("_", "[_]")
    End Function

    ' ---- One-call finishing touches for a screen or dialog --------------------------------------
    ' Default text colour, and an indigo focus ring around the text boxes and drop-downs.
    Public Sub Polish(root As Control)
        If root Is Nothing Then Return
        If root.ForeColor = SystemColors.ControlText Then root.ForeColor = Ink
        ApplyPolish(root)
    End Sub

    Private Sub ApplyPolish(c As Control)
        For Each ch As Control In c.Controls
            Dim tb = TryCast(ch, TextBox)
            If tb IsNot Nothing Then
                If tb.BorderStyle = BorderStyle.FixedSingle Then HookFocusRing(tb)
            ElseIf TypeOf ch Is ComboBox Then
                HookFocusRing(ch)
            End If
            If ch.HasChildren Then ApplyPolish(ch)
        Next
    End Sub

    Private ReadOnly ringParents As New System.Runtime.CompilerServices.ConditionalWeakTable(Of Control, Object)
    Private ReadOnly ringInputs As New System.Runtime.CompilerServices.ConditionalWeakTable(Of Control, Object)

    Private Sub HookFocusRing(input As Control)
        Dim seen As Object = Nothing
        If ringInputs.TryGetValue(input, seen) Then Return
        ringInputs.Add(input, New Object())
        AddHandler input.GotFocus, Sub(s, e) RepaintRing(input)
        AddHandler input.LostFocus, Sub(s, e) RepaintRing(input)
    End Sub

    Private Sub RepaintRing(input As Control)
        Dim p As Control = input.Parent
        If p Is Nothing OrElse p.IsDisposed Then Return
        Dim marker As Object = Nothing
        If Not ringParents.TryGetValue(p, marker) Then
            ringParents.Add(p, New Object())
            AddHandler p.Paint, AddressOf PaintRings
        End If
        Dim r As Rectangle = input.Bounds
        r.Inflate(4, 4)
        p.Invalidate(r)
    End Sub

    Private Sub PaintRings(sender As Object, e As PaintEventArgs)
        Dim parent = DirectCast(sender, Control)
        For Each c As Control In parent.Controls
            If c.Visible AndAlso c.Focused AndAlso (TypeOf c Is TextBox OrElse TypeOf c Is ComboBox) Then
                Dim r As Rectangle = c.Bounds
                r.Inflate(2, 2)
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
                Using p As GraphicsPath = RoundedRect(r, 4), pen As New Pen(Color.FromArgb(170, 79, 70, 229), 2)
                    e.Graphics.DrawPath(pen, p)
                End Using
            End If
        Next
    End Sub

    ' ---- Vector icons (no icon fonts or image files needed) -------------------------------------
    ' Draws a simple line icon into rc. Names: dashboard, students, payments, reports, audit, users,
    ' fees, cash, receipt, alert, progress, school.
    Public Sub DrawIcon(g As Graphics, name As String, rc As Rectangle, color As Color)
        Dim sc As Single = rc.Width / 24.0F
        Dim old = g.SmoothingMode
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim pen As New Pen(color, Math.Max(1.4F, 1.8F * sc)) With {.StartCap = LineCap.Round, .EndCap = LineCap.Round, .LineJoin = LineJoin.Round}
        Dim br As New SolidBrush(color)
        Dim P As Func(Of Single, Single, PointF) = Function(x, y) New PointF(rc.X + x * sc, rc.Y + y * sc)
        Dim R As Func(Of Single, Single, Single, Single, RectangleF) = Function(x, y, w, h) New RectangleF(rc.X + x * sc, rc.Y + y * sc, w * sc, h * sc)
        Try
            Select Case name
                Case "dashboard"
                    DrawRound(g, pen, R(3, 3, 7.5F, 9), 2 * sc)
                    DrawRound(g, pen, R(13.5F, 3, 7.5F, 5), 2 * sc)
                    DrawRound(g, pen, R(13.5F, 12, 7.5F, 9), 2 * sc)
                    DrawRound(g, pen, R(3, 15, 7.5F, 6), 2 * sc)
                Case "students"
                    g.DrawEllipse(pen, R(8.5F, 3.5F, 7, 7))
                    g.DrawArc(pen, R(4, 13, 16, 15), 180, 180)
                Case "users"
                    g.DrawEllipse(pen, R(6.5F, 4, 6, 6))
                    g.DrawArc(pen, R(2.5F, 13, 14, 13), 180, 180)
                    g.DrawArc(pen, R(14.5F, 5.5F, 5, 5), 270, 180)
                    g.DrawArc(pen, R(15, 13.5F, 7, 10), 270, 90)
                Case "payments"
                    DrawRound(g, pen, R(2.5F, 5, 19, 14), 2.5F * sc)
                    g.DrawLine(pen, P(2.5F, 10), P(21.5F, 10))
                    g.DrawLine(pen, P(6, 15), P(10, 15))
                Case "cash"
                    DrawRound(g, pen, R(2.5F, 6, 19, 12), 2.5F * sc)
                    g.DrawEllipse(pen, R(9, 9, 6, 6))
                Case "reports"
                    g.DrawLine(pen, P(6, 20), P(6, 13))
                    g.DrawLine(pen, P(12, 20), P(12, 5))
                    g.DrawLine(pen, P(18, 20), P(18, 9))
                Case "audit"
                    DrawRound(g, pen, R(5, 4, 14, 17), 2.5F * sc)
                    g.DrawLines(pen, New PointF() {P(9, 12.5F), P(11, 14.5F), P(15, 9.5F)})
                Case "receipt"
                    g.DrawLines(pen, New PointF() {P(6, 3), P(18, 3), P(18, 21), P(15, 19), P(12, 21), P(9, 19), P(6, 21), P(6, 3)})
                    g.DrawLine(pen, P(9, 8), P(15, 8))
                    g.DrawLine(pen, P(9, 12), P(15, 12))
                Case "fees"
                    For Each row In New Single()() {New Single() {7, 15}, New Single() {12, 8.5F}, New Single() {17, 16}}
                        Dim ry As Single = row(0), kx As Single = row(1)
                        g.DrawLine(pen, P(3.5F, ry), P(kx - 2.8F, ry))
                        g.DrawLine(pen, P(kx + 2.8F, ry), P(20.5F, ry))
                        g.DrawEllipse(pen, R(kx - 2.2F, ry - 2.2F, 4.4F, 4.4F))
                    Next
                Case "alert"
                    g.DrawEllipse(pen, R(3, 3, 18, 18))
                    g.DrawLine(pen, P(12, 7.5F), P(12, 13))
                    g.FillEllipse(br, R(11, 15.5F, 2, 2))
                Case "progress"
                    g.DrawEllipse(pen, R(3, 3, 18, 18))
                    g.DrawEllipse(pen, R(7.5F, 7.5F, 9, 9))
                    g.FillEllipse(br, R(10.5F, 10.5F, 3, 3))
                Case "school"
                    g.DrawLines(pen, New PointF() {P(12, 4.5F), P(22, 9.5F), P(12, 14.5F), P(2, 9.5F), P(12, 4.5F)})
                    g.DrawLines(pen, New PointF() {P(6.5F, 12), P(6.5F, 16.5F), P(12, 19.5F), P(17.5F, 16.5F), P(17.5F, 12)})
                    g.DrawLine(pen, P(22, 9.5F), P(22, 15))
            End Select
        Finally
            pen.Dispose()
            br.Dispose()
            g.SmoothingMode = old
        End Try
    End Sub

    Private Sub DrawRound(g As Graphics, pen As Pen, rf As RectangleF, radius As Single)
        Dim rc As Rectangle = Rectangle.Round(rf)
        Using p As GraphicsPath = RoundedRect(rc, Math.Max(1, CInt(radius)))
            g.DrawPath(pen, p)
        End Using
    End Sub
End Module
