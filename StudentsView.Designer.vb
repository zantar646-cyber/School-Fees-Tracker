<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StudentsView
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
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.lblEmpty = New System.Windows.Forms.Label()
        Me.sbTotals = New SummaryBar()
        Me.flowActions = New System.Windows.Forms.FlowLayoutPanel()
        Me.flowData = New System.Windows.Forms.FlowLayoutPanel()
        Me.tlpActions = New System.Windows.Forms.TableLayoutPanel()
        Me.flowBar = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cboClass = New System.Windows.Forms.ComboBox()
        Me.cboTerm = New System.Windows.Forms.ComboBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.btnRegister = New RoundButton()
        Me.btnEdit = New RoundButton()
        Me.btnDelete = New RoundButton()
        Me.btnStatement = New RoundButton()
        Me.btnImport = New RoundButton()
        Me.btnExport = New RoundButton()
        Me.flowBar.SuspendLayout()
        Me.flowActions.SuspendLayout()
        Me.flowData.SuspendLayout()
        Me.tlpActions.SuspendLayout()
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
        'sbTotals
        '
        Me.sbTotals.Name = "sbTotals"
        Me.sbTotals.TabIndex = 2
        '
        'txtSearch
        '
        Me.txtSearch.Size = New System.Drawing.Size(260, 27)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(2, 3, 8, 3)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.PlaceholderText = "Search name or ID"
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.TabIndex = 3
        '
        'cboClass
        '
        Me.cboClass.Size = New System.Drawing.Size(140, 27)
        Me.cboClass.Margin = New System.Windows.Forms.Padding(2, 3, 8, 3)
        Me.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboClass.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.cboClass.Items.AddRange(New Object() {"All classes", "JHS 1", "JHS 2", "JHS 3"})
        Me.cboClass.Name = "cboClass"
        Me.cboClass.TabIndex = 4
        '
        'cboTerm
        '
        Me.cboTerm.Size = New System.Drawing.Size(140, 27)
        Me.cboTerm.Margin = New System.Windows.Forms.Padding(2, 3, 8, 3)
        Me.cboTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTerm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTerm.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.cboTerm.Items.AddRange(New Object() {"All terms", "Term 1", "Term 2", "Term 3"})
        Me.cboTerm.Name = "cboTerm"
        Me.cboTerm.TabIndex = 5
        '
        'cboStatus
        '
        Me.cboStatus.Size = New System.Drawing.Size(150, 27)
        Me.cboStatus.Margin = New System.Windows.Forms.Padding(2, 3, 8, 3)
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStatus.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.cboStatus.Items.AddRange(New Object() {"All statuses", "With arrears", "Owing", "Part paid", "Paid in full"})
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.TabIndex = 6
        '
        'btnRegister
        '
        Me.btnRegister.BackColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnRegister.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegister.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnRegister.Size = New System.Drawing.Size(110, 36)
        Me.btnRegister.Text = "Register"
        Me.btnRegister.UseVisualStyleBackColor = False
        Me.btnRegister.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Me.btnRegister.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnRegister.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(67, 56, 202)
        Me.btnRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(55, 48, 163)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.TabIndex = 7
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnEdit.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnEdit.Size = New System.Drawing.Size(80, 36)
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Me.btnEdit.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(238, 242, 255)
        Me.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(224, 231, 255)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.TabIndex = 8
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnDelete.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnDelete.Size = New System.Drawing.Size(90, 36)
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Me.btnDelete.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(252, 165, 165)
        Me.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(254, 242, 242)
        Me.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(254, 226, 226)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.TabIndex = 9
        '
        'btnStatement
        '
        Me.btnStatement.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnStatement.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnStatement.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStatement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStatement.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnStatement.Size = New System.Drawing.Size(110, 36)
        Me.btnStatement.Text = "Statement"
        Me.btnStatement.UseVisualStyleBackColor = False
        Me.btnStatement.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Me.btnStatement.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnStatement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnStatement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(238, 242, 255)
        Me.btnStatement.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(224, 231, 255)
        Me.btnStatement.Name = "btnStatement"
        Me.btnStatement.TabIndex = 10
        '
        'btnImport
        '
        Me.btnImport.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnImport.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnImport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImport.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnImport.Size = New System.Drawing.Size(120, 36)
        Me.btnImport.Text = "Import CSV"
        Me.btnImport.UseVisualStyleBackColor = False
        Me.btnImport.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Me.btnImport.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnImport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnImport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(238, 242, 255)
        Me.btnImport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(224, 231, 255)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.TabIndex = 11
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnExport.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.btnExport.Size = New System.Drawing.Size(120, 36)
        Me.btnExport.Text = "Export CSV"
        Me.btnExport.UseVisualStyleBackColor = False
        Me.btnExport.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Me.btnExport.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(238, 242, 255)
        Me.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(224, 231, 255)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.TabIndex = 12
        '
        'flowBar
        '
        Me.flowBar.AutoSize = True
        Me.flowBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.flowBar.Padding = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.flowBar.WrapContents = False
        Me.flowBar.Name = "flowBar"
        Me.flowBar.TabIndex = 13
        Me.flowBar.Controls.Add(Me.txtSearch)
        Me.flowBar.Controls.Add(Me.cboClass)
        Me.flowBar.Controls.Add(Me.cboTerm)
        Me.flowBar.Controls.Add(Me.cboStatus)
        '
        '
        'flowActions
        '
        Me.flowActions.AutoSize = True
        Me.flowActions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowActions.WrapContents = False
        Me.flowActions.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.flowActions.Margin = New System.Windows.Forms.Padding(0)
        Me.flowActions.Name = "flowActions"
        Me.flowActions.TabIndex = 14
        Me.flowActions.Controls.Add(Me.btnRegister)
        Me.flowActions.Controls.Add(Me.btnEdit)
        Me.flowActions.Controls.Add(Me.btnStatement)
        Me.flowActions.Controls.Add(Me.btnDelete)
        '
        'flowData
        '
        Me.flowData.AutoSize = True
        Me.flowData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowData.WrapContents = False
        Me.flowData.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.flowData.Margin = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.flowData.Name = "flowData"
        Me.flowData.TabIndex = 15
        Me.flowData.Controls.Add(Me.btnImport)
        Me.flowData.Controls.Add(Me.btnExport)
        '
        'tlpActions
        '
        Me.tlpActions.AutoSize = True
        Me.tlpActions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpActions.ColumnCount = 2
        Me.tlpActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpActions.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpActions.RowCount = 1
        Me.tlpActions.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpActions.Dock = System.Windows.Forms.DockStyle.Top
        Me.tlpActions.Padding = New System.Windows.Forms.Padding(0, 0, 0, 12)
        Me.tlpActions.Name = "tlpActions"
        Me.tlpActions.TabIndex = 16
        Me.tlpActions.Controls.Add(Me.flowActions, 0, 0)
        Me.tlpActions.Controls.Add(Me.flowData, 1, 0)
        'StudentsView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96!, 96!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Size = New System.Drawing.Size(900, 500)
        Me.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.lblEmpty)
        Me.Controls.Add(Me.sbTotals)
        Me.Controls.Add(Me.tlpActions)
        Me.Controls.Add(Me.flowBar)
        Me.Name = "StudentsView"
        Me.flowActions.ResumeLayout(False)
        Me.flowActions.PerformLayout()
        Me.flowData.ResumeLayout(False)
        Me.flowData.PerformLayout()
        Me.tlpActions.ResumeLayout(False)
        Me.tlpActions.PerformLayout()
        Me.flowBar.ResumeLayout(False)
        Me.flowBar.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents lblEmpty As System.Windows.Forms.Label
    Friend WithEvents sbTotals As SummaryBar
    Friend WithEvents flowActions As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents flowData As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tlpActions As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents flowBar As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cboClass As System.Windows.Forms.ComboBox
    Friend WithEvents cboTerm As System.Windows.Forms.ComboBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnRegister As RoundButton
    Friend WithEvents btnEdit As RoundButton
    Friend WithEvents btnDelete As RoundButton
    Friend WithEvents btnStatement As RoundButton
    Friend WithEvents btnImport As RoundButton
    Friend WithEvents btnExport As RoundButton

End Class
