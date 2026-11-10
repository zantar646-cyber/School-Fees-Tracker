<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FeesView
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
        Me.flowSave = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnSave = New RoundButton()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.flowTop = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblSchool = New System.Windows.Forms.Label()
        Me.txtSchool = New System.Windows.Forms.TextBox()
        Me.btnSaveName = New RoundButton()
        Me.btnBackup = New RoundButton()
        Me.btnRestore = New RoundButton()
        Me.pnlAccent = New System.Windows.Forms.Panel()
        Me.pnlAccentBar = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlCard.SuspendLayout()
        Me.flowSave.SuspendLayout()
        Me.flowTop.SuspendLayout()
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
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnSave.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Margin = New System.Windows.Forms.Padding(0, 2, 6, 2)
        Me.btnSave.Size = New System.Drawing.Size(130, 36)
        Me.btnSave.Text = "Save fees"
        Me.btnSave.UseVisualStyleBackColor = False
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.AutoSize = True
        Me.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnSave.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(67, 56, 202)
        Me.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(55, 48, 163)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.TabIndex = 1
        '
        'flowSave
        '
        Me.flowSave.AutoSize = False
        Me.flowSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowSave.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.flowSave.Size = New System.Drawing.Size(900, 52)
        Me.flowSave.Padding = New System.Windows.Forms.Padding(0, 8, 0, 0)
        Me.flowSave.Name = "flowSave"
        Me.flowSave.TabIndex = 2
        Me.flowSave.Controls.Add(Me.btnSave)
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
        Me.lblNote.TabIndex = 3
        '
        'lblSchool
        '
        Me.lblSchool.AutoSize = True
        Me.lblSchool.Text = "School name (printed on receipts)"
        Me.lblSchool.Margin = New System.Windows.Forms.Padding(0, 8, 6, 0)
        Me.lblSchool.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblSchool.Name = "lblSchool"
        Me.lblSchool.TabIndex = 4
        '
        'txtSchool
        '
        Me.txtSchool.Size = New System.Drawing.Size(280, 27)
        Me.txtSchool.Margin = New System.Windows.Forms.Padding(2, 3, 8, 3)
        Me.txtSchool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSchool.Name = "txtSchool"
        Me.txtSchool.TabIndex = 5
        '
        'btnSaveName
        '
        Me.btnSaveName.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnSaveName.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnSaveName.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveName.Margin = New System.Windows.Forms.Padding(0, 2, 6, 2)
        Me.btnSaveName.Size = New System.Drawing.Size(110, 36)
        Me.btnSaveName.Text = "Save name"
        Me.btnSaveName.UseVisualStyleBackColor = False
        Me.btnSaveName.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveName.AutoSize = True
        Me.btnSaveName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnSaveName.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnSaveName.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnSaveName.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(238, 242, 255)
        Me.btnSaveName.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(224, 231, 255)
        Me.btnSaveName.Name = "btnSaveName"
        Me.btnSaveName.TabIndex = 6
        '
        'btnBackup
        '
        Me.btnBackup.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnBackup.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnBackup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBackup.Margin = New System.Windows.Forms.Padding(0, 2, 6, 2)
        Me.btnBackup.Size = New System.Drawing.Size(160, 36)
        Me.btnBackup.Text = "Back up database"
        Me.btnBackup.UseVisualStyleBackColor = False
        Me.btnBackup.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBackup.AutoSize = True
        Me.btnBackup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnBackup.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnBackup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(238, 242, 255)
        Me.btnBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(224, 231, 255)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.TabIndex = 7
        '
        'btnRestore
        '
        Me.btnRestore.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnRestore.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRestore.Margin = New System.Windows.Forms.Padding(0, 2, 6, 2)
        Me.btnRestore.Size = New System.Drawing.Size(150, 36)
        Me.btnRestore.Text = "Restore backup"
        Me.btnRestore.UseVisualStyleBackColor = False
        Me.btnRestore.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRestore.AutoSize = True
        Me.btnRestore.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnRestore.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnRestore.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnRestore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(238, 242, 255)
        Me.btnRestore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(224, 231, 255)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.TabIndex = 8
        '
        'flowTop
        '
        Me.flowTop.AutoSize = True
        Me.flowTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.flowTop.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.flowTop.Name = "flowTop"
        Me.flowTop.TabIndex = 9
        Me.flowTop.Controls.Add(Me.lblSchool)
        Me.flowTop.Controls.Add(Me.txtSchool)
        Me.flowTop.Controls.Add(Me.btnSaveName)
        Me.flowTop.Controls.Add(Me.btnBackup)
        Me.flowTop.Controls.Add(Me.btnRestore)
        '
        'pnlCard
        '
        Me.pnlCard.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCard.Padding = New System.Windows.Forms.Padding(16, 14, 16, 16)
        Me.pnlCard.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.pnlCard.Name = "pnlCard"
        Me.pnlCard.TabIndex = 10
        Me.pnlCard.Controls.Add(Me.dgv)
        Me.pnlCard.Controls.Add(Me.flowSave)
        Me.pnlCard.Controls.Add(Me.lblNote)
        Me.pnlCard.Controls.Add(Me.flowTop)
        '
        'pnlAccentBar
        '
        Me.pnlAccentBar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccentBar.Size = New System.Drawing.Size(1, 1)
        Me.pnlAccentBar.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlAccentBar.Name = "pnlAccentBar"
        Me.pnlAccentBar.TabIndex = 11
        '
        'pnlAccent
        '
        Me.pnlAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAccent.Size = New System.Drawing.Size(900, 6)
        Me.pnlAccent.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlAccent.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlAccent.Name = "pnlAccent"
        Me.pnlAccent.TabIndex = 12
        Me.pnlAccent.Controls.Add(Me.pnlAccentBar)
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = False
        Me.lblTitle.Text = "Fee Settings"
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Size = New System.Drawing.Size(900, 44)
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTitle.AutoEllipsis = True
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.TabIndex = 13
        '
        'FeesView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96!, 96!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Size = New System.Drawing.Size(1000, 600)
        Me.Controls.Add(Me.pnlCard)
        Me.Controls.Add(Me.pnlAccent)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "FeesView"
        Me.pnlAccentBar.ResumeLayout(False)
        Me.pnlAccent.ResumeLayout(False)
        Me.flowTop.ResumeLayout(False)
        Me.flowTop.PerformLayout()
        Me.flowSave.ResumeLayout(False)
        Me.flowSave.PerformLayout()
        Me.pnlCard.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlCard As Surface
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents flowSave As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnSave As RoundButton
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents flowTop As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblSchool As System.Windows.Forms.Label
    Friend WithEvents txtSchool As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveName As RoundButton
    Friend WithEvents btnBackup As RoundButton
    Friend WithEvents btnRestore As RoundButton
    Friend WithEvents pnlAccent As System.Windows.Forms.Panel
    Friend WithEvents pnlAccentBar As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label

End Class
