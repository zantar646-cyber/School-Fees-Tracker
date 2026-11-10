Public Class MainForm
    Public LoggedOut As Boolean
    Private ReadOnly navButtons As New List(Of Button)
    Private ReadOnly idle As New IdleFilter
    Private ReadOnly tmr As New System.Windows.Forms.Timer With {.Interval = 30000}
    Private activeBtn As Button
    Private basePad As Padding

    Public Sub New()
        InitializeComponent()
        navButtons.AddRange({btnNavDashboard, btnNavStudents, btnNavPayments, btnNavReports, btnNavAudit, btnNavUsers, btnNavFees})
        Theme.Polish(Me)
        Animator.FadeIn(Me)
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Helpers.ApplyIcon(Me)
        basePad = pnlContent.Padding
        lblUser.Text = Session.FullName
        lblRole.Text = Session.Role
        avatar.Initials = AvatarBadge.InitialsOf(Session.FullName)
        lblAdmin.Visible = Session.IsAdmin
        btnNavAudit.Visible = Session.IsAdmin
        btnNavUsers.Visible = Session.IsAdmin
        btnNavFees.Visible = Session.IsAdmin
        Application.AddMessageFilter(idle)
        AddHandler tmr.Tick, AddressOf CheckIdle
        tmr.Start()
        Navigate(btnNavDashboard, Home())
    End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        MoveIndicator(activeBtn, False)
    End Sub

    Private Function Home() As UserControl
        If Session.IsAdmin Then Return New AdminDashboard()
        Return New UserDashboard()
    End Function

    Private Sub MoveIndicator(active As Button, animate As Boolean)
        If active Is Nothing Then Return
        Dim target As Integer = pnlSide.PointToClient(active.PointToScreen(Point.Empty)).Y
        pnlIndicator.Height = active.Height
        pnlIndicator.BringToFront()
        If animate Then
            Animator.MoveTop(pnlIndicator, target, 200)
        Else
            pnlIndicator.Top = target
        End If
    End Sub

    Private Sub Navigate(active As Button, view As UserControl)
        For Each b In navButtons
            Dim nb = TryCast(b, NavButton)
            If nb IsNot Nothing Then nb.Active = (b Is active)
        Next
        For Each old As Control In pnlContent.Controls.Cast(Of Control).ToList()
            pnlContent.Controls.Remove(old)
            old.Dispose()
        Next
        view.Dock = DockStyle.Fill
        pnlContent.Controls.Add(view)
        activeBtn = active
        If Visible Then
            MoveIndicator(active, True)
            Animator.SlideIn(pnlContent, basePad)
        End If
    End Sub

    Private Sub btnNavDashboard_Click(sender As Object, e As EventArgs) Handles btnNavDashboard.Click
        Navigate(btnNavDashboard, Home())
    End Sub
    Private Sub btnNavStudents_Click(sender As Object, e As EventArgs) Handles btnNavStudents.Click
        Navigate(btnNavStudents, New StudentsScreen())
    End Sub
    Private Sub btnNavPayments_Click(sender As Object, e As EventArgs) Handles btnNavPayments.Click
        Navigate(btnNavPayments, New PaymentsView())
    End Sub
    Private Sub btnNavReports_Click(sender As Object, e As EventArgs) Handles btnNavReports.Click
        Navigate(btnNavReports, New ReportsView())
    End Sub
    Private Sub btnNavAudit_Click(sender As Object, e As EventArgs) Handles btnNavAudit.Click
        Navigate(btnNavAudit, New AuditView())
    End Sub
    Private Sub btnNavUsers_Click(sender As Object, e As EventArgs) Handles btnNavUsers.Click
        Navigate(btnNavUsers, New UsersView())
    End Sub
    Private Sub btnNavFees_Click(sender As Object, e As EventArgs) Handles btnNavFees.Click
        Navigate(btnNavFees, New FeesView())
    End Sub

    Private Sub btnChangePassword_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        Using d As New ChangePasswordForm(False)
            If d.ShowDialog(Me) = DialogResult.OK Then Toast.Notify(Me, "Password changed")
        End Using
    End Sub

    Private Sub btnSignOut_Click(sender As Object, e As EventArgs) Handles btnSignOut.Click
        LoggedOut = True
        Close()
    End Sub

    Private Sub CheckIdle(s As Object, e As EventArgs)
        If (Now - idle.LastActivity).TotalMinutes < 15 Then Return
        tmr.Stop()
        Try
            AuditLogger.LogOnly("SESSION TIMEOUT", Session.UserName, "", "Signed out after 15 minutes of inactivity")
        Catch
        End Try
        LoggedOut = True
        For Each f As Form In Application.OpenForms.Cast(Of Form).ToList()
            If f IsNot Me Then f.Close()
        Next
        Close()
    End Sub

    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        tmr.Stop()
        Application.RemoveMessageFilter(idle)
        Try
            AuditLogger.LogOnly("SIGN-OUT", Session.UserName)
        Catch
        End Try
        Db.AutoBackup()
        Session.Clear()
        MyBase.OnFormClosed(e)
    End Sub
End Class
