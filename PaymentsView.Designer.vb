<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PaymentsView
    Inherits System.Windows.Forms.UserControl

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
        Me.pnlCard = New Surface()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.lblEmpty = New System.Windows.Forms.Label()
        Me.flowBar = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.chkVoided = New System.Windows.Forms.CheckBox()
        Me.btnReprint = New RoundButton()
        Me.btnVoid = New RoundButton()
        Me.btnRefund = New RoundButton()
        Me.btnExport = New RoundButton()
        Me.pnlAccent = New System.Windows.Forms.Panel()
        Me.pnlAccentBar = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlCard.SuspendLayout()
        Me.flowBar.SuspendLayout()
        Me.pnlAccent.SuspendLayout()
        Me.pnlAccentBar.SuspendLayout()
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
        'lblEmpty
        '
        Me.lblEmpty.AutoSize = False
        Me.lblEmpty.Text = ""
        Me.lblEmpty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblEmpty.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblEmpty.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.lblEmpty.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblEmpty.Visible = False
        Me.lblEmpty.AutoEllipsis = True
        Me.lblEmpty.Name = "lblEmpty"
        Me.lblEmpty.TabIndex = 1
        '
        'txtSearch
        '
        Me.txtSearch.Size = New System.Drawing.Size(230, 27)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(2, 3, 8, 3)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.PlaceholderText = "Search receipt, student or ID"
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.TabIndex = 2
        '
        'chkVoided
        '
        Me.chkVoided.AutoSize = True
        Me.chkVoided.Text = "Show voided"
        Me.chkVoided.Checked = True
        Me.chkVoided.Margin = New System.Windows.Forms.Padding(0, 8, 14, 0)
        Me.chkVoided.UseVisualStyleBackColor = True
        Me.chkVoided.Name = "chkVoided"
        Me.chkVoided.TabIndex = 3
        '
        'btnReprint
        '
        Me.btnReprint.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnReprint.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnReprint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReprint.Margin = New System.Windows.Forms.Padding(0, 2, 6, 2)
        Me.btnReprint.Size = New System.Drawing.Size(140, 36)
        Me.btnReprint.Text = "Reprint receipt"
        Me.btnReprint.UseVisualStyleBackColor = False
        Me.btnReprint.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReprint.AutoSize = True
        Me.btnReprint.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnReprint.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnReprint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnReprint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(238, 242, 255)
        Me.btnReprint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(224, 231, 255)
        Me.btnReprint.Name = "btnReprint"
        Me.btnReprint.TabIndex = 4
        '
        'btnVoid
        '
        Me.btnVoid.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnVoid.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.btnVoid.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVoid.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVoid.Margin = New System.Windows.Forms.Padding(0, 2, 6, 2)
        Me.btnVoid.Size = New System.Drawing.Size(130, 36)
        Me.btnVoid.Text = "Void payment"
        Me.btnVoid.UseVisualStyleBackColor = False
        Me.btnVoid.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoid.AutoSize = True
        Me.btnVoid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnVoid.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnVoid.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(252, 165, 165)
        Me.btnVoid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(254, 242, 242)
        Me.btnVoid.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(254, 226, 226)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.TabIndex = 5
        '
        'btnRefund
        '
        Me.btnRefund.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnRefund.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.btnRefund.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefund.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefund.Margin = New System.Windows.Forms.Padding(0, 2, 6, 2)
        Me.btnRefund.Size = New System.Drawing.Size(110, 36)
        Me.btnRefund.Text = "Refund..."
        Me.btnRefund.UseVisualStyleBackColor = False
        Me.btnRefund.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefund.AutoSize = True
        Me.btnRefund.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnRefund.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnRefund.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(252, 165, 165)
        Me.btnRefund.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(254, 242, 242)
        Me.btnRefund.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(254, 226, 226)
        Me.btnRefund.Name = "btnRefund"
        Me.btnRefund.TabIndex = 6
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnExport.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Margin = New System.Windows.Forms.Padding(0, 2, 6, 2)
        Me.btnExport.Size = New System.Drawing.Size(110, 36)
        Me.btnExport.Text = "Export CSV"
        Me.btnExport.UseVisualStyleBackColor = False
        Me.btnExport.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.AutoSize = True
        Me.btnExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnExport.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(238, 242, 255)
        Me.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(224, 231, 255)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.TabIndex = 7
        '
        'flowBar
        '
        Me.flowBar.AutoSize = True
        Me.flowBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.flowBar.Padding = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.flowBar.Name = "flowBar"
        Me.flowBar.TabIndex = 8
        Me.flowBar.Controls.Add(Me.txtSearch)
        Me.flowBar.Controls.Add(Me.chkVoided)
        Me.flowBar.Controls.Add(Me.btnReprint)
        Me.flowBar.Controls.Add(Me.btnVoid)
        Me.flowBar.Controls.Add(Me.btnRefund)
        Me.flowBar.Controls.Add(Me.btnExport)
        '
        'pnlCard
        '
        Me.pnlCard.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCard.Padding = New System.Windows.Forms.Padding(16, 14, 16, 16)
        Me.pnlCard.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.pnlCard.Name = "pnlCard"
        Me.pnlCard.TabIndex = 9
        Me.pnlCard.Controls.Add(Me.dgv)
        Me.pnlCard.Controls.Add(Me.lblEmpty)
        Me.pnlCard.Controls.Add(Me.flowBar)
        '
        'pnlAccentBar
        '
        Me.pnlAccentBar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccentBar.Size = New System.Drawing.Size(1, 1)
        Me.pnlAccentBar.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlAccentBar.Name = "pnlAccentBar"
        Me.pnlAccentBar.TabIndex = 10
        '
        'pnlAccent
        '
        Me.pnlAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAccent.Size = New System.Drawing.Size(900, 6)
        Me.pnlAccent.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlAccent.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlAccent.Name = "pnlAccent"
        Me.pnlAccent.TabIndex = 11
        Me.pnlAccent.Controls.Add(Me.pnlAccentBar)
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = False
        Me.lblTitle.Text = "Payments"
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Size = New System.Drawing.Size(900, 44)
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTitle.AutoEllipsis = True
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.TabIndex = 12
        '
        'PaymentsView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96!, 96!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Size = New System.Drawing.Size(1000, 600)
        Me.Controls.Add(Me.pnlCard)
        Me.Controls.Add(Me.pnlAccent)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "PaymentsView"
        Me.pnlAccentBar.ResumeLayout(False)
        Me.pnlAccent.ResumeLayout(False)
        Me.flowBar.ResumeLayout(False)
        Me.flowBar.PerformLayout()
        Me.pnlCard.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlCard As Surface
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents lblEmpty As System.Windows.Forms.Label
    Friend WithEvents flowBar As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents chkVoided As System.Windows.Forms.CheckBox
    Friend WithEvents btnReprint As RoundButton
    Friend WithEvents btnVoid As RoundButton
    Friend WithEvents btnRefund As RoundButton
    Friend WithEvents btnExport As RoundButton
    Friend WithEvents pnlAccent As System.Windows.Forms.Panel
    Friend WithEvents pnlAccentBar As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label

End Class
