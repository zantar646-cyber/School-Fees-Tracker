Public Class ChangePasswordForm

    Public Sub New()
        InitializeComponent()
        Theme.Polish(Me)
        Animator.FadeIn(Me)
        txtNew.UseSystemPasswordChar = True
        txtConfirm.UseSystemPasswordChar = True
        lblInfo.Text = "Choose a new password (at least 8 characters, with a letter and a number)."
    End Sub

    Public Sub New(forced As Boolean)
        Me.New()
        If forced Then lblInfo.Text = "You are using a temporary password. Choose your own (at least 8 characters, with a letter and a number)."
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim pwProblem As String = Security.PasswordProblem(txtNew.Text)
        If pwProblem <> "" Then lblMsg.Text = pwProblem : Return
        If txtNew.Text <> txtConfirm.Text Then lblMsg.Text = "The two passwords do not match." : Return
        Dim salt = Security.NewSalt()
        Using tx As New Tx()
            tx.Exec("UPDATE Users SET PasswordHash = @p0, Salt = @p1, MustChange = 0 WHERE Id = @p2", Security.HashPassword(txtNew.Text, salt), salt, Session.UserId)
            AuditLogger.Log(tx, "CHANGE PASSWORD", Session.UserName, "", "Password changed by the user")
            tx.Commit()
        End Using
        DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub
End Class
