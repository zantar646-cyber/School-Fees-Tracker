<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
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
        Me.pnlForm = New System.Windows.Forms.Panel()
        Me.tlpBody = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSub = New System.Windows.Forms.Label()
        Me.lblUserCaption = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.lblPassCaption = New System.Windows.Forms.Label()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.chkShow = New System.Windows.Forms.CheckBox()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.btnSignIn = New RoundButton()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.pnlBrand = New System.Windows.Forms.Panel()
        Me.lblBrandMark = New System.Windows.Forms.Label()
        Me.lblBrandName = New System.Windows.Forms.Label()
        Me.lblBrandTag = New System.Windows.Forms.Label()
        Me.lblBrandFoot = New System.Windows.Forms.Label()
        Me.pnlForm.SuspendLayout()
        Me.tlpBody.SuspendLayout()
        Me.pnlBrand.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Text = "Welcome back"
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.TabIndex = 0
        '
        'lblSub
        '
        Me.lblSub.AutoSize = True
        Me.lblSub.Text = "Sign in to continue"
        Me.lblSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblSub.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSub.Margin = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.lblSub.Name = "lblSub"
        Me.lblSub.TabIndex = 1
        '
        'lblUserCaption
        '
        Me.lblUserCaption.AutoSize = True
        Me.lblUserCaption.Text = "Username"
        Me.lblUserCaption.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblUserCaption.Margin = New System.Windows.Forms.Padding(0, 26, 0, 3)
        Me.lblUserCaption.Name = "lblUserCaption"
        Me.lblUserCaption.TabIndex = 2
        '
        'txtUser
        '
        Me.txtUser.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUser.Size = New System.Drawing.Size(340, 29)
        Me.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUser.Name = "txtUser"
        Me.txtUser.TabIndex = 3
        '
        'lblPassCaption
        '
        Me.lblPassCaption.AutoSize = True
        Me.lblPassCaption.Text = "Password"
        Me.lblPassCaption.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPassCaption.Margin = New System.Windows.Forms.Padding(0, 14, 0, 3)
        Me.lblPassCaption.Name = "lblPassCaption"
        Me.lblPassCaption.TabIndex = 4
        '
        'txtPass
        '
        Me.txtPass.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPass.Size = New System.Drawing.Size(340, 29)
        Me.txtPass.UseSystemPasswordChar = True
        Me.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPass.Name = "txtPass"
        Me.txtPass.TabIndex = 5
        '
        'chkShow
        '
        Me.chkShow.AutoSize = True
        Me.chkShow.Text = "Show password"
        Me.chkShow.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.chkShow.Margin = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.chkShow.UseVisualStyleBackColor = True
        Me.chkShow.Name = "chkShow"
        Me.chkShow.TabIndex = 6
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = True
        Me.lblMsg.Text = ""
        Me.lblMsg.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.lblMsg.MaximumSize = New System.Drawing.Size(340, 0)
        Me.lblMsg.Margin = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.TabIndex = 7
        '
        'btnSignIn
        '
        Me.btnSignIn.BackColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnSignIn.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnSignIn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSignIn.Margin = New System.Windows.Forms.Padding(0, 14, 0, 0)
        Me.btnSignIn.Size = New System.Drawing.Size(340, 48)
        Me.btnSignIn.Text = "Sign in"
        Me.btnSignIn.UseVisualStyleBackColor = False
        Me.btnSignIn.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSignIn.AutoSize = True
        Me.btnSignIn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnSignIn.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnSignIn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnSignIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(67, 56, 202)
        Me.btnSignIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(55, 48, 163)
        Me.btnSignIn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSignIn.Name = "btnSignIn"
        Me.btnSignIn.TabIndex = 8
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Text = "Your role is set by your account. Contact the super admin if you cannot sign in."
        Me.lblNote.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNote.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblNote.MaximumSize = New System.Drawing.Size(340, 0)
        Me.lblNote.Margin = New System.Windows.Forms.Padding(0, 18, 0, 0)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.TabIndex = 9
        '
        'tlpBody
        '
        Me.tlpBody.ColumnCount = 1
        Me.tlpBody.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpBody.RowCount = 10
        Me.tlpBody.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpBody.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpBody.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpBody.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpBody.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpBody.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpBody.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpBody.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpBody.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpBody.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpBody.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpBody.AutoSize = True
        Me.tlpBody.Name = "tlpBody"
        Me.tlpBody.TabIndex = 10
        Me.tlpBody.Controls.Add(Me.lblTitle, 0, 0)
        Me.tlpBody.Controls.Add(Me.lblSub, 0, 1)
        Me.tlpBody.Controls.Add(Me.lblUserCaption, 0, 2)
        Me.tlpBody.Controls.Add(Me.txtUser, 0, 3)
        Me.tlpBody.Controls.Add(Me.lblPassCaption, 0, 4)
        Me.tlpBody.Controls.Add(Me.txtPass, 0, 5)
        Me.tlpBody.Controls.Add(Me.chkShow, 0, 6)
        Me.tlpBody.Controls.Add(Me.lblMsg, 0, 7)
        Me.tlpBody.Controls.Add(Me.btnSignIn, 0, 8)
        Me.tlpBody.Controls.Add(Me.lblNote, 0, 9)
        '
        'pnlForm
        '
        Me.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlForm.Padding = New System.Windows.Forms.Padding(52, 44, 52, 24)
        Me.pnlForm.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.pnlForm.Name = "pnlForm"
        Me.pnlForm.TabIndex = 11
        Me.pnlForm.Controls.Add(Me.tlpBody)
        '
        'lblBrandMark
        '
        Me.lblBrandMark.AutoSize = False
        Me.lblBrandMark.Text = "₵"
        Me.lblBrandMark.Location = New System.Drawing.Point(48, 64)
        Me.lblBrandMark.Size = New System.Drawing.Size(64, 64)
        Me.lblBrandMark.BackColor = System.Drawing.Color.FromArgb(129, 140, 248)
        Me.lblBrandMark.ForeColor = System.Drawing.Color.FromArgb(33, 28, 73)
        Me.lblBrandMark.Font = New System.Drawing.Font("Segoe UI", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrandMark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblBrandMark.AutoEllipsis = True
        Me.lblBrandMark.Name = "lblBrandMark"
        Me.lblBrandMark.TabIndex = 12
        '
        'lblBrandName
        '
        Me.lblBrandName.AutoSize = False
        Me.lblBrandName.Text = "School Fees Tracker"
        Me.lblBrandName.Location = New System.Drawing.Point(48, 152)
        Me.lblBrandName.Size = New System.Drawing.Size(260, 100)
        Me.lblBrandName.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.lblBrandName.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrandName.AutoEllipsis = True
        Me.lblBrandName.Name = "lblBrandName"
        Me.lblBrandName.TabIndex = 13
        '
        'lblBrandTag
        '
        Me.lblBrandTag.AutoSize = False
        Me.lblBrandTag.Text = "Simple, accurate fee records for Ghanaian JHS schools."
        Me.lblBrandTag.Location = New System.Drawing.Point(48, 264)
        Me.lblBrandTag.Size = New System.Drawing.Size(250, 72)
        Me.lblBrandTag.ForeColor = System.Drawing.Color.FromArgb(199, 210, 254)
        Me.lblBrandTag.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrandTag.AutoEllipsis = True
        Me.lblBrandTag.Name = "lblBrandTag"
        Me.lblBrandTag.TabIndex = 14
        '
        'lblBrandFoot
        '
        Me.lblBrandFoot.AutoSize = False
        Me.lblBrandFoot.Text = "Every sign-in and every change is recorded in the audit log."
        Me.lblBrandFoot.Location = New System.Drawing.Point(48, 432)
        Me.lblBrandFoot.Size = New System.Drawing.Size(250, 48)
        Me.lblBrandFoot.ForeColor = System.Drawing.Color.FromArgb(129, 140, 248)
        Me.lblBrandFoot.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrandFoot.AutoEllipsis = True
        Me.lblBrandFoot.Name = "lblBrandFoot"
        Me.lblBrandFoot.TabIndex = 15
        '
        'pnlBrand
        '
        Me.pnlBrand.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBrand.Size = New System.Drawing.Size(340, 520)
        Me.pnlBrand.BackColor = System.Drawing.Color.FromArgb(33, 28, 73)
        Me.pnlBrand.Name = "pnlBrand"
        Me.pnlBrand.TabIndex = 16
        Me.pnlBrand.Controls.Add(Me.lblBrandMark)
        Me.pnlBrand.Controls.Add(Me.lblBrandName)
        Me.pnlBrand.Controls.Add(Me.lblBrandTag)
        Me.pnlBrand.Controls.Add(Me.lblBrandFoot)
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96!, 96!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(800, 520)
        Me.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JHS School Fees Payment Tracker"
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AcceptButton = Me.btnSignIn
        Me.Controls.Add(Me.pnlForm)
        Me.Controls.Add(Me.pnlBrand)
        Me.ActiveControl = Me.txtUser
        Me.Name = "LoginForm"
        Me.pnlBrand.ResumeLayout(False)
        Me.tlpBody.ResumeLayout(False)
        Me.tlpBody.PerformLayout()
        Me.pnlForm.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlForm As System.Windows.Forms.Panel
    Friend WithEvents tlpBody As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblSub As System.Windows.Forms.Label
    Friend WithEvents lblUserCaption As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents lblPassCaption As System.Windows.Forms.Label
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents chkShow As System.Windows.Forms.CheckBox
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents btnSignIn As RoundButton
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents pnlBrand As System.Windows.Forms.Panel
    Friend WithEvents lblBrandMark As System.Windows.Forms.Label
    Friend WithEvents lblBrandName As System.Windows.Forms.Label
    Friend WithEvents lblBrandTag As System.Windows.Forms.Label
    Friend WithEvents lblBrandFoot As System.Windows.Forms.Label

End Class
