Imports System.ComponentModel
Imports System.Drawing.Drawing2D

' ---------------------------------------------------------------------------------------------
' Custom-painted controls for the modern look. They only change how things are drawn: every
' event, property and name the screens already use is unchanged.
' ---------------------------------------------------------------------------------------------

' A white card with rounded corners, a hairline border and a very soft shadow.
' Used wherever the screens previously used a plain white Panel.
Public Class Surface
    Inherits Panel

    Private _radius As Integer = 12
    Private _shadow As Boolean = True
    Private _border As Color = Theme.Border

    Public Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
        BackColor = Color.White
    End Sub

    <DefaultValue(12)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property Radius As Integer
        Get
            Return _radius
        End Get
        Set(value As Integer)
            _radius = Math.Max(0, value)
            Invalidate()
        End Set
    End Property

    <DefaultValue(True)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property ShowShadow As Boolean
        Get
            Return _shadow
        End Get
        Set(value As Boolean)
            _shadow = value
            Invalidate()
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property BorderColor As Color
        Get
            Return _border
        End Get
        Set(value As Color)
            _border = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        ' everything is painted in OnPaint
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.Clear(If(Parent IsNot Nothing, Parent.BackColor, Theme.PageBg))
        If Width < 8 OrElse Height < 8 Then Return
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim r As Integer = Math.Min(Theme.S(_radius), Math.Min(Width, Height) \ 2 - 1)
        Dim reserve As Integer = If(_shadow, 3, 0)
        Dim body As New Rectangle(0, 0, Width - 1, Height - 1 - reserve)
        If _shadow Then
            For i As Integer = 2 To 1 Step -1
                Using p As GraphicsPath = Theme.RoundedRect(New Rectangle(0, i, body.Width, body.Height), r),
                      b As New SolidBrush(Color.FromArgb(If(i = 2, 9, 14), 15, 23, 42))
                    g.FillPath(b, p)
                End Using
            Next
        End If
        Using p As GraphicsPath = Theme.RoundedRect(body, r)
            Using b As New SolidBrush(BackColor)
                g.FillPath(b, p)
            End Using
            If _border.A > 0 Then
                Using pen As New Pen(_border, 1)
                    g.DrawPath(pen, p)
                End Using
            End If
        End Using
        MyBase.OnPaint(e)
    End Sub
End Class

' Rounded button. It paints exactly what the designer sets (BackColor, ForeColor and
' FlatAppearance colours), so every existing button keeps its meaning (primary / secondary / danger).
Public Class RoundButton
    Inherits Button

    Private hover As Boolean
    Private pressed As Boolean

    Public Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
        FlatStyle = FlatStyle.Flat
        Cursor = Cursors.Hand
        UseVisualStyleBackColor = False
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        hover = True
        Invalidate()
        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        hover = False
        pressed = False
        Invalidate()
        MyBase.OnMouseLeave(e)
    End Sub

    Protected Overrides Sub OnMouseDown(mevent As MouseEventArgs)
        If mevent.Button = MouseButtons.Left Then pressed = True
        Invalidate()
        MyBase.OnMouseDown(mevent)
    End Sub

    Protected Overrides Sub OnMouseUp(mevent As MouseEventArgs)
        pressed = False
        Invalidate()
        MyBase.OnMouseUp(mevent)
    End Sub

    Protected Overrides Sub OnEnabledChanged(e As EventArgs)
        Invalidate()
        MyBase.OnEnabledChanged(e)
    End Sub

    Protected Overrides Sub OnGotFocus(e As EventArgs)
        Invalidate()
        MyBase.OnGotFocus(e)
    End Sub

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        Invalidate()
        MyBase.OnLostFocus(e)
    End Sub

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
        Dim g As Graphics = pevent.Graphics
        g.Clear(If(Parent IsNot Nothing, Parent.BackColor, Theme.PageBg))
        If Width < 4 OrElse Height < 4 Then Return
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim fill As Color = BackColor
        Dim fore As Color = ForeColor
        Dim border As Color = FlatAppearance.BorderColor
        Dim drawBorder As Boolean = FlatAppearance.BorderSize > 0 AndAlso Not border.IsEmpty
        If Not Enabled Then
            fill = Theme.Blend(fill, Color.White, 0.55F)
            fore = Theme.Blend(fore, Color.White, 0.5F)
            border = Theme.Blend(border, Color.White, 0.55F)
        ElseIf pressed AndAlso Not FlatAppearance.MouseDownBackColor.IsEmpty Then
            fill = FlatAppearance.MouseDownBackColor
        ElseIf hover AndAlso Not FlatAppearance.MouseOverBackColor.IsEmpty Then
            fill = FlatAppearance.MouseOverBackColor
        End If
        Dim rc As New Rectangle(0, 0, Width - 1, Height - 1)
        Dim r As Integer = Math.Min(Theme.S(8), Height \ 2 - 1)
        Using p As GraphicsPath = Theme.RoundedRect(rc, r)
            Using b As New SolidBrush(fill)
                g.FillPath(b, p)
            End Using
            If drawBorder AndAlso border <> fill Then
                Using pen As New Pen(border, 1)
                    g.DrawPath(pen, p)
                End Using
            End If
            If Focused AndAlso ShowFocusCues AndAlso Enabled Then
                Dim inner As Rectangle = Rectangle.Inflate(rc, -2, -2)
                If inner.Width > 6 AndAlso inner.Height > 6 Then
                    Using fp As GraphicsPath = Theme.RoundedRect(inner, Math.Max(2, r - 2)), pen As New Pen(Color.FromArgb(110, 129, 140, 248), 2)
                        g.DrawPath(pen, fp)
                    End Using
                End If
            End If
        End Using
        Dim tr As New Rectangle(Padding.Left, 0, Math.Max(1, Width - Padding.Horizontal), Height)
        TextRenderer.DrawText(g, Text, Font, tr, fore, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter Or TextFormatFlags.EndEllipsis Or TextFormatFlags.NoPrefix Or TextFormatFlags.SingleLine)
    End Sub
End Class

' Sidebar navigation item: a drawn icon, the label, a subtle indigo background when active.
Public Class NavButton
    Inherits Button

    Private hover As Boolean
    Private _active As Boolean
    Private _icon As String = ""

    Public Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
        FlatStyle = FlatStyle.Flat
        Cursor = Cursors.Hand
        TabStop = True
    End Sub

    <DefaultValue("")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property IconName As String
        Get
            Return _icon
        End Get
        Set(value As String)
            _icon = If(value, "")
            Invalidate()
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Active As Boolean
        Get
            Return _active
        End Get
        Set(value As Boolean)
            _active = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        hover = True
        Invalidate()
        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        hover = False
        Invalidate()
        MyBase.OnMouseLeave(e)
    End Sub

    Protected Overrides Sub OnGotFocus(e As EventArgs)
        Invalidate()
        MyBase.OnGotFocus(e)
    End Sub

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        Invalidate()
        MyBase.OnLostFocus(e)
    End Sub

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
        Dim g As Graphics = pevent.Graphics
        g.Clear(If(Parent IsNot Nothing, Parent.BackColor, Theme.Dark))
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim rc As New Rectangle(0, 0, Width - 1, Height - 1)
        Dim textColor As Color = Color.FromArgb(203, 200, 236)
        Dim iconColor As Color = Color.FromArgb(165, 160, 214)
        Dim bg As Color = Color.Empty
        If _active Then
            bg = Theme.NavActive
            textColor = Color.White
            iconColor = Color.FromArgb(165, 180, 252)
        ElseIf hover Then
            bg = Theme.NavHover
            textColor = Color.White
            iconColor = Color.FromArgb(199, 196, 235)
        End If
        If Not bg.IsEmpty Then
            Using p As GraphicsPath = Theme.RoundedRect(rc, Theme.S(8)), b As New SolidBrush(bg)
                g.FillPath(b, p)
            End Using
        End If
        If Focused AndAlso ShowFocusCues Then
            Using p As GraphicsPath = Theme.RoundedRect(Rectangle.Inflate(rc, -1, -1), Theme.S(8)), pen As New Pen(Color.FromArgb(150, 129, 140, 248), 1)
                g.DrawPath(pen, p)
            End Using
        End If
        Dim icoSize As Integer = Theme.S(18)
        Dim icoRect As New Rectangle(Theme.S(14), (Height - icoSize) \ 2, icoSize, icoSize)
        If _icon <> "" Then Theme.DrawIcon(g, _icon, icoRect, iconColor)
        Dim tx As Integer = icoRect.Right + Theme.S(12)
        Dim f As Font = If(_active, Theme.BoldFont, Font)
        TextRenderer.DrawText(g, Text, f, New Rectangle(tx, 0, Math.Max(1, Width - tx - Theme.S(8)), Height), textColor, TextFormatFlags.Left Or TextFormatFlags.VerticalCenter Or TextFormatFlags.EndEllipsis Or TextFormatFlags.NoPrefix Or TextFormatFlags.SingleLine)
    End Sub
End Class

' Round avatar with initials (sidebar user block)
Public Class AvatarBadge
    Inherits Control

    Private _initials As String = "U"

    Public Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
        Size = New Size(36, 36)
    End Sub

    <DefaultValue("U")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property Initials As String
        Get
            Return _initials
        End Get
        Set(value As String)
            _initials = If(value, "")
            Invalidate()
        End Set
    End Property

    Public Shared Function InitialsOf(fullName As String) As String
        If String.IsNullOrWhiteSpace(fullName) Then Return "U"
        Dim parts() As String = fullName.Trim().Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
        If parts.Length = 1 Then Return parts(0).Substring(0, 1).ToUpper()
        Return (parts(0).Substring(0, 1) & parts(parts.Length - 1).Substring(0, 1)).ToUpper()
    End Function

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.Clear(If(Parent IsNot Nothing, Parent.BackColor, Theme.Dark))
        g.SmoothingMode = SmoothingMode.AntiAlias
        Using b As New SolidBrush(Theme.Primary)
            g.FillEllipse(b, 0, 0, Width - 1, Height - 1)
        End Using
        TextRenderer.DrawText(g, _initials, Theme.BoldFont, New Rectangle(0, 0, Width, Height), Color.White, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter Or TextFormatFlags.NoPadding Or TextFormatFlags.NoPrefix)
    End Sub
End Class

' App mark for the sidebar: rounded indigo square with a graduation cap
Public Class LogoMark
    Inherits Control

    Public Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
        Size = New Size(36, 36)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.Clear(If(Parent IsNot Nothing, Parent.BackColor, Theme.Dark))
        g.SmoothingMode = SmoothingMode.AntiAlias
        Using p As GraphicsPath = Theme.RoundedRect(New Rectangle(0, 0, Width - 1, Height - 1), Theme.S(10)), b As New SolidBrush(Theme.Primary)
            g.FillPath(b, p)
        End Using
        Dim pad As Integer = Width \ 5
        Theme.DrawIcon(g, "school", New Rectangle(pad, pad, Width - 2 * pad, Height - 2 * pad), Color.White)
    End Sub
End Class

' Statistic card: caption, large figure, optional small line, optional thin progress bar and an icon.
Public Class StatCard
    Inherits Surface

    Private _caption As String = ""
    Private _badge As String = ""
    Private _icon As String = ""
    Private _sub As String = ""
    Private _valueText As String = ""
    Private _valueColor As Color = Theme.Ink
    Private _accent As Color = Theme.Primary
    Private _progress As Single = -1
    Private _progressShown As Single = 0
    Private ReadOnly tmr As New System.Windows.Forms.Timer With {.Interval = 16}
    Private prefix As String = ""
    Private suffix As String = ""
    Private startVal As Decimal
    Private targetVal As Decimal
    Private currentVal As Decimal
    Private decimals As Integer
    Private started As Integer
    Private finalText As String = ""
    Private progFrom As Single
    Private progTo As Single
    Private progStarted As Integer

    Public Sub New()
        Dock = DockStyle.Fill
        Margin = New Padding(0, 0, 12, 12)
        Padding = New Padding(18, 12, 18, 12)
        AddHandler tmr.Tick, AddressOf OnTick
    End Sub

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property Caption As String
        Get
            Return _caption
        End Get
        Set(value As String)
            _caption = If(value, "")
            Invalidate()
        End Set
    End Property

    ' Kept for older designer files: a single character shown in the icon badge when no IconName is set
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property BadgeText As String
        Get
            Return _badge
        End Get
        Set(value As String)
            _badge = If(value, "")
            Invalidate()
        End Set
    End Property

    <DefaultValue("")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property IconName As String
        Get
            Return _icon
        End Get
        Set(value As String)
            _icon = If(value, "")
            Invalidate()
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property AccentColor As Color
        Get
            Return _accent
        End Get
        Set(value As Color)
            _accent = value
            Invalidate()
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property SubText As String
        Get
            Return _sub
        End Get
        Set(value As String)
            _sub = If(value, "")
            Invalidate()
        End Set
    End Property

    ' Shows a value; numbers count up (or down) smoothly from the previous value
    Public Sub SetValue(text As String, Optional color As Color = Nothing)
        _valueColor = If(color.IsEmpty, Theme.Ink, color)
        finalText = text
        tmr.Stop()
        Dim m = System.Text.RegularExpressions.Regex.Match(text, "^(\D*?)(\d[\d,]*(?:\.\d+)?)(\D*)$")
        Dim v As Decimal
        If DesignMode OrElse Not m.Success OrElse Not Decimal.TryParse(m.Groups(2).Value.Replace(",", ""), Globalization.NumberStyles.Number, Globalization.CultureInfo.InvariantCulture, v) Then
            _valueText = text
            currentVal = 0
            Invalidate()
            Return
        End If
        prefix = m.Groups(1).Value
        suffix = m.Groups(3).Value
        Dim num As String = m.Groups(2).Value
        Dim dot As Integer = num.IndexOf("."c)
        decimals = If(dot >= 0, num.Length - dot - 1, 0)
        startVal = currentVal
        targetVal = v
        If startVal = targetVal Then
            _valueText = text
            Invalidate()
            Return
        End If
        started = Environment.TickCount
        tmr.Start()
    End Sub

    ' Shows a thin progress bar along the bottom of the card (percent 0-100); pass a negative number to hide it
    Public Sub SetProgress(percent As Single)
        If percent < 0 Then
            _progress = -1
            Invalidate()
            Return
        End If
        progFrom = _progressShown
        progTo = Math.Max(0, Math.Min(100, percent))
        _progress = progTo
        progStarted = Environment.TickCount
        If Not DesignMode Then tmr.Start() Else _progressShown = progTo
        Invalidate()
    End Sub

    Private Sub OnTick(sender As Object, e As EventArgs)
        Dim busy As Boolean = False
        If finalText <> "" AndAlso startVal <> targetVal AndAlso currentVal <> targetVal Then
            Dim p As Double = Math.Min(1.0, (Environment.TickCount - started) / 700.0)
            Dim ease As Double = 1 - Math.Pow(1 - p, 3)
            currentVal = startVal + (targetVal - startVal) * CDec(ease)
            _valueText = prefix & currentVal.ToString("N" & decimals) & suffix
            If p >= 1.0 Then
                currentVal = targetVal
                _valueText = finalText
            Else
                busy = True
            End If
        End If
        If _progress >= 0 AndAlso _progressShown <> progTo Then
            Dim p2 As Double = Math.Min(1.0, (Environment.TickCount - progStarted) / 700.0)
            Dim ease2 As Double = 1 - Math.Pow(1 - p2, 3)
            _progressShown = progFrom + CSng((progTo - progFrom) * ease2)
            If p2 >= 1.0 Then _progressShown = progTo Else busy = True
        End If
        If Not busy Then tmr.Stop()
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim padL As Integer = Padding.Left, padT As Integer = Padding.Top, padR As Integer = Padding.Right, padB As Integer = Padding.Bottom
        Dim innerW As Integer = Width - padL - padR
        If innerW < 60 Then Return
        Dim flags As TextFormatFlags = TextFormatFlags.Left Or TextFormatFlags.VerticalCenter Or TextFormatFlags.EndEllipsis Or TextFormatFlags.NoPadding Or TextFormatFlags.NoPrefix Or TextFormatFlags.SingleLine
        Dim big As New Size(Integer.MaxValue, Integer.MaxValue)
        Dim badge As Integer = Theme.S(34)
        Dim gap As Integer = Theme.S(10)
        Dim textW As Integer = innerW - badge - gap
        Dim capH As Integer = TextRenderer.MeasureText("Ag", Theme.SmallFont).Height
        ' the figure: one fixed size for every card, only reduced when a long amount would touch the icon
        Dim size As Single = 17.0F
        Dim vf As Font = New Font("Segoe UI Semibold", size, FontStyle.Regular)
        Do While size > 11.0F AndAlso TextRenderer.MeasureText(_valueText, vf, big, TextFormatFlags.NoPadding).Width > textW
            vf.Dispose()
            size -= 1.0F
            vf = New Font("Segoe UI Semibold", size, FontStyle.Regular)
        Loop
        Dim valueH As Integer = TextRenderer.MeasureText("0", vf, big, TextFormatFlags.NoPadding).Height
        Dim topBlock As Integer = capH + Theme.S(3) + valueH
        ' caption and figure
        TextRenderer.DrawText(g, _caption, Theme.SmallFont, New Rectangle(padL, padT, textW, capH), Theme.Muted, flags)
        TextRenderer.DrawText(g, _valueText, vf, New Rectangle(padL, padT + capH + Theme.S(3), textW, valueH), _valueColor, flags)
        vf.Dispose()
        ' icon badge: right edge on the padding, centred on the caption + figure block
        Dim by As Integer = padT + Math.Max(0, (topBlock - badge) \ 2)
        Dim br As New Rectangle(Width - padR - badge, by, badge, badge)
        Using p As GraphicsPath = Theme.RoundedRect(br, Theme.S(9)), b As New SolidBrush(Theme.Tint(_accent, 0.88F))
            g.FillPath(b, p)
        End Using
        If _icon <> "" Then
            Dim isz As Integer = Theme.S(18)
            Theme.DrawIcon(g, _icon, New Rectangle(br.X + (badge - isz) \ 2, br.Y + (badge - isz) \ 2, isz, isz), _accent)
        ElseIf _badge <> "" Then
            TextRenderer.DrawText(g, _badge, Theme.BoldFont, br, _accent, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter Or TextFormatFlags.NoPadding)
        End If
        ' bottom block, built upwards: progress bar, then the small line above it. Nothing is drawn
        ' if it would run into the figure, so the two can never overlap.
        Dim floor As Integer = padT + topBlock + Theme.S(4)
        Dim bottom As Integer = Height - 3 - padB
        If _progress >= 0 Then
            Dim barH As Integer = Theme.S(6)
            Dim track As New Rectangle(padL, bottom - barH, innerW, barH)
            If track.Y >= floor Then
                Using p As GraphicsPath = Theme.RoundedRect(track, barH \ 2), b As New SolidBrush(Color.FromArgb(226, 232, 240))
                    g.FillPath(b, p)
                End Using
                Dim fw As Integer = CInt(track.Width * (_progressShown / 100.0F))
                If fw >= barH Then
                    Using p As GraphicsPath = Theme.RoundedRect(New Rectangle(track.X, track.Y, fw, track.Height), barH \ 2), b As New SolidBrush(_accent)
                        g.FillPath(b, p)
                    End Using
                ElseIf fw > 0 Then
                    Using b As New SolidBrush(_accent)
                        g.FillEllipse(b, track.X, track.Y, barH, barH)
                    End Using
                End If
                bottom = track.Y - Theme.S(4)
            End If
        End If
        If _sub <> "" Then
            Dim sh As Integer = capH
            If bottom - sh >= floor Then
                TextRenderer.DrawText(g, _sub, Theme.SmallFont, New Rectangle(padL, bottom - sh, innerW, sh), Theme.Muted, flags)
            End If
        End If
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then tmr.Dispose()
        MyBase.Dispose(disposing)
    End Sub
End Class

' Card with a title and horizontal bars (label + thin rounded bar), colours follow the status names.
Public Class BarCard
    Inherits Surface

    Private _title As String = ""
    Private _footer As String = ""
    Private _footerColor As Color = Theme.Muted
    Private ReadOnly labels As New List(Of String)
    Private ReadOnly targets As New List(Of Integer)
    Private shown As Double = 0
    Private ReadOnly tmr As New System.Windows.Forms.Timer With {.Interval = 16}
    Private started As Integer

    Public Sub New()
        Dock = DockStyle.Fill
        Margin = New Padding(0, 0, 12, 12)
        Padding = New Padding(18, 12, 18, 12)
        AddHandler tmr.Tick, AddressOf OnTick
    End Sub

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property Title As String
        Get
            Return _title
        End Get
        Set(value As String)
            _title = If(value, "")
            Invalidate()
        End Set
    End Property

    ' A small note along the bottom of the card (e.g. refunds, which are not part of the bars)
    Public Sub SetFooter(text As String, Optional color As Color = Nothing)
        _footer = If(text, "")
        _footerColor = If(color.IsEmpty, Theme.Muted, color)
        Invalidate()
    End Sub

    ' items: (label, percent 0-100); the bars fill up smoothly.
    ' A label written "Name · detail" is drawn with the name on the left and the detail on the right.
    Public Sub SetItems(items As List(Of KeyValuePair(Of String, Integer)))
        tmr.Stop()
        labels.Clear()
        targets.Clear()
        For Each it In items
            labels.Add(it.Key)
            targets.Add(Math.Max(0, Math.Min(100, it.Value)))
        Next
        shown = 0
        started = Environment.TickCount
        If DesignMode Then
            shown = 1
            Invalidate()
        Else
            tmr.Start()
        End If
    End Sub

    Private Sub OnTick(sender As Object, e As EventArgs)
        Dim p As Double = Math.Min(1.0, (Environment.TickCount - started) / 700.0)
        shown = 1 - Math.Pow(1 - p, 3)
        If p >= 1.0 Then tmr.Stop()
        Invalidate()
    End Sub

    Private Shared Function BarColor(label As String) As Color
        If label.StartsWith("Paid in full") Then Return Theme.Ok
        If label.StartsWith("Part paid") Then Return Theme.Warn
        If label.StartsWith("Owing") Then Return Theme.Danger
        Return Theme.Primary
    End Function

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        Dim x As Integer = Padding.Left
        Dim w As Integer = Width - Padding.Horizontal
        If w < 40 Then Return
        Dim lf As TextFormatFlags = TextFormatFlags.Left Or TextFormatFlags.VerticalCenter Or TextFormatFlags.EndEllipsis Or TextFormatFlags.NoPadding Or TextFormatFlags.NoPrefix Or TextFormatFlags.SingleLine
        Dim rf As TextFormatFlags = TextFormatFlags.Right Or TextFormatFlags.VerticalCenter Or TextFormatFlags.NoPadding Or TextFormatFlags.NoPrefix Or TextFormatFlags.SingleLine
        Dim titleH As Integer = TextRenderer.MeasureText("Ag", Theme.BoldFont).Height
        Dim lblH As Integer = TextRenderer.MeasureText("Ag", Theme.SmallFont).Height
        TextRenderer.DrawText(g, _title, Theme.BoldFont, New Rectangle(x, Padding.Top, w, titleH), Theme.Ink, lf)
        Dim top As Integer = Padding.Top + titleH + Theme.S(10)
        Dim bottom As Integer = Height - 3 - Padding.Bottom
        If _footer <> "" Then
            TextRenderer.DrawText(g, _footer, Theme.SmallFont, New Rectangle(x, bottom - lblH, w, lblH), _footerColor, lf)
            Using pen As New Pen(Theme.Border, 1)
                g.DrawLine(pen, x, bottom - lblH - Theme.S(5), x + w, bottom - lblH - Theme.S(5))
            End Using
            bottom -= lblH + Theme.S(9)
        End If
        If labels.Count = 0 Then
            TextRenderer.DrawText(g, "No data yet", Theme.SmallFont, New Rectangle(x, top, w, lblH), Theme.Muted, lf)
            Return
        End If
        Dim barH As Integer = Theme.S(7)
        Dim need As Integer = lblH + Theme.S(3) + barH
        Dim rowH As Integer = Math.Min(Theme.S(44), (bottom - top) \ labels.Count)
        If rowH < need Then rowH = need
        For i As Integer = 0 To labels.Count - 1
            Dim y As Integer = top + i * rowH
            If y + need > bottom + Theme.S(2) Then Exit For
            Dim name As String = labels(i), detail As String = ""
            Dim cut As Integer = name.IndexOf(" · ")
            If cut > 0 Then
                detail = name.Substring(cut + 3)
                name = name.Substring(0, cut)
            End If
            Dim dw As Integer = 0
            If detail <> "" Then
                dw = TextRenderer.MeasureText(detail, Theme.BoldFont, New Size(Integer.MaxValue, Integer.MaxValue), TextFormatFlags.NoPadding).Width
                TextRenderer.DrawText(g, detail, Theme.SmallFont, New Rectangle(x + w - dw - 1, y, dw + 2, lblH), Theme.Ink, rf)
            End If
            TextRenderer.DrawText(g, name, Theme.SmallFont, New Rectangle(x, y, Math.Max(10, w - dw - Theme.S(8)), lblH), Theme.Muted, lf)
            Dim track As New Rectangle(x, y + lblH + Theme.S(3), w, barH)
            Using p As GraphicsPath = Theme.RoundedRect(track, barH \ 2), b As New SolidBrush(Color.FromArgb(226, 232, 240))
                g.FillPath(b, p)
            End Using
            Dim fw As Integer = CInt(track.Width * (targets(i) / 100.0) * shown)
            If fw >= barH Then
                Using p As GraphicsPath = Theme.RoundedRect(New Rectangle(track.X, track.Y, fw, barH), barH \ 2), b As New SolidBrush(BarColor(labels(i)))
                    g.FillPath(b, p)
                End Using
            End If
        Next
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then tmr.Dispose()
        MyBase.Dispose(disposing)
    End Sub
End Class

' Small tile: caption and a figure (used for Fee / Paid / Balance and report summaries)
Public Class MiniStat
    Inherits Surface

    Private _caption As String = ""
    Private _value As String = ""
    Private _valueColor As Color = Theme.Ink

    Public Sub New()
        Dock = DockStyle.Fill
        Radius = 10
        ShowShadow = False
        BorderColor = Color.Transparent
        BackColor = Theme.Tile
        Margin = New Padding(0, 0, 8, 0)
        Padding = New Padding(12, 8, 12, 8)
    End Sub

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property Caption As String
        Get
            Return _caption
        End Get
        Set(value As String)
            _caption = If(value, "")
            Invalidate()
        End Set
    End Property

    Public Sub SetValue(text As String, Optional color As Color = Nothing)
        _value = text
        _valueColor = If(color.IsEmpty, Theme.Ink, color)
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim g As Graphics = e.Graphics
        Dim w As Integer = Width - Padding.Horizontal
        If w < 20 Then Return
        Dim ch As Integer = TextRenderer.MeasureText("Ag", Theme.SmallFont).Height
        TextRenderer.DrawText(g, _caption, Theme.SmallFont, New Rectangle(Padding.Left, Padding.Top, w, ch), Theme.Muted, TextFormatFlags.Left Or TextFormatFlags.EndEllipsis Or TextFormatFlags.NoPadding Or TextFormatFlags.NoPrefix Or TextFormatFlags.SingleLine)
        Dim vf As New Font("Segoe UI Semibold", 12.0F, FontStyle.Regular)
        Dim vTop As Integer = Padding.Top + ch + Theme.S(2)
        TextRenderer.DrawText(g, _value, vf, New Rectangle(Padding.Left, vTop, w, Math.Max(1, Height - vTop - Padding.Bottom)), _valueColor, TextFormatFlags.Left Or TextFormatFlags.VerticalCenter Or TextFormatFlags.EndEllipsis Or TextFormatFlags.NoPadding Or TextFormatFlags.NoPrefix Or TextFormatFlags.SingleLine)
        vf.Dispose()
    End Sub
End Class

' Footer for tables: small tiles (caption above, figure below) with a hairline on top
Public Class SummaryBar
    Inherits Control

    Private ReadOnly items As New List(Of Tuple(Of String, String, Color))

    Public Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)
        Dock = DockStyle.Bottom
        Height = 54
    End Sub

    Public Sub SetItems(ParamArray entries() As Tuple(Of String, String, Color))
        items.Clear()
        items.AddRange(entries)
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.Clear(If(Parent IsNot Nothing, Parent.BackColor, Color.White))
        Using pen As New Pen(Theme.Border, 1)
            g.DrawLine(pen, 0, 0, Width, 0)
        End Using
        Dim fl As TextFormatFlags = TextFormatFlags.Left Or TextFormatFlags.NoPadding Or TextFormatFlags.NoPrefix Or TextFormatFlags.SingleLine Or TextFormatFlags.EndEllipsis
        Dim big As New Size(Integer.MaxValue, Integer.MaxValue)
        Dim capH As Integer = TextRenderer.MeasureText("Ag", Theme.SmallFont).Height
        Dim valH As Integer = TextRenderer.MeasureText("Ag", Theme.BoldFont).Height
        Dim y As Integer = (Height - (capH + valH)) \ 2 + Theme.S(2)
        Dim x As Integer = 0
        For Each it In items
            Dim w As Integer = Math.Max(TextRenderer.MeasureText(it.Item1, Theme.SmallFont, big, TextFormatFlags.NoPadding).Width, TextRenderer.MeasureText(it.Item2, Theme.BoldFont, big, TextFormatFlags.NoPadding).Width)
            If x + w > Width Then Exit For
            TextRenderer.DrawText(g, it.Item1, Theme.SmallFont, New Rectangle(x, y, w + 2, capH), Theme.Muted, fl)
            TextRenderer.DrawText(g, it.Item2, Theme.BoldFont, New Rectangle(x, y + capH, w + 2, valH), it.Item3, fl)
            x += w + Theme.S(36)
        Next
    End Sub
End Class
