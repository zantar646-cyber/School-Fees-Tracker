Imports System.ComponentModel

Public Class StudentsView
    Public Event SelectedChanged(id As String)
    Public Event DataChanged()
    Private dt As New DataTable
    Private ready As Boolean

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property TermFilter As String
        Get
            Return cboTerm.SelectedItem.ToString()
        End Get
        Set(value As String)
            cboTerm.SelectedItem = value
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property ShowTermFilter As Boolean
        Get
            Return cboTerm.Visible
        End Get
        Set(value As Boolean)
            cboTerm.Visible = value
        End Set
    End Property

    Public ReadOnly Property SelectedId As String
        Get
            If dgv.CurrentRow Is Nothing Then Return Nothing
            Return dgv.CurrentRow.Cells("Id").Value.ToString()
        End Get
    End Property

    Private compact As Boolean

    ' Compact mode (used on the general user dashboard): fewer columns, two-row toolbar, short totals
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property CompactColumns As Boolean
        Get
            Return compact
        End Get
        Set(value As Boolean)
            compact = value
            sbTotals.Height = If(value, Theme.S(46), Theme.S(54))
            tlpActions.Padding = New Padding(0, 0, 0, If(value, 8, 12))
            btnImport.Visible = Not value
            btnExport.Visible = Not value
            ApplyColumnVisibility()
            Theme.FitColumns(dgv)
            ApplyFilter()
        End Set
    End Property

    ' Less important columns step aside as the window narrows, so the important ones always fit without sideways scrolling
    Private Sub ApplyColumnVisibility()
        If dgv.Columns.Count = 0 Then Return
        Dim w As Integer = dgv.Width
        SetVisible("Term", Not compact)
        SetVisible("Fee", Not compact AndAlso w >= Theme.S(760))
        SetVisible("Paid", Not compact AndAlso w >= Theme.S(760))
        SetVisible("Phone", Not compact AndAlso w >= Theme.S(930))
    End Sub

    Private Sub SetVisible(name As String, show As Boolean)
        If dgv.Columns.Contains(name) AndAlso dgv.Columns(name).Visible <> show Then dgv.Columns(name).Visible = show
    End Sub

    Public Sub New()
        InitializeComponent()
        Theme.Polish(Me)
        Theme.StyleGrid(dgv)
        cboClass.SelectedIndex = 0
        cboTerm.SelectedIndex = 0
        cboStatus.SelectedIndex = 0
        AddHandler dgv.SizeChanged, Sub(s, e) ApplyColumnVisibility()
    End Sub

    Private Sub StudentsView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If DesignMode Then Return
        btnDelete.Visible = Session.IsAdmin
        lblEmpty.BringToFront()
        Reload()
    End Sub

    Public Sub Reload()
        Dim keep = SelectedId
        ready = False
        dt = Db.Query(Db.StudentSql & " ORDER BY Id")
        dgv.DataSource = New DataView(dt)
        If dgv.Columns.Count > 0 Then
            dgv.Columns("Id").FillWeight = 50
            dgv.Columns("Class").FillWeight = 55
            dgv.Columns("Term").FillWeight = 55
            dgv.Columns("Phone").FillWeight = 95
            dgv.Columns("Phone").HeaderText = "Guardian phone"
            dgv.Columns("Guardian").Visible = False
            For Each c In {"Fee", "Paid", "Balance"}
                dgv.Columns(c).DefaultCellStyle.Format = "N2"
                dgv.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgv.Columns(c).FillWeight = 80
            Next
            dgv.Columns("Name").FillWeight = 190
            dgv.Columns("Status").FillWeight = 110
        End If
        ApplyColumnVisibility()
        Theme.FitColumns(dgv, Theme.S(200))
        ApplyFilter()
        ready = True
        If keep IsNot Nothing Then SelectById(keep)
        RaiseEvent SelectedChanged(SelectedId)
    End Sub

    Private Sub SelectById(id As String)
        For Each r As DataGridViewRow In dgv.Rows
            If r.Cells("Id").Value.ToString() = id Then
                dgv.CurrentCell = r.Cells("Name")
                Return
            End If
        Next
    End Sub

    Private Sub Filters_Changed(sender As Object, e As EventArgs) Handles txtSearch.TextChanged, cboClass.SelectedIndexChanged, cboTerm.SelectedIndexChanged, cboStatus.SelectedIndexChanged
        ApplyFilter()
    End Sub

    Private Sub ApplyFilter()
        Dim dv = TryCast(dgv.DataSource, DataView)
        If dv Is Nothing Then Return
        Dim f As New List(Of String)
        Dim q = txtSearch.Text.Trim()
        If q <> "" Then f.Add("(Name LIKE '%" & Theme.Esc(q) & "%' OR Id LIKE '%" & Theme.Esc(q) & "%')")
        If cboClass.SelectedIndex > 0 Then f.Add("Class = '" & cboClass.SelectedItem.ToString() & "'")
        If cboTerm.SelectedIndex > 0 Then f.Add("Term = '" & cboTerm.SelectedItem.ToString() & "'")
        Select Case cboStatus.SelectedIndex
            Case 1 : f.Add("Balance > 0")
            Case Is > 1 : f.Add("Status = '" & cboStatus.SelectedItem.ToString() & "'")
        End Select
        dv.RowFilter = String.Join(" AND ", f)
        Dim fee As Decimal = 0, paid As Decimal = 0
        For Each r As DataRowView In dv
            fee += Convert.ToDecimal(r("Fee")) : paid += Convert.ToDecimal(r("Paid"))
        Next
        lblEmpty.Visible = (dv.Count = 0)
        If dv.Count = 0 Then lblEmpty.Text = If(dt.Rows.Count = 0, "No students yet." & vbCrLf & "Click Register to add the first one.", "No students match your search or filters.")
        Dim outstanding As Decimal = fee - paid
        Dim owe As Color = If(outstanding > 0, Theme.Danger, Theme.Ink)
        If compact Then
            sbTotals.SetItems(Tuple.Create("Students", dv.Count.ToString(), Theme.Ink), Tuple.Create("Outstanding", Theme.Money(outstanding), owe))
        Else
            sbTotals.SetItems(Tuple.Create("Students", dv.Count.ToString(), Theme.Ink), Tuple.Create("Expected", Theme.Money(fee), Theme.Ink),
                              Tuple.Create("Collected", Theme.Money(paid), Theme.Ok), Tuple.Create("Outstanding", Theme.Money(outstanding), owe))
        End If
    End Sub

    Private Sub dgv_SelectionChanged(sender As Object, e As EventArgs) Handles dgv.SelectionChanged
        If ready Then RaiseEvent SelectedChanged(SelectedId)
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If e.RowIndex >= 0 Then DoEdit()
    End Sub

    Private Sub dgv_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles dgv.CellPainting
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 OrElse dgv.Columns(e.ColumnIndex).Name <> "Status" Then Return
        Theme.PaintStatus(e)
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Using d As New StudentDialog()
            If d.ShowDialog(FindForm()) = DialogResult.OK Then
                Reload()
                RaiseEvent DataChanged()
            End If
        End Using
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        DoEdit()
    End Sub

    Private Sub DoEdit()
        Dim id = SelectedId
        If id Is Nothing Then MessageBox.Show("Select a student first.") : Return
        Using d As New StudentDialog(id)
            If d.ShowDialog(FindForm()) = DialogResult.OK Then
                Reload()
                RaiseEvent DataChanged()
            End If
        End Using
    End Sub

    Private Sub btnStatement_Click(sender As Object, e As EventArgs) Handles btnStatement.Click
        Dim id = SelectedId
        If id Is Nothing Then MessageBox.Show("Select a student first.") : Return
        Using d As New StatementDialog(id)
            d.ShowDialog(FindForm())
        End Using
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        ImportService.ImportStudents(FindForm())
        Reload()
        RaiseEvent DataChanged()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Helpers.ExportView(CType(dgv.DataSource, DataView), "students")
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not Session.IsAdmin Then Return
        Dim id = SelectedId
        If id Is Nothing Then MessageBox.Show("Select a student first.") : Return
        If Convert.ToInt32(Db.Scalar("SELECT COUNT(*) FROM Payments WHERE StudentId = @p0", id)) > 0 Then
            MessageBox.Show("This student has payment records, so the record cannot be deleted." & vbCrLf & "Void each payment first (Payments screen), with a reason.", "Cannot delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim r = Db.Query("SELECT * FROM Students WHERE Id = @p0", id).Rows(0)
        Dim snapshot = r("Name").ToString() & ", " & r("Class").ToString() & ", " & r("Term").ToString() & ", guardian " & r("Guardian").ToString() & ", phone " & r("Phone").ToString() & ", fee " & Convert.ToDecimal(r("Fee")).ToString("N2")
        Using d As New ReasonDialog("Delete student record?", id & " · " & r("Name").ToString() & vbCrLf & "This cannot be undone. A copy of the record is kept in the audit log.", "Reason (required)", "Delete record", True)
            If d.ShowDialog(FindForm()) <> DialogResult.OK Then Return
            Using tx As New Tx()
                tx.Exec("DELETE FROM Students WHERE Id = @p0", id)
                AuditLogger.Log(tx, "DELETE STUDENT", id & " · " & r("Name").ToString(), snapshot, "Record removed", d.Value)
                tx.Commit()
            End Using
        End Using
        Reload()
        RaiseEvent DataChanged()
    End Sub
End Class
