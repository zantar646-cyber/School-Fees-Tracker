<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserDashboard
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
        Me.tlpHead = New System.Windows.Forms.TableLayoutPanel()
        Me.flowHead = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.btnNewPayment = New RoundButton()
        Me.tlpCards = New System.Windows.Forms.TableLayoutPanel()
        Me.scToday = New StatCard()
        Me.scCount = New StatCard()
        Me.scOwing = New StatCard()
        Me.scProgress = New StatCard()
        Me.tlpBody = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlStudents = New Surface()
        Me.svStudents = New StudentsView()
        Me.pnlReceipts = New Surface()
        Me.dgvToday = New System.Windows.Forms.DataGridView()
        Me.lblNoReceipts = New System.Windows.Forms.Label()
        Me.flowReceipts = New System.Windows.Forms.FlowLayoutPanel()
        Me.lblReceiptsTitle = New System.Windows.Forms.Label()
        Me.btnReprint = New RoundButton()
        Me.pnlPay = New Surface()
        Me.tlpPay = New System.Windows.Forms.TableLayoutPanel()
        Me.lblPayTitle = New System.Windows.Forms.Label()
        Me.pnlStudentCard = New Surface()
        Me.lblStudent = New System.Windows.Forms.Label()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.tlpSums = New System.Windows.Forms.TableLayoutPanel()
        Me.msFee = New MiniStat()
        Me.msPaid = New MiniStat()
        Me.msBal = New MiniStat()
        Me.lblAmountCaption = New System.Windows.Forms.Label()
        Me.pnlAmount = New Surface()
        Me.lblCedi = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.flowFull = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnFull = New RoundButton()
        Me.btnTerms = New RoundButton()
        Me.lblAfter = New System.Windows.Forms.Label()
        Me.tlpMethod = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMethodCaption = New System.Windows.Forms.Label()
        Me.cboMethod = New System.Windows.Forms.ComboBox()
        Me.lblRefCaption = New System.Windows.Forms.Label()
        Me.txtRef = New System.Windows.Forms.TextBox()
        Me.tlpFooter = New System.Windows.Forms.TableLayoutPanel()
        Me.btnLast = New RoundButton()
        Me.btnCancelPay = New RoundButton()
        Me.btnRecord = New RoundButton()
        Me.tlpMain.SuspendLayout()
        Me.tlpHead.SuspendLayout()
        Me.flowHead.SuspendLayout()
        Me.tlpCards.SuspendLayout()
        Me.tlpBody.SuspendLayout()
        Me.pnlStudents.SuspendLayout()
        Me.pnlReceipts.SuspendLayout()
        Me.flowReceipts.SuspendLayout()
        Me.pnlPay.SuspendLayout()
        Me.tlpPay.SuspendLayout()
        Me.pnlStudentCard.SuspendLayout()
        Me.tlpSums.SuspendLayout()
        Me.pnlAmount.SuspendLayout()
        Me.flowFull.SuspendLayout()
        Me.tlpMethod.SuspendLayout()
        Me.tlpFooter.SuspendLayout()
        CType(Me.dgvToday, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Text = "Dashboard"
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 20!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(0, 0, 16, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.TabIndex = 1
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Text = ""
        Me.lblDate.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblDate.Margin = New System.Windows.Forms.Padding(0, 14, 0, 0)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.TabIndex = 2
        '
        'flowHead
        '
        Me.flowHead.AutoSize = False
        Me.flowHead.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowHead.WrapContents = False
        Me.flowHead.Controls.Add(Me.lblTitle)
        Me.flowHead.Controls.Add(Me.lblDate)
        Me.flowHead.Name = "flowHead"
        Me.flowHead.TabIndex = 3
        '
        'btnNewPayment
        '
        Me.btnNewPayment.BackColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnNewPayment.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnNewPayment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNewPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewPayment.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.btnNewPayment.Size = New System.Drawing.Size(180, 42)
        Me.btnNewPayment.Text = "+ Record Payment"
        Me.btnNewPayment.UseVisualStyleBackColor = False
        Me.btnNewPayment.Font = New System.Drawing.Font("Segoe UI Semibold", 10.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewPayment.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnNewPayment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(67, 56, 202)
        Me.btnNewPayment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(55, 48, 163)
        Me.btnNewPayment.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnNewPayment.Name = "btnNewPayment"
        Me.btnNewPayment.TabIndex = 4
        '
        'tlpHead
        '
        Me.tlpHead.ColumnCount = 2
        Me.tlpHead.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpHead.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpHead.RowCount = 1
        Me.tlpHead.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpHead.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpHead.Controls.Add(Me.flowHead, 0, 0)
        Me.tlpHead.Controls.Add(Me.btnNewPayment, 1, 0)
        Me.tlpHead.Name = "tlpHead"
        Me.tlpHead.TabIndex = 5
        '
        'scToday
        '
        Me.scToday.Caption = "Collected today"
        Me.scToday.IconName = "cash"
        Me.scToday.AccentColor = System.Drawing.Color.FromArgb(22, 163, 74)
        Me.scToday.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scToday.Margin = New System.Windows.Forms.Padding(0, 0, 12, 12)
        Me.scToday.Name = "scToday"
        Me.scToday.TabIndex = 6
        '
        'scCount
        '
        Me.scCount.Caption = "Payments today"
        Me.scCount.IconName = "receipt"
        Me.scCount.AccentColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.scCount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scCount.Margin = New System.Windows.Forms.Padding(0, 0, 12, 12)
        Me.scCount.Name = "scCount"
        Me.scCount.TabIndex = 7
        '
        'scOwing
        '
        Me.scOwing.Caption = "Students owing"
        Me.scOwing.IconName = "alert"
        Me.scOwing.AccentColor = System.Drawing.Color.FromArgb(220, 38, 38)
        Me.scOwing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scOwing.Margin = New System.Windows.Forms.Padding(0, 0, 12, 12)
        Me.scOwing.Name = "scOwing"
        Me.scOwing.TabIndex = 8
        '
        'scProgress
        '
        Me.scProgress.Caption = "Collection progress"
        Me.scProgress.IconName = "progress"
        Me.scProgress.AccentColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.scProgress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scProgress.Margin = New System.Windows.Forms.Padding(0, 0, 0, 12)
        Me.scProgress.Name = "scProgress"
        Me.scProgress.TabIndex = 9
        '
        'tlpCards
        '
        Me.tlpCards.ColumnCount = 4
        Me.tlpCards.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.tlpCards.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.tlpCards.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.tlpCards.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25!))
        Me.tlpCards.RowCount = 1
        Me.tlpCards.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpCards.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpCards.Controls.Add(Me.scToday, 0, 0)
        Me.tlpCards.Controls.Add(Me.scCount, 1, 0)
        Me.tlpCards.Controls.Add(Me.scOwing, 2, 0)
        Me.tlpCards.Controls.Add(Me.scProgress, 3, 0)
        Me.tlpCards.Name = "tlpCards"
        Me.tlpCards.TabIndex = 10
        '
        'svStudents
        '
        Me.svStudents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.svStudents.Name = "svStudents"
        Me.svStudents.TabIndex = 11
        '
        'pnlStudents
        '
        Me.pnlStudents.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.pnlStudents.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.pnlStudents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlStudents.Padding = New System.Windows.Forms.Padding(16, 14, 16, 16)
        Me.pnlStudents.Margin = New System.Windows.Forms.Padding(0, 0, 0, 12)
        Me.pnlStudents.Controls.Add(Me.svStudents)
        Me.pnlStudents.Name = "pnlStudents"
        Me.pnlStudents.TabIndex = 12
        '
        'dgvToday
        '
        Me.dgvToday.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvToday.AllowUserToAddRows = False
        Me.dgvToday.AllowUserToDeleteRows = False
        Me.dgvToday.ReadOnly = True
        Me.dgvToday.RowHeadersVisible = False
        Me.dgvToday.BackgroundColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.dgvToday.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvToday.MultiSelect = False
        Me.dgvToday.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvToday.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvToday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvToday.Name = "dgvToday"
        Me.dgvToday.TabIndex = 13
        '
        'lblNoReceipts
        '
        Me.lblNoReceipts.AutoSize = False
        Me.lblNoReceipts.Text = ""
        Me.lblNoReceipts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNoReceipts.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblNoReceipts.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.lblNoReceipts.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoReceipts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNoReceipts.Visible = False
        Me.lblNoReceipts.AutoEllipsis = True
        Me.lblNoReceipts.Name = "lblNoReceipts"
        Me.lblNoReceipts.TabIndex = 14
        '
        'lblReceiptsTitle
        '
        Me.lblReceiptsTitle.AutoSize = True
        Me.lblReceiptsTitle.Text = "Today's receipts"
        Me.lblReceiptsTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 11!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiptsTitle.Margin = New System.Windows.Forms.Padding(0, 8, 16, 0)
        Me.lblReceiptsTitle.Name = "lblReceiptsTitle"
        Me.lblReceiptsTitle.TabIndex = 15
        '
        'btnReprint
        '
        Me.btnReprint.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnReprint.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnReprint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReprint.Margin = New System.Windows.Forms.Padding(0, 2, 6, 2)
        Me.btnReprint.Size = New System.Drawing.Size(140, 36)
        Me.btnReprint.Text = "Reprint selected"
        Me.btnReprint.UseVisualStyleBackColor = False
        Me.btnReprint.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReprint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnReprint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(238, 242, 255)
        Me.btnReprint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(224, 231, 255)
        Me.btnReprint.AutoSize = True
        Me.btnReprint.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnReprint.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnReprint.Name = "btnReprint"
        Me.btnReprint.TabIndex = 16
        '
        'flowReceipts
        '
        Me.flowReceipts.AutoSize = True
        Me.flowReceipts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowReceipts.Dock = System.Windows.Forms.DockStyle.Top
        Me.flowReceipts.Padding = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.flowReceipts.Controls.Add(Me.lblReceiptsTitle)
        Me.flowReceipts.Controls.Add(Me.btnReprint)
        Me.flowReceipts.Name = "flowReceipts"
        Me.flowReceipts.TabIndex = 17
        '
        'pnlReceipts
        '
        Me.pnlReceipts.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.pnlReceipts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.pnlReceipts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlReceipts.Padding = New System.Windows.Forms.Padding(16, 14, 16, 16)
        Me.pnlReceipts.Margin = New System.Windows.Forms.Padding(0, 0, 0, 12)
        Me.pnlReceipts.Controls.Add(Me.dgvToday)
        Me.pnlReceipts.Controls.Add(Me.lblNoReceipts)
        Me.pnlReceipts.Controls.Add(Me.flowReceipts)
        Me.pnlReceipts.Name = "pnlReceipts"
        Me.pnlReceipts.TabIndex = 18
        '
        'tlpBody
        '
        Me.tlpBody.ColumnCount = 1
        Me.tlpBody.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpBody.RowCount = 2
        Me.tlpBody.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68!))
        Me.tlpBody.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32!))
        Me.tlpBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpBody.Controls.Add(Me.pnlStudents, 0, 0)
        Me.tlpBody.Controls.Add(Me.pnlReceipts, 0, 1)
        Me.tlpBody.Name = "tlpBody"
        Me.tlpBody.TabIndex = 19
        '
        'lblPayTitle
        '
        Me.lblPayTitle.AutoSize = True
        Me.lblPayTitle.Text = "Record payment"
        Me.lblPayTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 16!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPayTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPayTitle.Margin = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lblPayTitle.Name = "lblPayTitle"
        Me.lblPayTitle.TabIndex = 20
        '
        'lblStudent
        '
        Me.lblStudent.AutoSize = False
        Me.lblStudent.Text = "Select a student from the table"
        Me.lblStudent.Font = New System.Drawing.Font("Segoe UI Semibold", 12.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStudent.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblStudent.Size = New System.Drawing.Size(300, 26)
        Me.lblStudent.AutoEllipsis = True
        Me.lblStudent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblStudent.Name = "lblStudent"
        Me.lblStudent.TabIndex = 21
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = False
        Me.lblInfo.Text = ""
        Me.lblInfo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblInfo.Size = New System.Drawing.Size(300, 22)
        Me.lblInfo.AutoEllipsis = True
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.TabIndex = 22
        '
        'pnlStudentCard
        '
        Me.pnlStudentCard.Radius = 10
        Me.pnlStudentCard.ShowShadow = False
        Me.pnlStudentCard.BackColor = System.Drawing.Color.FromArgb(238, 242, 255)
        Me.pnlStudentCard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlStudentCard.Size = New System.Drawing.Size(300, 70)
        Me.pnlStudentCard.Padding = New System.Windows.Forms.Padding(16, 10, 16, 10)
        Me.pnlStudentCard.Margin = New System.Windows.Forms.Padding(0, 0, 0, 12)
        Me.pnlStudentCard.Controls.Add(Me.lblInfo)
        Me.pnlStudentCard.Controls.Add(Me.lblStudent)
        Me.pnlStudentCard.Name = "pnlStudentCard"
        Me.pnlStudentCard.TabIndex = 23
        '
        'msFee
        '
        Me.msFee.Caption = "Term fee"
        Me.msFee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.msFee.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.msFee.Name = "msFee"
        Me.msFee.TabIndex = 24
        '
        'msPaid
        '
        Me.msPaid.Caption = "Paid so far"
        Me.msPaid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.msPaid.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.msPaid.Name = "msPaid"
        Me.msPaid.TabIndex = 25
        '
        'msBal
        '
        Me.msBal.Caption = "Outstanding"
        Me.msBal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.msBal.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.msBal.Name = "msBal"
        Me.msBal.TabIndex = 26
        '
        'tlpSums
        '
        Me.tlpSums.ColumnCount = 3
        Me.tlpSums.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33!))
        Me.tlpSums.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33!))
        Me.tlpSums.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33!))
        Me.tlpSums.RowCount = 1
        Me.tlpSums.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpSums.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpSums.Size = New System.Drawing.Size(300, 60)
        Me.tlpSums.Margin = New System.Windows.Forms.Padding(0, 0, 0, 16)
        Me.tlpSums.Controls.Add(Me.msFee, 0, 0)
        Me.tlpSums.Controls.Add(Me.msPaid, 1, 0)
        Me.tlpSums.Controls.Add(Me.msBal, 2, 0)
        Me.tlpSums.Name = "tlpSums"
        Me.tlpSums.TabIndex = 27
        '
        'lblAmountCaption
        '
        Me.lblAmountCaption.AutoSize = True
        Me.lblAmountCaption.Text = "Amount to pay"
        Me.lblAmountCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmountCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAmountCaption.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.lblAmountCaption.Name = "lblAmountCaption"
        Me.lblAmountCaption.TabIndex = 28
        '
        'lblCedi
        '
        Me.lblCedi.AutoSize = False
        Me.lblCedi.Text = "GH₵"
        Me.lblCedi.Font = New System.Drawing.Font("Segoe UI Semibold", 11!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCedi.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblCedi.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblCedi.Size = New System.Drawing.Size(46, 40)
        Me.lblCedi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCedi.Name = "lblCedi"
        Me.lblCedi.TabIndex = 29
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Segoe UI Semibold", 16!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAmount.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59)
        Me.txtAmount.PlaceholderText = "0.00"
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.TabIndex = 30
        '
        'pnlAmount
        '
        Me.pnlAmount.Radius = 10
        Me.pnlAmount.ShowShadow = False
        Me.pnlAmount.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.pnlAmount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAmount.Size = New System.Drawing.Size(300, 54)
        Me.pnlAmount.Padding = New System.Windows.Forms.Padding(14, 11, 12, 8)
        Me.pnlAmount.Margin = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.pnlAmount.Controls.Add(Me.txtAmount)
        Me.pnlAmount.Controls.Add(Me.lblCedi)
        Me.pnlAmount.Name = "pnlAmount"
        Me.pnlAmount.TabIndex = 31
        '
        'btnFull
        '
        Me.btnFull.BackColor = System.Drawing.Color.FromArgb(238, 242, 255)
        Me.btnFull.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnFull.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFull.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFull.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnFull.Size = New System.Drawing.Size(150, 36)
        Me.btnFull.Text = "Pay full balance"
        Me.btnFull.UseVisualStyleBackColor = False
        Me.btnFull.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFull.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(199, 210, 254)
        Me.btnFull.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(224, 231, 255)
        Me.btnFull.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(199, 210, 254)
        Me.btnFull.AutoSize = True
        Me.btnFull.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnFull.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnFull.Name = "btnFull"
        Me.btnFull.TabIndex = 32
        '
        'btnTerms
        '
        Me.btnTerms.BackColor = System.Drawing.Color.FromArgb(238, 242, 255)
        Me.btnTerms.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnTerms.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTerms.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTerms.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnTerms.Size = New System.Drawing.Size(140, 36)
        Me.btnTerms.Text = "Several terms..."
        Me.btnTerms.UseVisualStyleBackColor = False
        Me.btnTerms.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTerms.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(199, 210, 254)
        Me.btnTerms.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(224, 231, 255)
        Me.btnTerms.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(199, 210, 254)
        Me.btnTerms.AutoSize = True
        Me.btnTerms.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
        Me.btnTerms.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.btnTerms.Name = "btnTerms"
        Me.btnTerms.TabIndex = 33
        '
        'flowFull
        '
        Me.flowFull.AutoSize = True
        Me.flowFull.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowFull.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowFull.WrapContents = False
        Me.flowFull.Margin = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.flowFull.Controls.Add(Me.btnFull)
        Me.flowFull.Controls.Add(Me.btnTerms)
        Me.flowFull.Name = "flowFull"
        Me.flowFull.TabIndex = 34
        '
        'lblAfter
        '
        Me.lblAfter.AutoSize = False
        Me.lblAfter.Text = ""
        Me.lblAfter.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
        Me.lblAfter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAfter.Size = New System.Drawing.Size(300, 24)
        Me.lblAfter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAfter.Margin = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.lblAfter.Name = "lblAfter"
        Me.lblAfter.TabIndex = 35
        '
        'lblMethodCaption
        '
        Me.lblMethodCaption.AutoSize = True
        Me.lblMethodCaption.Text = "Payment method"
        Me.lblMethodCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMethodCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMethodCaption.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.lblMethodCaption.Name = "lblMethodCaption"
        Me.lblMethodCaption.TabIndex = 36
        '
        'cboMethod
        '
        Me.cboMethod.Size = New System.Drawing.Size(200, 28)
        Me.cboMethod.Margin = New System.Windows.Forms.Padding(2, 2, 12, 3)
        Me.cboMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboMethod.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.cboMethod.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboMethod.Items.AddRange(New Object() {"Mobile Money", "Cash", "Bank"})
        Me.cboMethod.Name = "cboMethod"
        Me.cboMethod.TabIndex = 37
        '
        'lblRefCaption
        '
        Me.lblRefCaption.AutoSize = True
        Me.lblRefCaption.Text = "Reference (optional)"
        Me.lblRefCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRefCaption.Margin = New System.Windows.Forms.Padding(0, 0, 0, 6)
        Me.lblRefCaption.Name = "lblRefCaption"
        Me.lblRefCaption.TabIndex = 38
        '
        'txtRef
        '
        Me.txtRef.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtRef.Size = New System.Drawing.Size(200, 28)
        Me.txtRef.Margin = New System.Windows.Forms.Padding(2, 2, 2, 3)
        Me.txtRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRef.PlaceholderText = "MoMo or bank reference"
        Me.txtRef.Name = "txtRef"
        Me.txtRef.TabIndex = 39
        '
        'tlpMethod
        '
        Me.tlpMethod.ColumnCount = 2
        Me.tlpMethod.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46!))
        Me.tlpMethod.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54!))
        Me.tlpMethod.RowCount = 2
        Me.tlpMethod.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpMethod.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpMethod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMethod.Size = New System.Drawing.Size(300, 64)
        Me.tlpMethod.Margin = New System.Windows.Forms.Padding(0, 0, 0, 18)
        Me.tlpMethod.Controls.Add(Me.lblMethodCaption, 0, 0)
        Me.tlpMethod.Controls.Add(Me.lblRefCaption, 1, 0)
        Me.tlpMethod.Controls.Add(Me.cboMethod, 0, 1)
        Me.tlpMethod.Controls.Add(Me.txtRef, 1, 1)
        Me.tlpMethod.Name = "tlpMethod"
        Me.tlpMethod.TabIndex = 40
        '
        'btnLast
        '
        Me.btnLast.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnLast.ForeColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnLast.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLast.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnLast.Size = New System.Drawing.Size(150, 44)
        Me.btnLast.Text = "Print last receipt"
        Me.btnLast.UseVisualStyleBackColor = False
        Me.btnLast.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLast.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnLast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(238, 242, 255)
        Me.btnLast.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(224, 231, 255)
        Me.btnLast.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnLast.Name = "btnLast"
        Me.btnLast.TabIndex = 41
        '
        'btnCancelPay
        '
        Me.btnCancelPay.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnCancelPay.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105)
        Me.btnCancelPay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelPay.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnCancelPay.Size = New System.Drawing.Size(90, 44)
        Me.btnCancelPay.Text = "Cancel"
        Me.btnCancelPay.UseVisualStyleBackColor = False
        Me.btnCancelPay.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelPay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
        Me.btnCancelPay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(241, 245, 249)
        Me.btnCancelPay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(226, 232, 240)
        Me.btnCancelPay.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnCancelPay.Name = "btnCancelPay"
        Me.btnCancelPay.TabIndex = 42
        '
        'btnRecord
        '
        Me.btnRecord.BackColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnRecord.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.btnRecord.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRecord.Margin = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.btnRecord.Size = New System.Drawing.Size(170, 44)
        Me.btnRecord.Text = "Record payment"
        Me.btnRecord.UseVisualStyleBackColor = False
        Me.btnRecord.Font = New System.Drawing.Font("Segoe UI Semibold", 11!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecord.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(79, 70, 229)
        Me.btnRecord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(67, 56, 202)
        Me.btnRecord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(55, 48, 163)
        Me.btnRecord.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnRecord.Name = "btnRecord"
        Me.btnRecord.TabIndex = 43
        '
        'tlpFooter
        '
        Me.tlpFooter.ColumnCount = 4
        Me.tlpFooter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpFooter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpFooter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpFooter.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpFooter.RowCount = 1
        Me.tlpFooter.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpFooter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpFooter.Size = New System.Drawing.Size(300, 48)
        Me.tlpFooter.Controls.Add(Me.btnLast, 0, 0)
        Me.tlpFooter.Controls.Add(Me.btnCancelPay, 2, 0)
        Me.tlpFooter.Controls.Add(Me.btnRecord, 3, 0)
        Me.tlpFooter.Name = "tlpFooter"
        Me.tlpFooter.TabIndex = 44
        '
        'tlpPay
        '
        Me.tlpPay.ColumnCount = 1
        Me.tlpPay.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpPay.RowCount = 9
        Me.tlpPay.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpPay.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82!))
        Me.tlpPay.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76!))
        Me.tlpPay.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpPay.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64!))
        Me.tlpPay.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpPay.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34!))
        Me.tlpPay.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize))
        Me.tlpPay.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48!))
        Me.tlpPay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpPay.Controls.Add(Me.lblPayTitle, 0, 0)
        Me.tlpPay.Controls.Add(Me.pnlStudentCard, 0, 1)
        Me.tlpPay.Controls.Add(Me.tlpSums, 0, 2)
        Me.tlpPay.Controls.Add(Me.lblAmountCaption, 0, 3)
        Me.tlpPay.Controls.Add(Me.pnlAmount, 0, 4)
        Me.tlpPay.Controls.Add(Me.flowFull, 0, 5)
        Me.tlpPay.Controls.Add(Me.lblAfter, 0, 6)
        Me.tlpPay.Controls.Add(Me.tlpMethod, 0, 7)
        Me.tlpPay.Controls.Add(Me.tlpFooter, 0, 8)
        Me.tlpPay.Name = "tlpPay"
        Me.tlpPay.TabIndex = 45
        '
        'pnlPay
        '
        Me.pnlPay.Radius = 0
        Me.pnlPay.ShowShadow = False
        Me.pnlPay.BorderColor = System.Drawing.Color.Transparent
        Me.pnlPay.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Me.pnlPay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPay.Padding = New System.Windows.Forms.Padding(0, 0, 0, 0)
        Me.pnlPay.Visible = False
        Me.pnlPay.Controls.Add(Me.tlpPay)
        Me.pnlPay.Name = "pnlPay"
        Me.pnlPay.TabIndex = 46
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpMain.RowCount = 3
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 124!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100!))
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Controls.Add(Me.tlpHead, 0, 0)
        Me.tlpMain.Controls.Add(Me.tlpCards, 0, 1)
        Me.tlpMain.Controls.Add(Me.tlpBody, 0, 2)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.TabIndex = 47
        '
        'UserDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96!, 96!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
        Me.Font = New System.Drawing.Font("Segoe UI", 10!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Size = New System.Drawing.Size(1100, 700)
        Me.Controls.Add(Me.tlpMain)
        Me.Controls.Add(Me.pnlPay)
        Me.Name = "UserDashboard"
        CType(Me.dgvToday, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpFooter.ResumeLayout(False)
        Me.tlpMethod.ResumeLayout(False)
        Me.flowFull.ResumeLayout(False)
        Me.pnlAmount.ResumeLayout(False)
        Me.tlpSums.ResumeLayout(False)
        Me.pnlStudentCard.ResumeLayout(False)
        Me.tlpPay.ResumeLayout(False)
        Me.pnlPay.ResumeLayout(False)
        Me.flowReceipts.ResumeLayout(False)
        Me.pnlReceipts.ResumeLayout(False)
        Me.pnlStudents.ResumeLayout(False)
        Me.tlpBody.ResumeLayout(False)
        Me.tlpCards.ResumeLayout(False)
        Me.flowHead.ResumeLayout(False)
        Me.tlpHead.ResumeLayout(False)
        Me.tlpMain.ResumeLayout(False)
        Me.flowReceipts.PerformLayout()
        Me.tlpMain.PerformLayout()
        Me.tlpHead.PerformLayout()
        Me.tlpCards.PerformLayout()
        Me.tlpBody.PerformLayout()
        Me.tlpPay.PerformLayout()
        Me.tlpSums.PerformLayout()
        Me.tlpMethod.PerformLayout()
        Me.tlpFooter.PerformLayout()
        Me.flowFull.PerformLayout()
        Me.flowHead.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpHead As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents flowHead As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents btnNewPayment As RoundButton
    Friend WithEvents tlpCards As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents scToday As StatCard
    Friend WithEvents scCount As StatCard
    Friend WithEvents scOwing As StatCard
    Friend WithEvents scProgress As StatCard
    Friend WithEvents tlpBody As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlStudents As Surface
    Friend WithEvents svStudents As StudentsView
    Friend WithEvents pnlReceipts As Surface
    Friend WithEvents dgvToday As System.Windows.Forms.DataGridView
    Friend WithEvents lblNoReceipts As System.Windows.Forms.Label
    Friend WithEvents flowReceipts As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblReceiptsTitle As System.Windows.Forms.Label
    Friend WithEvents btnReprint As RoundButton
    Friend WithEvents pnlPay As Surface
    Friend WithEvents tlpPay As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblPayTitle As System.Windows.Forms.Label
    Friend WithEvents pnlStudentCard As Surface
    Friend WithEvents lblStudent As System.Windows.Forms.Label
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents tlpSums As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents msFee As MiniStat
    Friend WithEvents msPaid As MiniStat
    Friend WithEvents msBal As MiniStat
    Friend WithEvents lblAmountCaption As System.Windows.Forms.Label
    Friend WithEvents pnlAmount As Surface
    Friend WithEvents lblCedi As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents flowFull As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnFull As RoundButton
    Friend WithEvents btnTerms As RoundButton
    Friend WithEvents lblAfter As System.Windows.Forms.Label
    Friend WithEvents tlpMethod As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblMethodCaption As System.Windows.Forms.Label
    Friend WithEvents cboMethod As System.Windows.Forms.ComboBox
    Friend WithEvents lblRefCaption As System.Windows.Forms.Label
    Friend WithEvents txtRef As System.Windows.Forms.TextBox
    Friend WithEvents tlpFooter As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnLast As RoundButton
    Friend WithEvents btnCancelPay As RoundButton
    Friend WithEvents btnRecord As RoundButton

End Class
