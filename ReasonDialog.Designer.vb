<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReasonDialog
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
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.lblField = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.flowButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnOk = New RoundButton()
        Me.btnCancel = New RoundButton()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblSubHeader = New System.Windows.Forms.Label()
        Me.pnlBody.SuspendLayout()
        Me.flowButtons.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtValue
        '
        Me.txtValue.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtValue.Size = New System.Drawing.Size(432, 27)
        Me.txtValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValue.Name = "txtValue"
        Me.txtValue.TabIndex = 0
        '
        'lblField
        '
        Me.lblField.AutoSize = False
        Me.lblField.Text = "Reason (required)"
        Me.lblField.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblField.Size = New System.Drawing.Size(432, 28)
        Me.lblField.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblField.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblField.AutoEllipsis = True
        Me.lblField.Name = "lblField"
        Me.lblField.TabIndex = 1
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = False
        Me.lblMessage.Text = ""
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblMessage.Size = New System.Drawing.Size(432, 110)
        Me.lblMessage.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblMessage.AutoEllipsis = True
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.TabIndex = 2
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnOk.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Margin = New System.Windows.Forms.Padding(8, 4, 0, 4)
        Me.btnOk.Size = New System.Drawing.Size(160, 36)
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = False
        Me.btnOk.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.AutoSize = True
        Me.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnOk.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(67, 56, 202)
        Me.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(55, 48, 163)
        Me.btnOk.Enabled = False
        Me.btnOk.Name = "btnOk"
        Me.btnOk.TabIndex = 3
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
        Me.btnCancel.TabIndex = 4
        '
        'flowButtons
        '
        Me.flowButtons.AutoSize = False
        Me.flowButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flowButtons.Size = New System.Drawing.Size(440, 48)
        Me.flowButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flowButtons.Name = "flowButtons"
        Me.flowButtons.TabIndex = 5
        Me.flowButtons.Controls.Add(Me.btnOk)
        Me.flowButtons.Controls.Add(Me.btnCancel)
        '
        'pnlBody
        '
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(20, 14, 20, 8)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.TabIndex = 6
        Me.pnlBody.Controls.Add(Me.txtValue)
        Me.pnlBody.Controls.Add(Me.lblField)
        Me.pnlBody.Controls.Add(Me.lblMessage)
        Me.pnlBody.Controls.Add(Me.flowButtons)
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = False
        Me.lblHeader.Text = "Confirm"
        Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHeader.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblHeader.Padding = New System.Windows.Forms.Padding(20, 0, 0, 2)
        Me.lblHeader.AutoEllipsis = True
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.TabIndex = 7
        '
        'lblSubHeader
        '
        Me.lblSubHeader.AutoSize = False
        Me.lblSubHeader.Text = ""
        Me.lblSubHeader.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblSubHeader.Size = New System.Drawing.Size(480, 24)
        Me.lblSubHeader.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubHeader.ForeColor = System.Drawing.Color.FromArgb(199, 210, 254)
        Me.lblSubHeader.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblSubHeader.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.lblSubHeader.AutoEllipsis = True
        Me.lblSubHeader.Name = "lblSubHeader"
        Me.lblSubHeader.TabIndex = 8
        '
        'pnlHeader
        '
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Size = New System.Drawing.Size(480, 66)
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.TabIndex = 9
        Me.pnlHeader.Controls.Add(Me.lblHeader)
        Me.pnlHeader.Controls.Add(Me.lblSubHeader)
        '
        'ReasonDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96!, 96!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(480, 350)
        Me.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Confirm"
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ReasonDialog"
        Me.pnlHeader.ResumeLayout(False)
        Me.flowButtons.ResumeLayout(False)
        Me.flowButtons.PerformLayout()
        Me.pnlBody.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents lblField As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents flowButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnOk As RoundButton
    Friend WithEvents btnCancel As RoundButton
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblSubHeader As System.Windows.Forms.Label

End Class
