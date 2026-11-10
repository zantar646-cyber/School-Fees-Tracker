Public Class FeesView
    Private dt As DataTable

    Public Sub New()
        InitializeComponent()
        Theme.Polish(Me)
        Theme.StyleGrid(dgv)
        dgv.ReadOnly = False
        dgv.SelectionMode = DataGridViewSelectionMode.CellSelect
    End Sub

    Private Sub FeesView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If DesignMode Then Return
        lblNote.Text = "Click a fee to edit it. New fees apply to new registrations only. Every change is logged."
        txtSchool.Text = Db.SchoolName()
        LoadGrid()
    End Sub

    Private Sub dgv_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgv.DataError
        MessageBox.Show("Enter a number, for example 400.00")
        e.ThrowException = False
    End Sub

    Private Sub LoadGrid()
        dt = New DataTable
        dt.Columns.Add("Class", GetType(String))
        For Each tm In {"Term 1", "Term 2", "Term 3"}
            dt.Columns.Add(tm, GetType(Decimal))
        Next
        For Each c In {"JHS 1", "JHS 2", "JHS 3"}
            Dim row = dt.NewRow()
            row("Class") = c
            For Each tm In {"Term 1", "Term 2", "Term 3"}
                row(tm) = Db.SuggestedFee(c, tm)
            Next
            dt.Rows.Add(row)
        Next
        dgv.DataSource = dt
        dgv.Columns("Class").ReadOnly = True
        Theme.FitColumns(dgv)
        For Each tm In {"Term 1", "Term 2", "Term 3"}
            dgv.Columns(tm).DefaultCellStyle.Format = "N2"
        Next
    End Sub

    Private Sub btnSaveName_Click(sender As Object, e As EventArgs) Handles btnSaveName.Click
        Dim n = txtSchool.Text.Trim()
        If n = "" Then MessageBox.Show("Enter the school name.") : Return
        Dim old = Db.SchoolName()
        If n = old Then Return
        Using tx As New Tx()
            tx.Exec("INSERT INTO Settings(Key, Value) VALUES ('SchoolName', @p0) ON CONFLICT(Key) DO UPDATE SET Value = @p0", n)
            AuditLogger.Log(tx, "SETTING CHANGE", "School name", old, n)
            tx.Commit()
        End Using
        Toast.Notify(Me, "School name saved")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        dgv.EndEdit()
        Dim changes As Integer = 0
        Using tx As New Tx()
            For Each r As DataRow In dt.Rows
                For Each tm In {"Term 1", "Term 2", "Term 3"}
                    Dim newFee As Decimal = Math.Round(Convert.ToDecimal(r(tm)), 2)
                    If newFee <= 0 Then MessageBox.Show("Every fee must be greater than zero.") : Return
                    Dim oldFee As Decimal = Db.SuggestedFee(r("Class").ToString(), tm)
                    If newFee <> oldFee Then
                        tx.Exec("UPDATE FeeSettings SET Fee = @p0 WHERE Class = @p1 AND Term = @p2", newFee, r("Class").ToString(), tm)
                        AuditLogger.Log(tx, "FEE CHANGE", r("Class").ToString() & " / " & tm, oldFee.ToString("N2"), newFee.ToString("N2"))
                        changes += 1
                    End If
                Next
            Next
            If changes > 0 Then tx.Commit()
        End Using
        Toast.Notify(Me, If(changes = 0, "No changes to save", changes & " fee(s) updated"))
    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        Using sfd As New SaveFileDialog With {.Filter = "Database backup (*.db)|*.db", .FileName = "fees_backup_" & Now.ToString("yyyyMMdd_HHmm") & ".db"}
            If sfd.ShowDialog() <> DialogResult.OK Then Return
            Try
                Db.BackupTo(sfd.FileName)
                AuditLogger.LogOnly("BACKUP", "fees.db", "", "Saved to " & Path.GetFileName(sfd.FileName))
                Toast.Notify(Me, "Backup saved. Keep a copy on a flash drive.")
            Catch ex As Exception
                MessageBox.Show("Backup failed: " & ex.Message, "Backup")
            End Try
        End Using
    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        Using ofd As New OpenFileDialog With {.Filter = "Database backup (*.db)|*.db"}
            If ofd.ShowDialog() <> DialogResult.OK Then Return
            Dim problem As String = Db.ValidateBackup(ofd.FileName)
            If problem <> "" Then MessageBox.Show(problem, "Restore") : Return
            If MessageBox.Show("Restore this backup? Anything entered after the backup was made will be lost when the app restarts. A copy of the current data is kept first.", "Restore backup", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return
            File.Copy(ofd.FileName, Path.Combine(Db.DataDir, "restore.pending"), True)
            AuditLogger.LogOnly("RESTORE REQUESTED", Path.GetFileName(ofd.FileName), "", "Will be applied at the next start")
            MessageBox.Show("Close the app and open it again to finish the restore.", "Restore backup")
        End Using
    End Sub
End Class
