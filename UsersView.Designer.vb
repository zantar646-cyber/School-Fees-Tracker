<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UsersView
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
        Me.btnAdd = New RoundButton()
        Me.btnReset = New RoundButton()
        Me.btnToggle = New RoundButton()
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
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnAdd.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(0, 2, 6, 2)
        Me.btnAdd.Size = New System.Drawing.Size(110, 36)
        Me.btnAdd.Text = "Add user"
        Me.btnAdd.UseVisualStyleBackColor = False
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.AutoSize = True
        Me.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnAdd.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(67, 56, 202)
        Me.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(55, 48, 163)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.TabIndex = 2
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnReset.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnReset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReset.Margin = New System.Windows.Forms.Padding(0, 2, 6, 2)
        Me.btnReset.Size = New System.Drawing.Size(150, 36)
        Me.btnReset.Text = "Reset password"
        Me.btnReset.UseVisualStyleBackColor = False
        Me.btnReset.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.AutoSize = True
        Me.btnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnReset.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(238, 242, 255)
        Me.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(224, 231, 255)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.TabIndex = 3
        '
        'btnToggle
        '
        Me.btnToggle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnToggle.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnToggle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnToggle.Margin = New System.Windows.Forms.Padding(0, 2, 6, 2)
        Me.btnToggle.Size = New System.Drawing.Size(150, 36)
        Me.btnToggle.Text = "Disable / Enable"
        Me.btnToggle.UseVisualStyleBackColor = False
        Me.btnToggle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnToggle.AutoSize = True
        Me.btnToggle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnToggle.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnToggle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnToggle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(238, 242, 255)
        Me.btnToggle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(224, 231, 255)
        Me.btnToggle.Name = "btnToggle"
        Me.btnToggle.TabIndex = 4
        '
        'flowBar
        '
        Me.flowBar.AutoSize = True
        Me.flowBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.flowBar.Padding = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.flowBar.Name = "flowBar"
        Me.flowBar.TabIndex = 5
        Me.flowBar.Controls.Add(Me.btnAdd)
        Me.flowBar.Controls.Add(Me.btnReset)
        Me.flowBar.Controls.Add(Me.btnToggle)
        '
        'pnlCard
        '
        Me.pnlCard.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCard.Padding = New System.Windows.Forms.Padding(16, 14, 16, 16)
        Me.pnlCard.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.pnlCard.Name = "pnlCard"
        Me.pnlCard.TabIndex = 6
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
        Me.pnlAccentBar.TabIndex = 7
        '
        'pnlAccent
        '
        Me.pnlAccent.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAccent.Size = New System.Drawing.Size(900, 6)
        Me.pnlAccent.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.pnlAccent.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.pnlAccent.Name = "pnlAccent"
        Me.pnlAccent.TabIndex = 8
        Me.pnlAccent.Controls.Add(Me.pnlAccentBar)
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = False
        Me.lblTitle.Text = "User Management"
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Size = New System.Drawing.Size(900, 44)
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTitle.AutoEllipsis = True
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.TabIndex = 9
        '
        'UsersView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96!, 96!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Size = New System.Drawing.Size(1000, 600)
        Me.Controls.Add(Me.pnlCard)
        Me.Controls.Add(Me.pnlAccent)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "UsersView"
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
    Friend WithEvents btnAdd As RoundButton
    Friend WithEvents btnReset As RoundButton
    Friend WithEvents btnToggle As RoundButton
    Friend WithEvents pnlAccent As System.Windows.Forms.Panel
    Friend WithEvents pnlAccentBar As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label

End Class
