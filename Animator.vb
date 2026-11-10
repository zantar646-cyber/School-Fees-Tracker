' Small animation helpers (all timer-based, no extra packages)
Public Module Animator
    Public Function EaseOut(t As Double) As Double
        Return 1 - Math.Pow(1 - t, 3)
    End Function

    ' Fades a window in when it is first shown
    Public Sub FadeIn(f As Form, Optional ms As Integer = 220)
        f.Opacity = 0
        AddHandler f.Shown, Sub(a As Object, b As EventArgs)
                                Dim t0 As Integer = Environment.TickCount
                                Dim t As New System.Windows.Forms.Timer With {.Interval = 15}
                                AddHandler t.Tick, Sub(c As Object, d As EventArgs)
                                                       If f.IsDisposed Then
                                                           t.Stop()
                                                           t.Dispose()
                                                           Return
                                                       End If
                                                       Dim p As Double = Math.Min(1.0, (Environment.TickCount - t0) / CDbl(ms))
                                                       f.Opacity = EaseOut(p)
                                                       If p >= 1.0 Then
                                                           f.Opacity = 1
                                                           t.Stop()
                                                           t.Dispose()
                                                       End If
                                                   End Sub
                                t.Start()
                            End Sub
    End Sub

    ' Quick left-right shake (used for a failed sign-in)
    Public Sub Shake(f As Form)
        Dim origin As Integer = f.Left
        Dim offs() As Integer = {-12, 12, -9, 9, -6, 6, -3, 3, 0}
        Dim idx As Integer = 0
        Dim t As New System.Windows.Forms.Timer With {.Interval = 22}
        AddHandler t.Tick, Sub(a As Object, b As EventArgs)
                               If f.IsDisposed OrElse idx >= offs.Length Then
                                   t.Stop()
                                   t.Dispose()
                                   If Not f.IsDisposed Then f.Left = origin
                                   Return
                               End If
                               f.Left = origin + offs(idx)
                               idx += 1
                           End Sub
        t.Start()
    End Sub

    ' Slides a page in from the left by animating the host panel's left padding
    Public Sub SlideIn(host As Panel, basePad As Padding, Optional ms As Integer = 240)
        Dim dist As Integer = Theme.S(44)
        Dim t0 As Integer = Environment.TickCount
        Dim t As New System.Windows.Forms.Timer With {.Interval = 15}
        AddHandler t.Tick, Sub(a As Object, b As EventArgs)
                               If host.IsDisposed Then
                                   t.Stop()
                                   t.Dispose()
                                   Return
                               End If
                               Dim p As Double = Math.Min(1.0, (Environment.TickCount - t0) / CDbl(ms))
                               host.Padding = New Padding(basePad.Left + CInt(dist * (1 - EaseOut(p))), basePad.Top, basePad.Right, basePad.Bottom)
                               If p >= 1.0 Then
                                   host.Padding = basePad
                                   t.Stop()
                                   t.Dispose()
                               End If
                           End Sub
        t.Start()
    End Sub

    ' Glides a control to a new Top position
    Public Sub MoveTop(c As Control, target As Integer, Optional ms As Integer = 200)
        Dim startY As Integer = c.Top
        Dim t0 As Integer = Environment.TickCount
        Dim t As New System.Windows.Forms.Timer With {.Interval = 15}
        AddHandler t.Tick, Sub(a As Object, b As EventArgs)
                               If c.IsDisposed Then
                                   t.Stop()
                                   t.Dispose()
                                   Return
                               End If
                               Dim p As Double = Math.Min(1.0, (Environment.TickCount - t0) / CDbl(ms))
                               c.Top = startY + CInt((target - startY) * EaseOut(p))
                               If p >= 1.0 Then
                                   c.Top = target
                                   t.Stop()
                                   t.Dispose()
                               End If
                           End Sub
        t.Start()
    End Sub
End Module

' A panel that paints without flicker (used for the page area that slides)
Public Class BufferedPanel
    Inherits Panel
    Public Sub New()
        DoubleBuffered = True
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    End Sub
End Class

' A small message that slides up, stays a moment, then fades away (does not steal focus)
Public Class Toast
    Inherits Form
    Private ReadOnly lbl As New Label
    Private ReadOnly tmr As New System.Windows.Forms.Timer With {.Interval = 15}
    Private started As Integer
    Private baseTop As Integer
    Private ownerForm As Form

    Public Shared Sub Notify(owner As Control, text As String, Optional isError As Boolean = False)
        Dim f As Form = Nothing
        If owner IsNot Nothing Then f = owner.FindForm()
        Dim t As New Toast(text, isError)
        t.ownerForm = f
        t.Show(f)
    End Sub

    Private Sub New(text As String, isError As Boolean)
        FormBorderStyle = FormBorderStyle.None
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        TopMost = True
        AutoSize = True
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        BackColor = If(isError, Theme.Danger, Theme.Dark)
        Padding = New Padding(Theme.S(20), Theme.S(12), Theme.S(20), Theme.S(12))
        lbl.AutoSize = True
        lbl.ForeColor = Color.White
        lbl.Font = Theme.BoldFont
        lbl.Text = text
        lbl.MaximumSize = New Size(Theme.S(420), 0)
        Controls.Add(lbl)
        Opacity = 0
    End Sub

    Protected Overrides ReadOnly Property ShowWithoutActivation As Boolean
        Get
            Return True
        End Get
    End Property

    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)
        Dim area As Rectangle = If(ownerForm IsNot Nothing, ownerForm.Bounds, Screen.PrimaryScreen.WorkingArea)
        Left = area.Right - Width - Theme.S(28)
        baseTop = area.Bottom - Height - Theme.S(28)
        Top = baseTop + Theme.S(16)
        started = Environment.TickCount
        AddHandler tmr.Tick, AddressOf OnTick
        tmr.Start()
    End Sub

    Private Sub OnTick(sender As Object, e As EventArgs)
        Dim t As Integer = Environment.TickCount - started
        If t < 220 Then
            Dim p As Double = EaseOut(t / 220.0)
            Opacity = 0.96 * p
            Top = baseTop + CInt(Theme.S(16) * (1 - p))
        ElseIf t < 2800 Then
            Opacity = 0.96
            Top = baseTop
        ElseIf t < 3200 Then
            Opacity = 0.96 * (1 - (t - 2800) / 400.0)
        Else
            tmr.Stop()
            Close()
        End If
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing Then tmr.Dispose()
        MyBase.Dispose(disposing)
    End Sub
End Class
