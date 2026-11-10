Public Class StudentDialog
    Private studentId As String
    Private original As DataRow
    Private hasPayments As Boolean
    Private loaded As Boolean

    Public Sub New()
        InitializeComponent()
        Theme.Polish(Me)
        Animator.FadeIn(Me)
    End Sub

    Public Sub New(id As String)
        Me.New()
        studentId = id
    End Sub

    Private Sub StudentDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If DesignMode Then Return
        If studentId Is Nothing Then
            Text = "Register student"
            lblHeader.Text = "Register student"
            lblSubHeader.Text = "Add a new student to the register"
            btnSave.Text = "Save student"
            lblNote.Text = "The fee is suggested from Fee settings. Every registration is logged."
            cboClass.SelectedIndex = 0
            cboTerm.SelectedIndex = 0
            Suggest()
        Else
            Text = "Edit student " & studentId
            lblHeader.Text = "Edit student " & studentId
            lblSubHeader.Text = "Changes are logged with before and after values"
            btnSave.Text = "Save changes"
            original = Db.Query("SELECT * FROM Students WHERE Id = @p0", studentId).Rows(0)
            hasPayments = Convert.ToInt32(Db.Scalar("SELECT COUNT(*) FROM Payments WHERE StudentId = @p0", studentId)) > 0
            txtName.Text = original("Name").ToString()
            cboClass.SelectedItem = original("Class").ToString()
            cboTerm.SelectedItem = original("Term").ToString()
            txtGuardian.Text = original("Guardian").ToString()
            txtPhone.Text = original("Phone").ToString()
            txtFee.Text = Convert.ToDecimal(original("Fee")).ToString("0.00")
            If hasPayments Then
                txtFee.ReadOnly = True
                cboClass.Enabled = False
                cboTerm.Enabled = False
                lblNote.Text = "Class, term and fee are locked because payments exist. All changes are logged (before and after)."
            Else
                lblNote.Text = "All changes are logged (before and after)."
            End If
        End If
        loaded = True
    End Sub

    Private Sub ClassOrTerm_Changed(sender As Object, e As EventArgs) Handles cboClass.SelectedIndexChanged, cboTerm.SelectedIndexChanged
        If loaded AndAlso studentId Is Nothing Then Suggest()
    End Sub

    Private Sub Suggest()
        If cboClass.SelectedItem Is Nothing OrElse cboTerm.SelectedItem Is Nothing Then Return
        txtFee.Text = Db.SuggestedFee(cboClass.SelectedItem.ToString(), cboTerm.SelectedItem.ToString()).ToString("0.00")
    End Sub

    Private Function Clean(s As String) As String
        Return s.Trim().Replace(vbCr, " ").Replace(vbLf, " ")
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim name = Clean(txtName.Text), guardian = Clean(txtGuardian.Text), phone = Clean(txtPhone.Text)
        If name = "" Then lblMsg.Text = "Enter the student's full name." : Return
        If name.Length > 100 Then lblMsg.Text = "The name is too long." : Return
        If phone <> "" AndAlso Not System.Text.RegularExpressions.Regex.IsMatch(phone, "^[0-9+ ]{9,15}$") Then
            lblMsg.Text = "Phone should be 9 to 15 digits (spaces and + allowed)." : Return
        End If
        Dim fee As Decimal
        If Not Decimal.TryParse(txtFee.Text, fee) OrElse fee <= 0 Then lblMsg.Text = "Enter a fee greater than zero." : Return
        fee = Math.Round(fee, 2)
        Dim cls = cboClass.SelectedItem.ToString(), term = cboTerm.SelectedItem.ToString()

        Using tx As New Tx()
            Dim dupe = Convert.ToInt32(tx.Scalar("SELECT COUNT(*) FROM Students WHERE LOWER(Name) = LOWER(@p0) AND Class = @p1 AND Term = @p2 AND Id <> @p3", name, cls, term, If(studentId, "")))
            If dupe > 0 Then lblMsg.Text = "A student with this name is already registered for " & cls & ", " & term & "." : Return
            If studentId Is Nothing Then
                Dim id = Db.NextNumber(tx, "Students", "STU", 3)
                tx.Exec("INSERT INTO Students(Id, Name, Class, Term, Guardian, Phone, Fee, Created, PersonId) VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)",
                        id, name, cls, term, guardian, phone, fee, Now.ToString("yyyy-MM-dd HH:mm:ss"), If(Db.FindPersonId(tx, name, phone), id))
                AuditLogger.Log(tx, "REGISTER STUDENT", id & " · " & name, "", cls & ", " & term & ", fee " & fee.ToString("N2") & ", phone " & phone)
            Else
                Dim before As New List(Of String), after As New List(Of String)
                Diff(before, after, "Name", original("Name").ToString(), name)
                Diff(before, after, "Class", original("Class").ToString(), cls)
                Diff(before, after, "Term", original("Term").ToString(), term)
                Diff(before, after, "Guardian", original("Guardian").ToString(), guardian)
                Diff(before, after, "Phone", original("Phone").ToString(), phone)
                Diff(before, after, "Fee", Convert.ToDecimal(original("Fee")).ToString("N2"), fee.ToString("N2"))
                If before.Count = 0 Then DialogResult = DialogResult.Cancel : Return
                tx.Exec("UPDATE Students SET Name = @p0, Class = @p1, Term = @p2, Guardian = @p3, Phone = @p4, Fee = @p5 WHERE Id = @p6", name, cls, term, guardian, phone, fee, studentId)
                AuditLogger.Log(tx, "EDIT STUDENT", studentId & " · " & name, String.Join("; ", before), String.Join("; ", after))
            End If
            tx.Commit()
        End Using
        DialogResult = DialogResult.OK
    End Sub

    Private Sub Diff(b As List(Of String), a As List(Of String), field As String, oldV As String, newV As String)
        If oldV <> newV Then
            b.Add(field & ": " & oldV)
            a.Add(field & ": " & newV)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
    End Sub
End Class
