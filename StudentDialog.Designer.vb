<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StudentDialog
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
        Me.lblClassCap = New System.Windows.Forms.Label()
        Me.cboClass = New System.Windows.Forms.ComboBox()
        Me.lblTermCap = New System.Windows.Forms.Label()
        Me.cboTerm = New System.Windows.Forms.ComboBox()
        Me.lblGuardianCap = New System.Windows.Forms.Label()
        Me.txtGuardian = New System.Windows.Forms.TextBox()
        Me.lblPhoneCap = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.lblFeeCap = New System.Windows.Forms.Label()
        Me.txtFee = New System.Windows.Forms.TextBox()
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
        Me.lblMsg.Size = New System.Drawing.Size(440, 36)
        Me.lblMsg.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.lblMsg.AutoEllipsis = True
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.TabIndex = 0
        '
        'lblNote
        '
        Me.lblNote.AutoSize = False
        Me.lblNote.Text = ""
        Me.lblNote.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblNote.Size = New System.Drawing.Size(440, 48)
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
        'lblClassCap
        '
        Me.lblClassCap.AutoSize = True
        Me.lblClassCap.Text = "Class"
        Me.lblClassCap.Margin = New System.Windows.Forms.Padding(0, 8, 14, 0)
        Me.lblClassCap.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblClassCap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblClassCap.Name = "lblClassCap"
        Me.lblClassCap.TabIndex = 4
        '
        'cboClass
        '
        Me.cboClass.Size = New System.Drawing.Size(260, 27)
        Me.cboClass.Margin = New System.Windows.Forms.Padding(2, 3, 8, 3)
        Me.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboClass.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.cboClass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboClass.Items.AddRange(New Object() {"JHS 1", "JHS 2", "JHS 3"})
        Me.cboClass.Name = "cboClass"
        Me.cboClass.TabIndex = 5
        '
        'lblTermCap
        '
        Me.lblTermCap.AutoSize = True
        Me.lblTermCap.Text = "Term"
        Me.lblTermCap.Margin = New System.Windows.Forms.Padding(0, 8, 14, 0)
        Me.lblTermCap.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblTermCap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTermCap.Name = "lblTermCap"
        Me.lblTermCap.TabIndex = 6
        '
        'cboTerm
        '
        Me.cboTerm.Size = New System.Drawing.Size(260, 27)
        Me.cboTerm.Margin = New System.Windows.Forms.Padding(2, 3, 8, 3)
        Me.cboTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTerm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTerm.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.cboTerm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTerm.Items.AddRange(New Object() {"Term 1", "Term 2", "Term 3"})
        Me.cboTerm.Name = "cboTerm"
        Me.cboTerm.TabIndex = 7
        '
        'lblGuardianCap
        '
        Me.lblGuardianCap.AutoSize = True
        Me.lblGuardianCap.Text = "Guardian name"
        Me.lblGuardianCap.Margin = New System.Windows.Forms.Padding(0, 8, 14, 0)
        Me.lblGuardianCap.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblGuardianCap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGuardianCap.Name = "lblGuardianCap"
        Me.lblGuardianCap.TabIndex = 8
        '
        'txtGuardian
        '
        Me.txtGuardian.Size = New System.Drawing.Size(260, 27)
        Me.txtGuardian.Margin = New System.Windows.Forms.Padding(2, 3, 8, 3)
        Me.txtGuardian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGuardian.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtGuardian.Name = "txtGuardian"
        Me.txtGuardian.TabIndex = 9
        '
        'lblPhoneCap
        '
        Me.lblPhoneCap.AutoSize = True
        Me.lblPhoneCap.Text = "Guardian phone"
        Me.lblPhoneCap.Margin = New System.Windows.Forms.Padding(0, 8, 14, 0)
        Me.lblPhoneCap.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblPhoneCap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPhoneCap.Name = "lblPhoneCap"
        Me.lblPhoneCap.TabIndex = 10
        '
        'txtPhone
        '
        Me.txtPhone.Size = New System.Drawing.Size(260, 27)
        Me.txtPhone.Margin = New System.Windows.Forms.Padding(2, 3, 8, 3)
        Me.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPhone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.TabIndex = 11
        '
        'lblFeeCap
        '
        Me.lblFeeCap.AutoSize = True
        Me.lblFeeCap.Text = "Term fee (GH₵)"
        Me.lblFeeCap.Margin = New System.Windows.Forms.Padding(0, 8, 14, 0)
        Me.lblFeeCap.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblFeeCap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFeeCap.Name = "lblFeeCap"
        Me.lblFeeCap.TabIndex = 12
        '
        'txtFee
        '
        Me.txtFee.Size = New System.Drawing.Size(260, 27)
        Me.txtFee.Margin = New System.Windows.Forms.Padding(2, 3, 8, 3)
        Me.txtFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFee.Name = "txtFee"
        Me.txtFee.TabIndex = 13
        '
        'tlpFields
        '
        Me.tlpFields.ColumnCount = 2
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpFields.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpFields.RowCount = 6
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpFields.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpFields.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpFields.AutoSize = True
        Me.tlpFields.Padding = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.tlpFields.Name = "tlpFields"
        Me.tlpFields.TabIndex = 14
        Me.tlpFields.Controls.Add(Me.lblNameCap, 0, 0)
        Me.tlpFields.Controls.Add(Me.txtName, 1, 0)
        Me.tlpFields.Controls.Add(Me.lblClassCap, 0, 1)
        Me.tlpFields.Controls.Add(Me.cboClass, 1, 1)
        Me.tlpFields.Controls.Add(Me.lblTermCap, 0, 2)
        Me.tlpFields.Controls.Add(Me.cboTerm, 1, 2)
        Me.tlpFields.Controls.Add(Me.lblGuardianCap, 0, 3)
        Me.tlpFields.Controls.Add(Me.txtGuardian, 1, 3)
        Me.tlpFields.Controls.Add(Me.lblPhoneCap, 0, 4)
        Me.tlpFields.Controls.Add(Me.txtPhone, 1, 4)
        Me.tlpFields.Controls.Add(Me.lblFeeCap, 0, 5)
        Me.tlpFields.Controls.Add(Me.txtFee, 1, 5)
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnSave.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Margin = New System.Windows.Forms.Padding(8, 4, 0, 4)
        Me.btnSave.Size = New System.Drawing.Size(150, 36)
        Me.btnSave.Text = "Save student"
        Me.btnSave.UseVisualStyleBackColor = False
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.AutoSize = True
        Me.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnSave.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(67, 56, 202)
        Me.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(55, 48, 163)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.TabIndex = 15
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
        Me.btnCancel.TabIndex = 16
        '
        'flowButtons
        '
        Me.flowButtons.AutoSize = False
        Me.flowButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flowButtons.Size = New System.Drawing.Size(440, 48)
        Me.flowButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flowButtons.Name = "flowButtons"
        Me.flowButtons.TabIndex = 17
        Me.flowButtons.Controls.Add(Me.btnSave)
        Me.flowButtons.Controls.Add(Me.btnCancel)
        '
        'pnlBody
        '
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(20, 14, 20, 8)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.TabIndex = 18
        Me.pnlBody.Controls.Add(Me.lblMsg)
        Me.pnlBody.Controls.Add(Me.lblNote)
        Me.pnlBody.Controls.Add(Me.tlpFields)
        Me.pnlBody.Controls.Add(Me.flowButtons)
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = False
        Me.lblHeader.Text = "Register student"
        Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHeader.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblHeader.Padding = New System.Windows.Forms.Padding(20, 0, 0, 2)
        Me.lblHeader.AutoEllipsis = True
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.TabIndex = 19
        '
        'lblSubHeader
        '
        Me.lblSubHeader.AutoSize = False
        Me.lblSubHeader.Text = "Add a new student to the register"
        Me.lblSubHeader.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblSubHeader.Size = New System.Drawing.Size(480, 24)
        Me.lblSubHeader.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubHeader.ForeColor = System.Drawing.Color.FromArgb(199, 210, 254)
        Me.lblSubHeader.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblSubHeader.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.lblSubHeader.AutoEllipsis = True
        Me.lblSubHeader.Name = "lblSubHeader"
        Me.lblSubHeader.TabIndex = 20
        '
        'pnlHeader
        '
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Size = New System.Drawing.Size(480, 66)
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.TabIndex = 21
        Me.pnlHeader.Controls.Add(Me.lblHeader)
        Me.pnlHeader.Controls.Add(Me.lblSubHeader)
        '
        'StudentDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96!, 96!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(480, 520)
        Me.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Register student"
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "StudentDialog"
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
    Friend WithEvents lblClassCap As System.Windows.Forms.Label
    Friend WithEvents cboClass As System.Windows.Forms.ComboBox
    Friend WithEvents lblTermCap As System.Windows.Forms.Label
    Friend WithEvents cboTerm As System.Windows.Forms.ComboBox
    Friend WithEvents lblGuardianCap As System.Windows.Forms.Label
    Friend WithEvents txtGuardian As System.Windows.Forms.TextBox
    Friend WithEvents lblPhoneCap As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents lblFeeCap As System.Windows.Forms.Label
    Friend WithEvents txtFee As System.Windows.Forms.TextBox
    Friend WithEvents flowButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnSave As RoundButton
    Friend WithEvents btnCancel As RoundButton
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblSubHeader As System.Windows.Forms.Label

End Class
