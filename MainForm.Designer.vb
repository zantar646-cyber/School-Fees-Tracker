<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer. Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlContent = New BufferedPanel()
        Me.pnlSide = New System.Windows.Forms.Panel()
        Me.pnlBrand = New System.Windows.Forms.Panel()
        Me.logoMark = New LogoMark()
        Me.lblBrand = New System.Windows.Forms.Label()
        Me.lblBrandSub = New System.Windows.Forms.Label()
        Me.flowNav = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblMenu = New System.Windows.Forms.Label()
        Me.lblAdmin = New System.Windows.Forms.Label()
        Me.btnNavDashboard = New NavButton()
        Me.btnNavStudents = New NavButton()
        Me.btnNavPayments = New NavButton()
        Me.btnNavReports = New NavButton()
        Me.btnNavAudit = New NavButton()
        Me.btnNavUsers = New NavButton()
        Me.btnNavFees = New NavButton()
        Me.pnlDivider = New System.Windows.Forms.Panel()
        Me.pnlUser = New System.Windows.Forms.Panel()
        Me.avatar = New AvatarBadge()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lblRole = New System.Windows.Forms.Label()
        Me.btnSignOut = New RoundButton()
        Me.btnChangePassword = New RoundButton()
        Me.pnlIndicator = New System.Windows.Forms.Panel()
        Me.pnlSide.SuspendLayout()
        Me.pnlBrand.SuspendLayout()
        Me.flowNav.SuspendLayout()
        Me.pnlUser.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContent
        '
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(24, 20, 20, 12)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.TabIndex = 0
        '
        'logoMark
        '
        Me.logoMark.Location = New System.Drawing.Point(16, 18)
        Me.logoMark.Size = New System.Drawing.Size(36, 36)
        Me.logoMark.Name = "logoMark"
        Me.logoMark.TabIndex = 0
        '
        'lblBrand
        '
        Me.lblBrand.AutoSize = False
        Me.lblBrand.Text = "School Fees"
        Me.lblBrand.Location = New System.Drawing.Point(62, 18)
        Me.lblBrand.Size = New System.Drawing.Size(138, 20)
        Me.lblBrand.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.lblBrand.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBrand.AutoEllipsis = True
        Me.lblBrand.Name = "lblBrand"
        Me.lblBrand.TabIndex = 1
        '
        'lblBrandSub
        '
        Me.lblBrandSub.AutoSize = False
        Me.lblBrandSub.Text = "Payment Tracker"
        Me.lblBrandSub.Location = New System.Drawing.Point(62, 38)
        Me.lblBrandSub.Size = New System.Drawing.Size(138, 17)
        Me.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(165, 160, 214)
        Me.lblBrandSub.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrandSub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBrandSub.AutoEllipsis = True
        Me.lblBrandSub.Name = "lblBrandSub"
        Me.lblBrandSub.TabIndex = 2
        '
        'pnlBrand
        '
        Me.pnlBrand.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBrand.Size = New System.Drawing.Size(208, 72)
        Me.pnlBrand.BackColor = System.Drawing.Color.FromArgb(33, 28, 73)
        Me.pnlBrand.Name = "pnlBrand"
        Me.pnlBrand.TabIndex = 3
        Me.pnlBrand.Controls.Add(Me.logoMark)
        Me.pnlBrand.Controls.Add(Me.lblBrand)
        Me.pnlBrand.Controls.Add(Me.lblBrandSub)
        '
        'lblMenu
        '
        Me.lblMenu.AutoSize = False
        Me.lblMenu.Text = "MENU"
        Me.lblMenu.Size = New System.Drawing.Size(184, 24)
        Me.lblMenu.ForeColor = System.Drawing.Color.FromArgb(136, 131, 190)
        Me.lblMenu.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMenu.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblMenu.Padding = New System.Windows.Forms.Padding(14, 0, 0, 4)
        Me.lblMenu.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.lblMenu.Name = "lblMenu"
        Me.lblMenu.TabIndex = 4
        '
        'lblAdmin
        '
        Me.lblAdmin.AutoSize = False
        Me.lblAdmin.Text = "ADMINISTRATION"
        Me.lblAdmin.Size = New System.Drawing.Size(184, 34)
        Me.lblAdmin.ForeColor = System.Drawing.Color.FromArgb(136, 131, 190)
        Me.lblAdmin.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdmin.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblAdmin.Padding = New System.Windows.Forms.Padding(14, 0, 0, 4)
        Me.lblAdmin.Margin = New System.Windows.Forms.Padding(0, 0, 0, 2)
        Me.lblAdmin.Name = "lblAdmin"
        Me.lblAdmin.TabIndex = 5
        '
        'btnNavDashboard
        '
        Me.btnNavDashboard.Size = New System.Drawing.Size(184, 42)
        Me.btnNavDashboard.Text = "Dashboard"
        Me.btnNavDashboard.IconName = "dashboard"
        Me.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavDashboard.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavDashboard.ForeColor = System.Drawing.Color.FromArgb(203, 200, 236)
        Me.btnNavDashboard.BackColor = System.Drawing.Color.FromArgb(33, 28, 73)
        Me.btnNavDashboard.Margin = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNavDashboard.UseVisualStyleBackColor = False
        Me.btnNavDashboard.FlatAppearance.BorderSize = 0
        Me.btnNavDashboard.Name = "btnNavDashboard"
        Me.btnNavDashboard.TabIndex = 6
        '
        'btnNavStudents
        '
        Me.btnNavStudents.Size = New System.Drawing.Size(184, 42)
        Me.btnNavStudents.Text = "Students"
        Me.btnNavStudents.IconName = "students"
        Me.btnNavStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavStudents.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavStudents.ForeColor = System.Drawing.Color.FromArgb(203, 200, 236)
        Me.btnNavStudents.BackColor = System.Drawing.Color.FromArgb(33, 28, 73)
        Me.btnNavStudents.Margin = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.btnNavStudents.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNavStudents.UseVisualStyleBackColor = False
        Me.btnNavStudents.FlatAppearance.BorderSize = 0
        Me.btnNavStudents.Name = "btnNavStudents"
        Me.btnNavStudents.TabIndex = 7
        '
        'btnNavPayments
        '
        Me.btnNavPayments.Size = New System.Drawing.Size(184, 42)
        Me.btnNavPayments.Text = "Payments"
        Me.btnNavPayments.IconName = "payments"
        Me.btnNavPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavPayments.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavPayments.ForeColor = System.Drawing.Color.FromArgb(203, 200, 236)
        Me.btnNavPayments.BackColor = System.Drawing.Color.FromArgb(33, 28, 73)
        Me.btnNavPayments.Margin = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.btnNavPayments.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNavPayments.UseVisualStyleBackColor = False
        Me.btnNavPayments.FlatAppearance.BorderSize = 0
        Me.btnNavPayments.Name = "btnNavPayments"
        Me.btnNavPayments.TabIndex = 8
        '
        'btnNavReports
        '
        Me.btnNavReports.Size = New System.Drawing.Size(184, 42)
        Me.btnNavReports.Text = "Reports"
        Me.btnNavReports.IconName = "reports"
        Me.btnNavReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavReports.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavReports.ForeColor = System.Drawing.Color.FromArgb(203, 200, 236)
        Me.btnNavReports.BackColor = System.Drawing.Color.FromArgb(33, 28, 73)
        Me.btnNavReports.Margin = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.btnNavReports.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNavReports.UseVisualStyleBackColor = False
        Me.btnNavReports.FlatAppearance.BorderSize = 0
        Me.btnNavReports.Name = "btnNavReports"
        Me.btnNavReports.TabIndex = 9
        '
        'btnNavAudit
        '
        Me.btnNavAudit.Size = New System.Drawing.Size(184, 42)
        Me.btnNavAudit.Text = "Audit log"
        Me.btnNavAudit.IconName = "audit"
        Me.btnNavAudit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavAudit.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavAudit.ForeColor = System.Drawing.Color.FromArgb(203, 200, 236)
        Me.btnNavAudit.BackColor = System.Drawing.Color.FromArgb(33, 28, 73)
        Me.btnNavAudit.Margin = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.btnNavAudit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNavAudit.UseVisualStyleBackColor = False
        Me.btnNavAudit.FlatAppearance.BorderSize = 0
        Me.btnNavAudit.Name = "btnNavAudit"
        Me.btnNavAudit.TabIndex = 10
        '
        'btnNavUsers
        '
        Me.btnNavUsers.Size = New System.Drawing.Size(184, 42)
        Me.btnNavUsers.Text = "Users"
        Me.btnNavUsers.IconName = "users"
        Me.btnNavUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavUsers.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavUsers.ForeColor = System.Drawing.Color.FromArgb(203, 200, 236)
        Me.btnNavUsers.BackColor = System.Drawing.Color.FromArgb(33, 28, 73)
        Me.btnNavUsers.Margin = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.btnNavUsers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNavUsers.UseVisualStyleBackColor = False
        Me.btnNavUsers.FlatAppearance.BorderSize = 0
        Me.btnNavUsers.Name = "btnNavUsers"
        Me.btnNavUsers.TabIndex = 11
        '
        'btnNavFees
        '
        Me.btnNavFees.Size = New System.Drawing.Size(184, 42)
        Me.btnNavFees.Text = "Fee settings"
        Me.btnNavFees.IconName = "fees"
        Me.btnNavFees.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavFees.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavFees.ForeColor = System.Drawing.Color.FromArgb(203, 200, 236)
        Me.btnNavFees.BackColor = System.Drawing.Color.FromArgb(33, 28, 73)
        Me.btnNavFees.Margin = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.btnNavFees.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNavFees.UseVisualStyleBackColor = False
        Me.btnNavFees.FlatAppearance.BorderSize = 0
        Me.btnNavFees.Name = "btnNavFees"
        Me.btnNavFees.TabIndex = 12
        '
        'flowNav
        '
        Me.flowNav.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowNav.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flowNav.WrapContents = False
        Me.flowNav.Padding = New System.Windows.Forms.Padding(12, 4, 12, 0)
        Me.flowNav.BackColor = System.Drawing.Color.FromArgb(33, 28, 73)
        Me.flowNav.Name = "flowNav"
        Me.flowNav.TabIndex = 13
        Me.flowNav.Controls.Add(Me.lblMenu)
        Me.flowNav.Controls.Add(Me.btnNavDashboard)
        Me.flowNav.Controls.Add(Me.btnNavStudents)
        Me.flowNav.Controls.Add(Me.btnNavPayments)
        Me.flowNav.Controls.Add(Me.btnNavReports)
        Me.flowNav.Controls.Add(Me.lblAdmin)
        Me.flowNav.Controls.Add(Me.btnNavAudit)
        Me.flowNav.Controls.Add(Me.btnNavUsers)
        Me.flowNav.Controls.Add(Me.btnNavFees)
        '
        'pnlDivider
        '
        Me.pnlDivider.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDivider.Size = New System.Drawing.Size(208, 1)
        Me.pnlDivider.BackColor = System.Drawing.Color.FromArgb(52, 47, 108)
        Me.pnlDivider.Name = "pnlDivider"
        Me.pnlDivider.TabIndex = 14
        '
        'avatar
        '
        Me.avatar.Location = New System.Drawing.Point(16, 16)
        Me.avatar.Size = New System.Drawing.Size(36, 36)
        Me.avatar.Name = "avatar"
        Me.avatar.TabIndex = 0
        '
        'lblUser
        '
        Me.lblUser.AutoSize = False
        Me.lblUser.Text = "User"
        Me.lblUser.Location = New System.Drawing.Point(60, 15)
        Me.lblUser.Size = New System.Drawing.Size(134, 20)
        Me.lblUser.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.lblUser.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblUser.AutoEllipsis = True
        Me.lblUser.Name = "lblUser"
        Me.lblUser.TabIndex = 1
        '
        'lblRole
        '
        Me.lblRole.AutoSize = False
        Me.lblRole.Text = ""
        Me.lblRole.Location = New System.Drawing.Point(60, 35)
        Me.lblRole.Size = New System.Drawing.Size(134, 18)
        Me.lblRole.ForeColor = System.Drawing.Color.FromArgb(165, 160, 214)
        Me.lblRole.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRole.AutoEllipsis = True
        Me.lblRole.Name = "lblRole"
        Me.lblRole.TabIndex = 2
        '
        'btnSignOut
        '
        Me.btnSignOut.BackColor = System.Drawing.Color.FromArgb(33, 28, 73)
        Me.btnSignOut.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.btnSignOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSignOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSignOut.Location = New System.Drawing.Point(16, 66)
        Me.btnSignOut.Size = New System.Drawing.Size(176, 34)
        Me.btnSignOut.Text = "Sign out"
        Me.btnSignOut.UseVisualStyleBackColor = False
        Me.btnSignOut.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSignOut.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(76, 70, 138)
        Me.btnSignOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(43, 37, 98)
        Me.btnSignOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(49, 43, 128)
        Me.btnSignOut.Name = "btnSignOut"
        Me.btnSignOut.TabIndex = 3
        '
        'btnChangePassword
        '
        Me.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(33, 28, 73)
        Me.btnChangePassword.ForeColor = System.Drawing.Color.FromArgb(165, 160, 214)
        Me.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangePassword.Location = New System.Drawing.Point(16, 104)
        Me.btnChangePassword.Size = New System.Drawing.Size(176, 28)
        Me.btnChangePassword.Text = "Change password"
        Me.btnChangePassword.UseVisualStyleBackColor = False
        Me.btnChangePassword.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangePassword.FlatAppearance.BorderSize = 0
        Me.btnChangePassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(43, 37, 98)
        Me.btnChangePassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(49, 43, 128)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.TabIndex = 4
        '
        'pnlUser
        '
        Me.pnlUser.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlUser.Size = New System.Drawing.Size(208, 142)
        Me.pnlUser.BackColor = System.Drawing.Color.FromArgb(33, 28, 73)
        Me.pnlUser.Name = "pnlUser"
        Me.pnlUser.TabIndex = 15
        Me.pnlUser.Controls.Add(Me.avatar)
        Me.pnlUser.Controls.Add(Me.lblUser)
        Me.pnlUser.Controls.Add(Me.lblRole)
        Me.pnlUser.Controls.Add(Me.btnSignOut)
        Me.pnlUser.Controls.Add(Me.btnChangePassword)
        '
        'pnlIndicator
        '
        Me.pnlIndicator.Size = New System.Drawing.Size(3, 42)
        Me.pnlIndicator.Location = New System.Drawing.Point(0, 110)
        Me.pnlIndicator.BackColor = System.Drawing.Color.FromArgb(129, 140, 248)
        Me.pnlIndicator.Name = "pnlIndicator"
        Me.pnlIndicator.TabIndex = 16
        '
        'pnlSide
        '
        Me.pnlSide.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSide.Size = New System.Drawing.Size(208, 780)
        Me.pnlSide.BackColor = System.Drawing.Color.FromArgb(33, 28, 73)
        Me.pnlSide.Name = "pnlSide"
        Me.pnlSide.TabIndex = 17
        Me.pnlSide.Controls.Add(Me.flowNav)
        Me.pnlSide.Controls.Add(Me.pnlDivider)
        Me.pnlSide.Controls.Add(Me.pnlUser)
        Me.pnlSide.Controls.Add(Me.pnlBrand)
        Me.pnlSide.Controls.Add(Me.pnlIndicator)
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96!, 96!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(1280, 780)
        Me.MinimumSize = New System.Drawing.Size(1000, 640)
        Me.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JHS School Fees Payment Tracker"
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlSide)
        Me.Name = "MainForm"
        Me.pnlUser.ResumeLayout(False)
        Me.flowNav.ResumeLayout(False)
        Me.pnlBrand.ResumeLayout(False)
        Me.pnlSide.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlContent As BufferedPanel
    Friend WithEvents pnlSide As System.Windows.Forms.Panel
    Friend WithEvents pnlBrand As System.Windows.Forms.Panel
    Friend WithEvents logoMark As LogoMark
    Friend WithEvents lblBrand As System.Windows.Forms.Label
    Friend WithEvents lblBrandSub As System.Windows.Forms.Label
    Friend WithEvents flowNav As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblMenu As System.Windows.Forms.Label
    Friend WithEvents lblAdmin As System.Windows.Forms.Label
    Friend WithEvents btnNavDashboard As NavButton
    Friend WithEvents btnNavStudents As NavButton
    Friend WithEvents btnNavPayments As NavButton
    Friend WithEvents btnNavReports As NavButton
    Friend WithEvents btnNavAudit As NavButton
    Friend WithEvents btnNavUsers As NavButton
    Friend WithEvents btnNavFees As NavButton
    Friend WithEvents pnlDivider As System.Windows.Forms.Panel
    Friend WithEvents pnlUser As System.Windows.Forms.Panel
    Friend WithEvents avatar As AvatarBadge
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblRole As System.Windows.Forms.Label
    Friend WithEvents btnChangePassword As RoundButton
    Friend WithEvents btnSignOut As RoundButton
    Friend WithEvents pnlIndicator As System.Windows.Forms.Panel

End Class
