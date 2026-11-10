' The "Record payment" window. It hosts the payment panel that lives on UserDashboard, so every
' calculation, validation and handler stays exactly where it was; this form only presents it.
Public Class PaymentModal
    Inherits Form

    Public Sub New(content As Control)
        Text = "Record payment"
        Font = Theme.BaseFont
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        BackColor = Color.White
        ClientSize = New Size(Theme.S(500), Theme.S(640))
        Padding = New Padding(Theme.S(28), Theme.S(24), Theme.S(28), Theme.S(20))
        content.Dock = DockStyle.Fill
        content.Visible = True
        Controls.Add(content)
        Helpers.ApplyIcon(Me)
    End Sub
End Class
