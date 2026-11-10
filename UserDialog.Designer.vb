<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserDialog
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
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.tlpFields = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNameCap = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblUserCap = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.lblRoleCap = New System.Windows.Forms.Label()
        Me.cboRole = New System.Windows.Forms.ComboBox()
        Me.lblPassCap = New System.Windows.Forms.Label()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.flowButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnCreate = New RoundButton()
        Me.btnCancel = New RoundButton()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblSubHeader = New System.Windows.Forms.Label()
        Me.pnlBody.SuspendLayout()
        Me.tlpFields.SuspendLayout()
        Me.flowButtons.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = False
        Me.lblMsg.Text = ""
        Me.lblMsg.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblMsg.Size = New System.Drawing.Size(440, 36)
        Me.lblMsg.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.lblMsg.AutoEllipsis = True
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.TabIndex = 0
        '
        'lblNote
        '
        Me.lblNote.AutoSize = False
        Me.lblNote.Text = "The user must choose their own password at first sign-in."
        Me.lblNote.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblNote.Size = New System.Drawing.Size(432, 40)
        Me.lblNote.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblNote.AutoEllipsis = True
        Me.lblNote.Name = "lblNote"
        Me.lblNote.TabIndex = 1
        '
        'lblNameCap
        '
        Me.lblNameCap.AutoSize = True
        Me.lblNameCap.Text = "Full name"
        Me.lblNameCap.Margin = New System.Windows.Forms.Padding(0, 8, 14, 0)
        Me.lblNameCap.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblNameCap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNameCap.Name = "lblNameCap"
        Me.lblNameCap.TabIndex = 2
        '
        'txtName
        '
        Me.txtName.Size = New System.Drawing.Size(260, 27)
        Me.txtName.Margin = New System.Windows.Forms.Padding(2, 3, 8, 3)
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtName.Name = "txtName"
        Me.txtName.TabIndex = 3
        '
        'lblUserCap
        '
        Me.lblUserCap.AutoSize = True
        Me.lblUserCap.Text = "Username"
        Me.lblUserCap.Margin = New System.Windows.Forms.Padding(0, 8, 14, 0)
        Me.lblUserCap.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblUserCap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblUserCap.Name = "lblUserCap"
        Me.lblUserCap.TabIndex = 4
        '
        'txtUser
        '
        Me.txtUser.Size = New System.Drawing.Size(260, 27)
        Me.txtUser.Margin = New System.Windows.Forms.Padding(2, 3, 8, 3)
        Me.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUser.Name = "txtUser"
        Me.txtUser.TabIndex = 5
        '
        'lblRoleCap
        '
        Me.lblRoleCap.AutoSize = True
        Me.lblRoleCap.Text = "Role"
        Me.lblRoleCap.Margin = New System.Windows.Forms.Padding(0, 8, 14, 0)
        Me.lblRoleCap.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblRoleCap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRoleCap.Name = "lblRoleCap"
        Me.lblRoleCap.TabIndex = 6
        '
        'cboRole
        '
        Me.cboRole.Size = New System.Drawing.Size(260, 27)
        Me.cboRole.Margin = New System.Windows.Forms.Padding(2, 3, 8, 3)
        Me.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboRole.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.cboRole.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboRole.Items.AddRange(New Object() {"General user", "Super admin"})
        Me.cboRole.Name = "cboRole"
        Me.cboRole.TabIndex = 7
        '
        'lblPassCap
        '
        Me.lblPassCap.AutoSize = True
        Me.lblPassCap.Text = "Temporary password"
        Me.lblPassCap.Margin = New System.Windows.Forms.Padding(0, 8, 14, 0)
        Me.lblPassCap.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblPassCap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPassCap.Name = "lblPassCap"
        Me.lblPassCap.TabIndex = 8
        '
        'txtPass
        '
        Me.txtPass.Size = New System.Drawing.Size(260, 27)
        Me.txtPass.Margin = New System.Windows.Forms.Padding(2, 3, 8, 3)
        Me.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPass.UseSystemPasswordChar = True
        Me.txtPass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPass.Name = "txtPass"
        Me.txtPass.TabIndex = 9
        '
        'tlpFields
        '
        Me.tlpFields.ColumnCount = 2
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpFields.RowCount = 4
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpFields.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpFields.AutoSize = True
        Me.tlpFields.Padding = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.tlpFields.Name = "tlpFields"
        Me.tlpFields.TabIndex = 10
        Me.tlpFields.Controls.Add(Me.lblNameCap, 0, 0)
        Me.tlpFields.Controls.Add(Me.txtName, 1, 0)
        Me.tlpFields.Controls.Add(Me.lblUserCap, 0, 1)
        Me.tlpFields.Controls.Add(Me.txtUser, 1, 1)
        Me.tlpFields.Controls.Add(Me.lblRoleCap, 0, 2)
        Me.tlpFields.Controls.Add(Me.cboRole, 1, 2)
        Me.tlpFields.Controls.Add(Me.lblPassCap, 0, 3)
        Me.tlpFields.Controls.Add(Me.txtPass, 1, 3)
        '
        'btnCreate
        '
        Me.btnCreate.BackColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnCreate.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreate.Margin = New System.Windows.Forms.Padding(8, 4, 0, 4)
        Me.btnCreate.Size = New System.Drawing.Size(150, 36)
        Me.btnCreate.Text = "Create user"
        Me.btnCreate.UseVisualStyleBackColor = False
        Me.btnCreate.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreate.AutoSize = True
        Me.btnCreate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnCreate.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnCreate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnCreate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(67, 56, 202)
        Me.btnCreate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(55, 48, 163)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.TabIndex = 11
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(8, 4, 0, 4)
        Me.btnCancel.Size = New System.Drawing.Size(100, 36)
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.AutoSize = True
        Me.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnCancel.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(238, 242, 255)
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(224, 231, 255)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 12
        '
        'flowButtons
        '
        Me.flowButtons.AutoSize = False
        Me.flowButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flowButtons.Size = New System.Drawing.Size(440, 48)
        Me.flowButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flowButtons.Name = "flowButtons"
        Me.flowButtons.TabIndex = 13
        Me.flowButtons.Controls.Add(Me.btnCreate)
        Me.flowButtons.Controls.Add(Me.btnCancel)
        '
        'pnlBody
        '
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(20, 14, 20, 8)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.TabIndex = 14
        Me.pnlBody.Controls.Add(Me.lblMsg)
        Me.pnlBody.Controls.Add(Me.lblNote)
        Me.pnlBody.Controls.Add(Me.tlpFields)
        Me.pnlBody.Controls.Add(Me.flowButtons)
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = False
        Me.lblHeader.Text = "Add user"
        Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHeader.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblHeader.Padding = New System.Windows.Forms.Padding(20, 0, 0, 2)
        Me.lblHeader.AutoEllipsis = True
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.TabIndex = 15
        '
        'lblSubHeader
        '
        Me.lblSubHeader.AutoSize = False
        Me.lblSubHeader.Text = "Create an account for a bursar or an admin"
        Me.lblSubHeader.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblSubHeader.Size = New System.Drawing.Size(480, 24)
        Me.lblSubHeader.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubHeader.ForeColor = System.Drawing.Color.FromArgb(199, 210, 254)
        Me.lblSubHeader.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblSubHeader.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.lblSubHeader.AutoEllipsis = True
        Me.lblSubHeader.Name = "lblSubHeader"
        Me.lblSubHeader.TabIndex = 16
        '
        'pnlHeader
        '
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Size = New System.Drawing.Size(480, 66)
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.TabIndex = 17
        Me.pnlHeader.Controls.Add(Me.lblHeader)
        Me.pnlHeader.Controls.Add(Me.lblSubHeader)
        '
        'UserDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96!, 96!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(480, 440)
        Me.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add user"
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "UserDialog"
        Me.pnlHeader.ResumeLayout(False)
        Me.flowButtons.ResumeLayout(False)
        Me.flowButtons.PerformLayout()
        Me.tlpFields.ResumeLayout(False)
        Me.tlpFields.PerformLayout()
        Me.pnlBody.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents tlpFields As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblNameCap As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblUserCap As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents lblRoleCap As System.Windows.Forms.Label
    Friend WithEvents cboRole As System.Windows.Forms.ComboBox
    Friend WithEvents lblPassCap As System.Windows.Forms.Label
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents flowButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnCreate As RoundButton
    Friend WithEvents btnCancel As RoundButton
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblSubHeader As System.Windows.Forms.Label

End Class
