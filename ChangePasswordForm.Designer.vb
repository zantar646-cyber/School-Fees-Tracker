<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChangePasswordForm
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
        Me.tlpFields = New System.Windows.Forms.TableLayoutPanel()
        Me.lblNewCaption = New System.Windows.Forms.Label()
        Me.txtNew = New System.Windows.Forms.TextBox()
        Me.lblConfirmCaption = New System.Windows.Forms.Label()
        Me.txtConfirm = New System.Windows.Forms.TextBox()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.flowButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnSave = New RoundButton()
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
        Me.lblMsg.Size = New System.Drawing.Size(440, 40)
        Me.lblMsg.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.lblMsg.AutoEllipsis = True
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.TabIndex = 0
        '
        'lblNewCaption
        '
        Me.lblNewCaption.AutoSize = True
        Me.lblNewCaption.Text = "New password"
        Me.lblNewCaption.Margin = New System.Windows.Forms.Padding(0, 8, 14, 0)
        Me.lblNewCaption.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblNewCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNewCaption.Name = "lblNewCaption"
        Me.lblNewCaption.TabIndex = 1
        '
        'txtNew
        '
        Me.txtNew.Size = New System.Drawing.Size(240, 27)
        Me.txtNew.Margin = New System.Windows.Forms.Padding(2, 3, 8, 3)
        Me.txtNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNew.UseSystemPasswordChar = True
        Me.txtNew.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNew.Name = "txtNew"
        Me.txtNew.TabIndex = 2
        '
        'lblConfirmCaption
        '
        Me.lblConfirmCaption.AutoSize = True
        Me.lblConfirmCaption.Text = "Confirm"
        Me.lblConfirmCaption.Margin = New System.Windows.Forms.Padding(0, 8, 14, 0)
        Me.lblConfirmCaption.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblConfirmCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblConfirmCaption.Name = "lblConfirmCaption"
        Me.lblConfirmCaption.TabIndex = 3
        '
        'txtConfirm
        '
        Me.txtConfirm.Size = New System.Drawing.Size(240, 27)
        Me.txtConfirm.Margin = New System.Windows.Forms.Padding(2, 3, 8, 3)
        Me.txtConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConfirm.UseSystemPasswordChar = True
        Me.txtConfirm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtConfirm.Name = "txtConfirm"
        Me.txtConfirm.TabIndex = 4
        '
        'tlpFields
        '
        Me.tlpFields.ColumnCount = 2
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpFields.RowCount = 2
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpFields.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpFields.AutoSize = True
        Me.tlpFields.Padding = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.tlpFields.Name = "tlpFields"
        Me.tlpFields.TabIndex = 5
        Me.tlpFields.Controls.Add(Me.lblNewCaption, 0, 0)
        Me.tlpFields.Controls.Add(Me.txtNew, 1, 0)
        Me.tlpFields.Controls.Add(Me.lblConfirmCaption, 0, 1)
        Me.tlpFields.Controls.Add(Me.txtConfirm, 1, 1)
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = False
        Me.lblInfo.Text = ""
        Me.lblInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblInfo.Size = New System.Drawing.Size(440, 48)
        Me.lblInfo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblInfo.AutoEllipsis = True
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.TabIndex = 6
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnSave.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Margin = New System.Windows.Forms.Padding(8, 4, 0, 4)
        Me.btnSave.Size = New System.Drawing.Size(110, 36)
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.AutoSize = True
        Me.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnSave.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(67, 56, 202)
        Me.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(55, 48, 163)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.TabIndex = 7
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
        Me.btnCancel.TabIndex = 8
        '
        'flowButtons
        '
        Me.flowButtons.AutoSize = False
        Me.flowButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flowButtons.Size = New System.Drawing.Size(440, 48)
        Me.flowButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flowButtons.Name = "flowButtons"
        Me.flowButtons.TabIndex = 9
        Me.flowButtons.Controls.Add(Me.btnSave)
        Me.flowButtons.Controls.Add(Me.btnCancel)
        '
        'pnlBody
        '
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(20, 14, 20, 8)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.TabIndex = 10
        Me.pnlBody.Controls.Add(Me.lblMsg)
        Me.pnlBody.Controls.Add(Me.tlpFields)
        Me.pnlBody.Controls.Add(Me.lblInfo)
        Me.pnlBody.Controls.Add(Me.flowButtons)
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = False
        Me.lblHeader.Text = "Change password"
        Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHeader.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblHeader.Padding = New System.Windows.Forms.Padding(20, 0, 0, 2)
        Me.lblHeader.AutoEllipsis = True
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.TabIndex = 11
        '
        'lblSubHeader
        '
        Me.lblSubHeader.AutoSize = False
        Me.lblSubHeader.Text = "Use a password only you know"
        Me.lblSubHeader.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblSubHeader.Size = New System.Drawing.Size(440, 24)
        Me.lblSubHeader.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubHeader.ForeColor = System.Drawing.Color.FromArgb(199, 210, 254)
        Me.lblSubHeader.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblSubHeader.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.lblSubHeader.AutoEllipsis = True
        Me.lblSubHeader.Name = "lblSubHeader"
        Me.lblSubHeader.TabIndex = 12
        '
        'pnlHeader
        '
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Size = New System.Drawing.Size(440, 66)
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.TabIndex = 13
        Me.pnlHeader.Controls.Add(Me.lblHeader)
        Me.pnlHeader.Controls.Add(Me.lblSubHeader)
        '
        'ChangePasswordForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96!, 96!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(440, 360)
        Me.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change password"
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ChangePasswordForm"
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
    Friend WithEvents tlpFields As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblNewCaption As System.Windows.Forms.Label
    Friend WithEvents txtNew As System.Windows.Forms.TextBox
    Friend WithEvents lblConfirmCaption As System.Windows.Forms.Label
    Friend WithEvents txtConfirm As System.Windows.Forms.TextBox
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents flowButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnSave As RoundButton
    Friend WithEvents btnCancel As RoundButton
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblSubHeader As System.Windows.Forms.Label

End Class
