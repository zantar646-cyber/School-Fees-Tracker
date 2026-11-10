<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AuditView
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
        Me.lblNote = New System.Windows.Forms.Label()
        Me.flowBar = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cboAction = New System.Windows.Forms.ComboBox()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.dtp = New System.Windows.Forms.DateTimePicker()
        Me.btnExport = New RoundButton()
        Me.btnVerify = New RoundButton()
        Me.btnFolder = New RoundButton()
        Me.lblCount = New System.Windows.Forms.Label()
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
        'lblNote
        '
        Me.lblNote.AutoSize = False
        Me.lblNote.Text = ""
        Me.lblNote.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblNote.Size = New System.Drawing.Size(900, 24)
        Me.lblNote.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNote.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblNote.AutoEllipsis = True
        Me.lblNote.Name = "lblNote"
        Me.lblNote.TabIndex = 1
        '
        'txtSearch
        '
        Me.txtSearch.Size = New System.Drawing.Size(210, 27)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(2, 3, 8, 3)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.PlaceholderText = "Search record, user or reason"
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.TabIndex = 2
        '
        'cboAction
        '
        Me.cboAction.Size = New System.Drawing.Size(190, 27)
        Me.cboAction.Margin = New System.Windows.Forms.Padding(2, 3, 8, 3)
        Me.cboAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAction.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.cboAction.Items.AddRange(New Object() {})
        Me.cboAction.Name = "cboAction"
        Me.cboAction.TabIndex = 3
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Text = "Date"
        Me.lblDate.Margin = New System.Windows.Forms.Padding(0, 8, 6, 0)
        Me.lblDate.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.TabIndex = 4
        '
        'dtp
        '
        Me.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtp.ShowCheckBox = True
        Me.dtp.Size = New System.Drawing.Size(130, 27)
        Me.dtp.Margin = New System.Windows.Forms.Padding(0, 3, 10, 3)
        Me.dtp.Name = "dtp"
        Me.dtp.TabIndex = 5
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
        Me.btnExport.TabIndex = 6
        '
        'btnVerify
        '
        Me.btnVerify.BackColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnVerify.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnVerify.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerify.Margin = New System.Windows.Forms.Padding(0, 2, 6, 2)
        Me.btnVerify.Size = New System.Drawing.Size(110, 36)
        Me.btnVerify.Text = "Verify log"
        Me.btnVerify.UseVisualStyleBackColor = False
        Me.btnVerify.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerify.AutoSize = True
        Me.btnVerify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnVerify.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnVerify.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnVerify.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(67, 56, 202)
        Me.btnVerify.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(55, 48, 163)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.TabIndex = 7
        '
        'btnFolder
        '
        Me.btnFolder.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnFolder.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnFolder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFolder.Margin = New System.Windows.Forms.Padding(0, 2, 6, 2)
        Me.btnFolder.Size = New System.Drawing.Size(140, 36)
        Me.btnFolder.Text = "Open log folder"
        Me.btnFolder.UseVisualStyleBackColor = False
        Me.btnFolder.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFolder.AutoSize = True
        Me.btnFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnFolder.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnFolder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(238, 242, 255)
        Me.btnFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(224, 231, 255)
        Me.btnFolder.Name = "btnFolder"
        Me.btnFolder.TabIndex = 8
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Text = ""
        Me.lblCount.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblCount.Margin = New System.Windows.Forms.Padding(8, 8, 0, 0)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.TabIndex = 9
        '
        'flowBar
        '
        Me.flowBar.AutoSize = True
        Me.flowBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.flowBar.Padding = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.flowBar.Name = "flowBar"
        Me.flowBar.TabIndex = 10
        Me.flowBar.Controls.Add(Me.txtSearch)
        Me.flowBar.Controls.Add(Me.cboAction)
        Me.flowBar.Controls.Add(Me.lblDate)
        Me.flowBar.Controls.Add(Me.dtp)
        Me.flowBar.Controls.Add(Me.btnExport)
        Me.flowBar.Controls.Add(Me.btnVerify)
        Me.flowBar.Controls.Add(Me.btnFolder)
        Me.flowBar.Controls.Add(Me.lblCount)
        '
        'pnlCard
        '
        Me.pnlCard.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCard.Padding = New System.Windows.Forms.Padding(16, 14, 16, 16)
        Me.pnlCard.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.pnlCard.Name = "pnlCard"
        Me.pnlCard.TabIndex = 11
        Me.pnlCard.Controls.Add(Me.dgv)
        Me.pnlCard.Controls.Add(Me.lblNote)
        Me.pnlCard.Controls.Add(Me.flowBar)
        '
        'pnlAccentBar
        '
        Me.pnlAccentBar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccentBar.Size = New System.Drawing.Size(1, 1)
        Me.pnlAccentBar.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlAccentBar.Name = "pnlAccentBar"
        Me.pnlAccentBar.TabIndex = 12
        '
        'pnlAccent
        '
        Me.pnlAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAccent.Size = New System.Drawing.Size(900, 6)
        Me.pnlAccent.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlAccent.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlAccent.Name = "pnlAccent"
        Me.pnlAccent.TabIndex = 13
        Me.pnlAccent.Controls.Add(Me.pnlAccentBar)
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = False
        Me.lblTitle.Text = "Audit Log"
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Size = New System.Drawing.Size(900, 44)
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTitle.AutoEllipsis = True
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.TabIndex = 14
        '
        'AuditView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96!, 96!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Size = New System.Drawing.Size(1000, 600)
        Me.Controls.Add(Me.pnlCard)
        Me.Controls.Add(Me.pnlAccent)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "AuditView"
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
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents flowBar As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cboAction As System.Windows.Forms.ComboBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents dtp As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnExport As RoundButton
    Friend WithEvents btnVerify As RoundButton
    Friend WithEvents btnFolder As RoundButton
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents pnlAccent As System.Windows.Forms.Panel
    Friend WithEvents pnlAccentBar As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label

End Class
