<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AllocationDialog
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
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.flowButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnOk = New RoundButton()
        Me.btnCancel = New RoundButton()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.lblSummary = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblSubHeader = New System.Windows.Forms.Label()
        Me.pnlBody.SuspendLayout()
        Me.flowButtons.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.ReadOnly = True
        Me.dgv.RowHeadersVisible = False
        Me.dgv.BackgroundColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv.MultiSelect = False
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgv.Name = "dgv"
        Me.dgv.TabIndex = 0
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = False
        Me.lblTotal.Text = ""
        Me.lblTotal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblTotal.Size = New System.Drawing.Size(620, 32)
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTotal.AutoEllipsis = True
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.TabIndex = 1
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnOk.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Margin = New System.Windows.Forms.Padding(8, 4, 0, 4)
        Me.btnOk.Size = New System.Drawing.Size(170, 36)
        Me.btnOk.Text = "Confirm payment"
        Me.btnOk.UseVisualStyleBackColor = False
        Me.btnOk.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.AutoSize = True
        Me.btnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnOk.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(67, 56, 202)
        Me.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(55, 48, 163)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.TabIndex = 2
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
        Me.btnCancel.TabIndex = 3
        '
        'flowButtons
        '
        Me.flowButtons.AutoSize = False
        Me.flowButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flowButtons.Size = New System.Drawing.Size(440, 48)
        Me.flowButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flowButtons.Name = "flowButtons"
        Me.flowButtons.TabIndex = 4
        Me.flowButtons.Controls.Add(Me.btnOk)
        Me.flowButtons.Controls.Add(Me.btnCancel)
        '
        'lblMsg
        '
        Me.lblMsg.AutoSize = False
        Me.lblMsg.Text = ""
        Me.lblMsg.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblMsg.Size = New System.Drawing.Size(440, 28)
        Me.lblMsg.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.lblMsg.AutoEllipsis = True
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.TabIndex = 5
        '
        'lblSummary
        '
        Me.lblSummary.AutoSize = False
        Me.lblSummary.Text = ""
        Me.lblSummary.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSummary.Size = New System.Drawing.Size(620, 46)
        Me.lblSummary.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblSummary.AutoEllipsis = True
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.TabIndex = 6
        '
        'pnlBody
        '
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(20, 14, 20, 8)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.TabIndex = 7
        Me.pnlBody.Controls.Add(Me.dgv)
        Me.pnlBody.Controls.Add(Me.lblTotal)
        Me.pnlBody.Controls.Add(Me.flowButtons)
        Me.pnlBody.Controls.Add(Me.lblMsg)
        Me.pnlBody.Controls.Add(Me.lblSummary)
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = False
        Me.lblHeader.Text = "Pay for several terms"
        Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHeader.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblHeader.Padding = New System.Windows.Forms.Padding(20, 0, 0, 2)
        Me.lblHeader.AutoEllipsis = True
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.TabIndex = 8
        '
        'lblSubHeader
        '
        Me.lblSubHeader.AutoSize = False
        Me.lblSubHeader.Text = "Share one payment across the pupil's terms"
        Me.lblSubHeader.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblSubHeader.Size = New System.Drawing.Size(660, 24)
        Me.lblSubHeader.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubHeader.ForeColor = System.Drawing.Color.FromArgb(199, 210, 254)
        Me.lblSubHeader.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.lblSubHeader.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.lblSubHeader.AutoEllipsis = True
        Me.lblSubHeader.Name = "lblSubHeader"
        Me.lblSubHeader.TabIndex = 9
        '
        'pnlHeader
        '
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Size = New System.Drawing.Size(660, 66)
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.TabIndex = 10
        Me.pnlHeader.Controls.Add(Me.lblHeader)
        Me.pnlHeader.Controls.Add(Me.lblSubHeader)
        '
        'AllocationDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96!, 96!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(660, 520)
        Me.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Pay for several terms"
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "AllocationDialog"
        Me.pnlHeader.ResumeLayout(False)
        Me.flowButtons.ResumeLayout(False)
        Me.flowButtons.PerformLayout()
        Me.pnlBody.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlBody As System.Windows.Forms.Panel
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents flowButtons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnOk As RoundButton
    Friend WithEvents btnCancel As RoundButton
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    Friend WithEvents lblSummary As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblSubHeader As System.Windows.Forms.Label

End Class
