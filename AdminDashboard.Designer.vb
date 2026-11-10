<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminDashboard
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
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.flowHead = New System.Windows.Forms.FlowLayoutPanel()
        Me.tlpHead = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblTerm = New System.Windows.Forms.Label()
        Me.cboTerm = New System.Windows.Forms.ComboBox()
        Me.tlpCards = New System.Windows.Forms.TableLayoutPanel()
        Me.scStudents = New StatCard()
        Me.scExpected = New StatCard()
        Me.scCollected = New StatCard()
        Me.scOutstanding = New StatCard()
        Me.tlpBars = New System.Windows.Forms.TableLayoutPanel()
        Me.bcClass = New BarCard()
        Me.bcMethod = New BarCard()
        Me.bcStatus = New BarCard()
        Me.tlpLower = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlGrid = New Surface()
        Me.svStudents = New StudentsView()
        Me.pnlActivity = New Surface()
        Me.dgvActivity = New System.Windows.Forms.DataGridView()
        Me.lblActivityTitle = New System.Windows.Forms.Label()
        Me.tlpMain.SuspendLayout()
        Me.flowHead.SuspendLayout()
        Me.tlpHead.SuspendLayout()
        Me.tlpCards.SuspendLayout()
        Me.tlpBars.SuspendLayout()
        Me.tlpLower.SuspendLayout()
        Me.pnlGrid.SuspendLayout()
        Me.pnlActivity.SuspendLayout()
        CType(Me.dgvActivity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Text = "Super Admin Dashboard"
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(0)
        Me.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.TabIndex = 0
        '
        'lblTerm
        '
        Me.lblTerm.AutoSize = True
        Me.lblTerm.Text = "Term"
        Me.lblTerm.Margin = New System.Windows.Forms.Padding(0, 5, 8, 0)
        Me.lblTerm.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblTerm.Name = "lblTerm"
        Me.lblTerm.TabIndex = 1
        '
        'cboTerm
        '
        Me.cboTerm.Size = New System.Drawing.Size(150, 28)
        Me.cboTerm.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.cboTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTerm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTerm.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.cboTerm.Items.AddRange(New Object() {"All terms", "Term 1", "Term 2", "Term 3"})
        Me.cboTerm.Name = "cboTerm"
        Me.cboTerm.TabIndex = 2
        '
        'flowHead
        '
        Me.flowHead.AutoSize = True
        Me.flowHead.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.flowHead.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowHead.Margin = New System.Windows.Forms.Padding(0)
        Me.flowHead.WrapContents = False
        Me.flowHead.Name = "flowHead"
        Me.flowHead.TabIndex = 3
        Me.flowHead.Controls.Add(Me.lblTerm)
        Me.flowHead.Controls.Add(Me.cboTerm)
        '
        '
        'tlpHead
        '
        Me.tlpHead.ColumnCount = 2
        Me.tlpHead.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpHead.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpHead.RowCount = 1
        Me.tlpHead.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpHead.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpHead.Name = "tlpHead"
        Me.tlpHead.TabIndex = 30
        Me.tlpHead.Controls.Add(Me.lblTitle, 0, 0)
        Me.tlpHead.Controls.Add(Me.flowHead, 1, 0)
        'scStudents
        '
        Me.scStudents.Caption = "Students"
        Me.scStudents.IconName = "users"
        Me.scStudents.AccentColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.scStudents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scStudents.Name = "scStudents"
        Me.scStudents.TabIndex = 4
        '
        'scExpected
        '
        Me.scExpected.Caption = "Expected"
        Me.scExpected.IconName = "receipt"
        Me.scExpected.AccentColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.scExpected.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scExpected.Name = "scExpected"
        Me.scExpected.TabIndex = 5
        '
        'scCollected
        '
        Me.scCollected.Caption = "Collected"
        Me.scCollected.IconName = "cash"
        Me.scCollected.AccentColor = System.Drawing.Color.FromArgb(22, 163, 74)
        Me.scCollected.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scCollected.Name = "scCollected"
        Me.scCollected.TabIndex = 6
        '
        'scOutstanding
        '
        Me.scOutstanding.Caption = "Outstanding"
        Me.scOutstanding.IconName = "alert"
        Me.scOutstanding.AccentColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.scOutstanding.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scOutstanding.Margin = New System.Windows.Forms.Padding(0, 0, 0, 12)
        Me.scOutstanding.Name = "scOutstanding"
        Me.scOutstanding.TabIndex = 7
        '
        'tlpCards
        '
        Me.tlpCards.ColumnCount = 4
        Me.tlpCards.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpCards.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpCards.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpCards.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpCards.RowCount = 1
        Me.tlpCards.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpCards.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpCards.Name = "tlpCards"
        Me.tlpCards.TabIndex = 8
        Me.tlpCards.Controls.Add(Me.scStudents, 0, 0)
        Me.tlpCards.Controls.Add(Me.scExpected, 1, 0)
        Me.tlpCards.Controls.Add(Me.scCollected, 2, 0)
        Me.tlpCards.Controls.Add(Me.scOutstanding, 3, 0)
        '
        'bcClass
        '
        Me.bcClass.Title = "Collection by class"
        Me.bcClass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bcClass.Name = "bcClass"
        Me.bcClass.TabIndex = 9
        '
        'bcMethod
        '
        Me.bcMethod.Title = "Payment methods"
        Me.bcMethod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bcMethod.Name = "bcMethod"
        Me.bcMethod.TabIndex = 10
        '
        'bcStatus
        '
        Me.bcStatus.Title = "Status breakdown"
        Me.bcStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bcStatus.Margin = New System.Windows.Forms.Padding(0, 0, 0, 12)
        Me.bcStatus.Name = "bcStatus"
        Me.bcStatus.TabIndex = 11
        '
        'tlpBars
        '
        Me.tlpBars.ColumnCount = 3
        Me.tlpBars.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.333333333333336!))
        Me.tlpBars.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.333333333333336!))
        Me.tlpBars.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.333333333333336!))
        Me.tlpBars.RowCount = 1
        Me.tlpBars.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpBars.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpBars.Name = "tlpBars"
        Me.tlpBars.TabIndex = 12
        Me.tlpBars.Controls.Add(Me.bcClass, 0, 0)
        Me.tlpBars.Controls.Add(Me.bcMethod, 1, 0)
        Me.tlpBars.Controls.Add(Me.bcStatus, 2, 0)
        '
        'svStudents
        '
        Me.svStudents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.svStudents.Name = "svStudents"
        Me.svStudents.TabIndex = 13
        '
        'pnlGrid
        '
        Me.pnlGrid.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGrid.Padding = New System.Windows.Forms.Padding(16, 14, 16, 16)
        Me.pnlGrid.Margin = New System.Windows.Forms.Padding(0, 0, 12, 12)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.TabIndex = 14
        Me.pnlGrid.Controls.Add(Me.svStudents)
        '
        'dgvActivity
        '
        Me.dgvActivity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvActivity.AllowUserToAddRows = False
        Me.dgvActivity.AllowUserToDeleteRows = False
        Me.dgvActivity.ReadOnly = True
        Me.dgvActivity.RowHeadersVisible = False
        Me.dgvActivity.BackgroundColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.dgvActivity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvActivity.MultiSelect = False
        Me.dgvActivity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvActivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvActivity.Name = "dgvActivity"
        Me.dgvActivity.TabIndex = 15
        '
        'lblActivityTitle
        '
        Me.lblActivityTitle.AutoSize = False
        Me.lblActivityTitle.Text = "Recent activity"
        Me.lblActivityTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivityTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblActivityTitle.Size = New System.Drawing.Size(260, 32)
        Me.lblActivityTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblActivityTitle.AutoEllipsis = True
        Me.lblActivityTitle.Name = "lblActivityTitle"
        Me.lblActivityTitle.TabIndex = 16
        '
        'pnlActivity
        '
        Me.pnlActivity.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.pnlActivity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.pnlActivity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlActivity.Padding = New System.Windows.Forms.Padding(16, 14, 16, 16)
        Me.pnlActivity.Margin = New System.Windows.Forms.Padding(0, 0, 0, 12)
        Me.pnlActivity.Name = "pnlActivity"
        Me.pnlActivity.TabIndex = 17
        Me.pnlActivity.Controls.Add(Me.dgvActivity)
        Me.pnlActivity.Controls.Add(Me.lblActivityTitle)
        '
        'tlpLower
        '
        Me.tlpLower.ColumnCount = 2
        Me.tlpLower.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68!))
        Me.tlpLower.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32!))
        Me.tlpLower.RowCount = 1
        Me.tlpLower.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpLower.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpLower.Name = "tlpLower"
        Me.tlpLower.TabIndex = 18
        Me.tlpLower.Controls.Add(Me.pnlGrid, 0, 0)
        Me.tlpLower.Controls.Add(Me.pnlActivity, 1, 0)
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpMain.RowCount = 4
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 124!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 158!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Padding = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.TabIndex = 19
        Me.tlpMain.Controls.Add(Me.tlpHead, 0, 0)
        Me.tlpMain.Controls.Add(Me.tlpCards, 0, 1)
        Me.tlpMain.Controls.Add(Me.tlpBars, 0, 2)
        Me.tlpMain.Controls.Add(Me.tlpLower, 0, 3)
        '
        'AdminDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96!, 96!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Size = New System.Drawing.Size(1100, 700)
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "AdminDashboard"
        Me.pnlActivity.ResumeLayout(False)
        Me.pnlGrid.ResumeLayout(False)
        Me.tlpLower.ResumeLayout(False)
        Me.tlpLower.PerformLayout()
        Me.tlpBars.ResumeLayout(False)
        Me.tlpBars.PerformLayout()
        Me.tlpCards.ResumeLayout(False)
        Me.tlpCards.PerformLayout()
        Me.flowHead.ResumeLayout(False)
        Me.flowHead.PerformLayout()
        Me.tlpHead.ResumeLayout(False)
        Me.tlpHead.PerformLayout()
        Me.flowHead.PerformLayout()
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        CType(Me.dgvActivity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents flowHead As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents tlpHead As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblTerm As System.Windows.Forms.Label
    Friend WithEvents cboTerm As System.Windows.Forms.ComboBox
    Friend WithEvents tlpCards As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents scStudents As StatCard
    Friend WithEvents scExpected As StatCard
    Friend WithEvents scCollected As StatCard
    Friend WithEvents scOutstanding As StatCard
    Friend WithEvents tlpBars As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents bcClass As BarCard
    Friend WithEvents bcMethod As BarCard
    Friend WithEvents bcStatus As BarCard
    Friend WithEvents tlpLower As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlGrid As Surface
    Friend WithEvents svStudents As StudentsView
    Friend WithEvents pnlActivity As Surface
    Friend WithEvents dgvActivity As System.Windows.Forms.DataGridView
    Friend WithEvents lblActivityTitle As System.Windows.Forms.Label

End Class
