Public Class UserDialog

    Public Sub New()
        InitializeComponent()
        Theme.Polish(Me)
        Animator.FadeIn(Me)
        cboRole.SelectedIndex = 0
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim name = txtName.Text.Trim(), user = txtUser.Text.Trim()
        If name = "" OrElse user = "" Then lblMsg.Text = "Enter the full name and a username." : Return
        If Not System.Text.RegularExpressions.Regex.IsMatch(user, "^[A-Za-z0-9._-]{3,30}$") Then lblMsg.Text = "Username: 3 to 30 letters, digits, . _ -" : Return
        Dim pwProblem As String = Security.PasswordProblem(txtPass.Text)
        If pwProblem <> "" Then lblMsg.Text = pwProblem : Return
        If Convert.ToInt32(Db.Scalar("SELECT COUNT(*) FROM Users WHERE Username = @p0", user)) > 0 Then lblMsg.Text = "That username is already taken." : Return
        Dim salt = Security.NewSalt()
        Using tx As New Tx()
            tx.Exec("INSERT INTO Users(FullName, Username, PasswordHash, Salt, Role, MustChange) VALUES (@p0, @p1, @p2, @p3, @p4, 1)",
                    name, user, Security.HashPassword(txtPass.Text, salt), salt, cboRole.SelectedItem.ToString())
            AuditLogger.Log(tx, "ADD USER", user, "", name & ", role " & cboRole.SelectedItem.ToString())
            tx.Commit()
        End Using
        DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub
End Class
