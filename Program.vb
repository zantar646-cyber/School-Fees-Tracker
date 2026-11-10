Module Program
    Public Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.SetHighDpiMode(HighDpiMode.SystemAware)
        Dim createdNew As Boolean
        Using instanceLock As New Threading.Mutex(True, "SchoolFeesTracker.SingleInstance", createdNew)
            If Not createdNew Then
                MessageBox.Show("The School Fees Tracker is already running on this computer.", "School Fees Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            AddHandler Application.ThreadException,
                Sub(sender, ev) MessageBox.Show("Unexpected error: " & ev.Exception.Message, "School Fees Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim restored As Boolean = Db.ApplyPendingRestore()
            Try
                Db.Initialize()
            Catch ex As Exception
                MessageBox.Show("Could not open the database in " & Db.DataDir & vbCrLf & ex.Message, "School Fees Tracker", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
            If restored Then AuditLogger.LogOnly("RESTORE COMPLETED", "fees.db", "", "Database restored from a backup", "", "system")
            Do
                Dim login As New LoginForm()
                If login.ShowDialog() <> DialogResult.OK Then Exit Do
                Dim shell As New MainForm()
                Application.Run(shell)
                If Not shell.LoggedOut Then Exit Do
            Loop
        End Using
    End Sub
End Module
