Public Class LoginForm

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Helpers.ApplyIcon(Me)
        Animator.FadeIn(Me)
    End Sub

    Private Sub chkShow_CheckedChanged(sender As Object, e As EventArgs) Handles chkShow.CheckedChanged
        txtPass.UseSystemPasswordChar = Not chkShow.Checked
    End Sub

    Private Sub btnSignIn_Click(sender As Object, e As EventArgs) Handles btnSignIn.Click
        Dim u As String = txtUser.Text.Trim()
        If u = "" OrElse txtPass.Text = "" Then
            lblMsg.Text = "Enter your username and password."
            Return
        End If
        Dim dt As DataTable = Db.Query("SELECT * FROM Users WHERE Username = @p0", u)
        If dt.Rows.Count = 0 Then
            AuditLogger.LogOnly("LOGIN FAILED", u, "", "Unknown username", "", u)
            lblMsg.Text = "Wrong username or password."
            Animator.Shake(Me)
            Return
        End If
        Dim r As DataRow = dt.Rows(0)
        Dim id As Integer = Convert.ToInt32(r("Id"))
        If Convert.ToInt32(r("Active")) = 0 Then
            AuditLogger.LogOnly("LOGIN FAILED", u, "", "Account disabled", "", u)
            lblMsg.Text = "This account is disabled. Contact the super admin."
            Return
        End If
        If Convert.ToInt32(r("FailedAttempts")) >= 5 Then
            lblMsg.Text = "Account locked after 5 wrong attempts. Ask the super admin to reset your password."
            Return
        End If
        If Not Security.Verify(txtPass.Text, r("Salt").ToString(), r("PasswordHash").ToString()) Then
            Using tx As New Tx(u)
                tx.Exec("UPDATE Users SET FailedAttempts = FailedAttempts + 1 WHERE Id = @p0", id)
                AuditLogger.Log(tx, "LOGIN FAILED", u, "", "Wrong password")
                tx.Commit()
            End Using
            lblMsg.Text = "Wrong username or password."
            Animator.Shake(Me)
            txtPass.Clear()
            Return
        End If
        Session.UserId = id
        Session.UserName = r("Username").ToString()
        Session.FullName = r("FullName").ToString()
        Session.Role = r("Role").ToString()
        If Convert.ToInt32(r("MustChange")) = 1 Then
            Using cp As New ChangePasswordForm(True)
                If cp.ShowDialog(Me) <> DialogResult.OK Then
                    Session.Clear()
                    lblMsg.Text = "You must set a new password to continue."
                    Return
                End If
            End Using
        End If
        Using tx As New Tx()
            tx.Exec("UPDATE Users SET FailedAttempts = 0, LastLogin = @p0 WHERE Id = @p1", Now.ToString("yyyy-MM-dd HH:mm"), id)
            AuditLogger.Log(tx, "SIGN-IN", Session.UserName, "", "Successful login")
            tx.Commit()
        End Using
        DialogResult = DialogResult.OK
    End Sub
End Class
