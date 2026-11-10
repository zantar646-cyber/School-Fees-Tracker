Public Class ReasonDialog
    Private minLen As Integer = 1

    Public ReadOnly Property Value As String
        Get
            Return txtValue.Text.Trim()
        End Get
    End Property

    Public Sub New()
        InitializeComponent()
        Theme.Polish(Me)
        Animator.FadeIn(Me)
    End Sub

    ' Used for delete / void reasons and password resets
    Public Sub New(title As String, message As String, fieldLabel As String, okText As String, Optional danger As Boolean = False, Optional isPassword As Boolean = False, Optional minLength As Integer = 1)
        Me.New()
        Text = title
        lblHeader.Text = title
        lblSubHeader.Text = "This action is recorded in the audit log."
        lblMessage.Text = message
        lblMessage.ForeColor = If(danger, Theme.Danger, Theme.Muted)
        lblField.Text = fieldLabel
        btnOk.Text = okText
        txtValue.UseSystemPasswordChar = isPassword
        minLen = minLength
        If danger Then
            pnlHeader.BackColor = Theme.Danger
            btnOk.BackColor = Theme.Danger
            btnOk.FlatAppearance.BorderColor = Theme.Danger
        End If
    End Sub

    Private Sub txtValue_TextChanged(sender As Object, e As EventArgs) Handles txtValue.TextChanged
        btnOk.Enabled = txtValue.Text.Trim().Length >= minLen
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        DialogResult = DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub
End Class
