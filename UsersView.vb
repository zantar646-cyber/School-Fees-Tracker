Public Class UsersView

    Public Sub New()
        InitializeComponent()
        Theme.Polish(Me)
        Theme.StyleGrid(dgv)
    End Sub

    Private Sub UsersView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If DesignMode Then Return
        lblNote.Text = "Users are disabled, never deleted. Five wrong passwords lock an account until you reset it."
        Reload()
    End Sub

    Private Sub Reload()
        dgv.DataSource = Db.Query("SELECT Id, FullName AS Name, Username, Role, CASE WHEN Active = 1 THEN 'Active' ELSE 'Disabled' END AS Status, IFNULL(LastLogin, 'never') AS LastSignIn, FailedAttempts AS FailedLogins FROM Users ORDER BY Id")
        dgv.Columns("Id").FillWeight = 30
        Theme.FitColumns(dgv)
    End Sub

    Private Function Selected() As DataGridViewRow
        If dgv.CurrentRow Is Nothing Then MessageBox.Show("Select a user first.")
        Return dgv.CurrentRow
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Using d As New UserDialog()
            If d.ShowDialog(FindForm()) = DialogResult.OK Then Reload()
        End Using
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim r = Selected() : If r Is Nothing Then Return
        Dim id = Convert.ToInt32(r.Cells("Id").Value), un = r.Cells("Username").Value.ToString()
        Using d As New ReasonDialog("Reset password", "Set a temporary password for " & un & ". They must choose their own at next sign-in.", "Temporary password (8+ characters, a letter and a number)", "Reset password", False, True, 8)
            If d.ShowDialog(FindForm()) <> DialogResult.OK Then Return
            Dim pwProblem As String = Security.PasswordProblem(d.Value)
            If pwProblem <> "" Then MessageBox.Show(pwProblem, "Password not accepted") : Return
            Dim salt = Security.NewSalt()
            Using tx As New Tx()
                tx.Exec("UPDATE Users SET PasswordHash = @p0, Salt = @p1, MustChange = 1, FailedAttempts = 0 WHERE Id = @p2", Security.HashPassword(d.Value, salt), salt, id)
                AuditLogger.Log(tx, "RESET PASSWORD", un, "", "Temporary password set; failed attempts cleared")
                tx.Commit()
            End Using
        End Using
        Reload()
    End Sub

    Private Sub btnToggle_Click(sender As Object, e As EventArgs) Handles btnToggle.Click
        Dim r = Selected() : If r Is Nothing Then Return
        Dim id = Convert.ToInt32(r.Cells("Id").Value), un = r.Cells("Username").Value.ToString()
        Dim active As Boolean = r.Cells("Status").Value.ToString() = "Active"
        If id = Session.UserId Then MessageBox.Show("You cannot disable your own account.") : Return
        If active AndAlso r.Cells("Role").Value.ToString() = "Super admin" AndAlso Convert.ToInt32(Db.Scalar("SELECT COUNT(*) FROM Users WHERE Role = 'Super admin' AND Active = 1")) <= 1 Then
            MessageBox.Show("At least one active super admin is required.") : Return
        End If
        If MessageBox.Show(If(active, "Disable ", "Enable ") & un & "?", "Confirm", MessageBoxButtons.YesNo) <> DialogResult.Yes Then Return
        Using tx As New Tx()
            tx.Exec("UPDATE Users SET Active = @p0 WHERE Id = @p1", If(active, 0, 1), id)
            AuditLogger.Log(tx, If(active, "DISABLE USER", "ENABLE USER"), un, If(active, "Active", "Disabled"), If(active, "Disabled", "Active"))
            tx.Commit()
        End Using
        Reload()
    End Sub
End Class
