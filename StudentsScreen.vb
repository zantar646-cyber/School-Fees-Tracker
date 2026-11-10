' Hosts the students grid with an admin-only "Term rollover" button (built in code)
Public Class StudentsScreen
    Inherits UserControl

    Public Sub New()
        Dock = DockStyle.Fill
        BackColor = Theme.PageBg
        Dim sv As New StudentsView()
        Dim card = Theme.CardPanel()
        card.Controls.Add(sv)
        Dim head As New FlowLayoutPanel With {.Dock = DockStyle.Top, .AutoSize = True, .WrapContents = False}
        head.Controls.Add(New Label With {.Text = "Students", .Font = Theme.TitleFont, .AutoSize = True, .Margin = New Padding(0, 0, Theme.S(24), Theme.S(8))})
        If Session.IsAdmin Then
            Dim bRoll = Theme.Btn("Term rollover...", False, 160)
            bRoll.Margin = New Padding(0, Theme.S(8), 0, 0)
            head.Controls.Add(bRoll)
            AddHandler bRoll.Click, Sub()
                                        Using d As New RolloverDialog()
                                            If d.ShowDialog(FindForm()) = DialogResult.OK Then sv.Reload()
                                        End Using
                                    End Sub
        End If
        Controls.Add(card)
        Controls.Add(head)
    End Sub
End Class
