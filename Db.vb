Public Module Db
    Public ReadOnly DataDir As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SchoolFeesTracker")
    Public ReadOnly DbPath As String = Path.Combine(DataDir, "fees.db")
    Public ReadOnly LogPath As String = Path.Combine(DataDir, "audit.log")

    ' Student rows with paid, balance and status calculated from valid (non-voided) payments
    Public Const StudentSql As String =
        "SELECT Id, Name, Class, Term, Guardian, Phone, Fee, Paid, ROUND(Fee - Paid, 2) AS Balance, " &
        "CASE WHEN Paid <= 0 THEN 'Owing' WHEN Paid < Fee THEN 'Part paid' ELSE 'Paid in full' END AS Status FROM (" &
        "SELECT s.Id, s.Name, s.Class, s.Term, s.Guardian, s.Phone, s.Fee, " &
        "ROUND(IFNULL((SELECT SUM(p.Amount) FROM Payments p WHERE p.StudentId = s.Id AND p.Voided = 0), 0), 2) AS Paid FROM Students s)"

    Public Function OpenConn() As SqliteConnection
        Dim c As New SqliteConnection("Data Source=" & DbPath)
        c.Open()
        Using cmd = c.CreateCommand()
            cmd.CommandText = "PRAGMA foreign_keys = ON"
            cmd.ExecuteNonQuery()
        End Using
        Return c
    End Function

    Private Sub Bind(cmd As SqliteCommand, args() As Object)
        If args Is Nothing Then Return
        For i = 0 To args.Length - 1
            Dim v As Object = args(i)
            If v Is Nothing Then v = DBNull.Value
            If TypeOf v Is Decimal Then v = CDbl(v)
            cmd.Parameters.AddWithValue("@p" & i, v)
        Next
    End Sub

    Private ReadOnly NumericNames As New HashSet(Of String)({"fee", "paid", "balance", "amount", "a", "f", "p", "n", "c", "failedlogins"})

    ' Loads a query into a DataTable with explicit column types (SQLite expression columns have no declared type,
    ' which made the DataGridView treat numbers as images).
    Public Function Query(sql As String, ParamArray args() As Object) As DataTable
        Using c = OpenConn(), cmd = c.CreateCommand()
            cmd.CommandText = sql
            Bind(cmd, args)
            Using r = cmd.ExecuteReader()
                Dim n As Integer = r.FieldCount
                Dim rows As New List(Of Object())
                Dim types(n - 1) As Type
                While r.Read()
                    Dim vals(n - 1) As Object
                    r.GetValues(vals)
                    For i = 0 To n - 1
                        If vals(i) Is DBNull.Value Then Continue For
                        Dim vt As Type = vals(i).GetType()
                        If types(i) Is Nothing Then
                            types(i) = vt
                        ElseIf types(i) IsNot vt Then
                            Dim numA As Boolean = (types(i) Is GetType(Double) OrElse types(i) Is GetType(Long))
                            Dim numB As Boolean = (vt Is GetType(Double) OrElse vt Is GetType(Long))
                            types(i) = If(numA AndAlso numB, GetType(Double), GetType(String))
                        End If
                    Next
                    rows.Add(vals)
                End While
                Dim dt As New DataTable
                For i = 0 To n - 1
                    Dim nm As String = r.GetName(i)
                    Dim t As Type = types(i)
                    If t Is Nothing Then t = If(NumericNames.Contains(nm.ToLower()), GetType(Double), GetType(String))
                    If t Is GetType(Byte()) Then t = GetType(String)
                    dt.Columns.Add(nm, t)
                Next
                For Each vals In rows
                    Dim row As DataRow = dt.NewRow()
                    For i = 0 To n - 1
                        If vals(i) Is DBNull.Value Then
                            row(i) = DBNull.Value
                        Else
                            row(i) = Convert.ChangeType(vals(i), dt.Columns(i).DataType)
                        End If
                    Next
                    dt.Rows.Add(row)
                Next
                Return dt
            End Using
        End Using
    End Function

    Public Function Scalar(sql As String, ParamArray args() As Object) As Object
        Using c = OpenConn(), cmd = c.CreateCommand()
            cmd.CommandText = sql
            Bind(cmd, args)
            Dim v = cmd.ExecuteScalar()
            Return If(v Is DBNull.Value, Nothing, v)
        End Using
    End Function

    Friend Sub ExecOn(conn As SqliteConnection, trn As SqliteTransaction, sql As String, args() As Object)
        Using cmd = conn.CreateCommand()
            cmd.Transaction = trn
            cmd.CommandText = sql
            Bind(cmd, args)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Friend Function ScalarOn(conn As SqliteConnection, trn As SqliteTransaction, sql As String, args() As Object) As Object
        Using cmd = conn.CreateCommand()
            cmd.Transaction = trn
            cmd.CommandText = sql
            Bind(cmd, args)
            Dim v = cmd.ExecuteScalar()
            Return If(v Is DBNull.Value, Nothing, v)
        End Using
    End Function

    Public Function NextNumber(tx As Tx, table As String, prefix As String, digits As Integer) As String
        Dim v = tx.Scalar("SELECT IFNULL(MAX(CAST(SUBSTR(Id, " & (prefix.Length + 1) & ") AS INTEGER)), 0) FROM " & table)
        Dim n As Integer = Convert.ToInt32(v) + 1
        ' never reuse a number that appears in the audit log (e.g. a deleted student)
        Do While Convert.ToInt32(tx.Scalar("SELECT COUNT(*) FROM AuditLog WHERE Record LIKE @p0", prefix & n.ToString(New String("0"c, digits)) & "%")) > 0
            n += 1
        Loop
        Return prefix & n.ToString(New String("0"c, digits))
    End Function

    Public Sub Initialize()
        Directory.CreateDirectory(DataDir)
        Dim ddl() As String = {
            "CREATE TABLE IF NOT EXISTS Users(Id INTEGER PRIMARY KEY AUTOINCREMENT, FullName TEXT NOT NULL, Username TEXT NOT NULL UNIQUE COLLATE NOCASE, PasswordHash TEXT NOT NULL, Salt TEXT NOT NULL, Role TEXT NOT NULL, Active INTEGER NOT NULL DEFAULT 1, MustChange INTEGER NOT NULL DEFAULT 0, FailedAttempts INTEGER NOT NULL DEFAULT 0, LastLogin TEXT)",
            "CREATE TABLE IF NOT EXISTS Students(Id TEXT PRIMARY KEY, Name TEXT NOT NULL, Class TEXT NOT NULL, Term TEXT NOT NULL, Guardian TEXT, Phone TEXT, Fee REAL NOT NULL, Created TEXT NOT NULL)",
            "CREATE TABLE IF NOT EXISTS Payments(Id TEXT PRIMARY KEY, StudentId TEXT NOT NULL REFERENCES Students(Id), Amount REAL NOT NULL, Method TEXT NOT NULL, Ref TEXT, PaidOn TEXT NOT NULL, ByUser TEXT NOT NULL, Voided INTEGER NOT NULL DEFAULT 0, VoidReason TEXT, PrintCount INTEGER NOT NULL DEFAULT 0)",
            "CREATE TABLE IF NOT EXISTS FeeSettings(Class TEXT NOT NULL, Term TEXT NOT NULL, Fee REAL NOT NULL, PRIMARY KEY(Class, Term))",
            "CREATE TABLE IF NOT EXISTS Settings(Key TEXT PRIMARY KEY, Value TEXT)",
            "CREATE TABLE IF NOT EXISTS AuditLog(Id INTEGER PRIMARY KEY AUTOINCREMENT, Time TEXT NOT NULL, UserName TEXT NOT NULL, Action TEXT NOT NULL, Record TEXT, OldValue TEXT, NewValue TEXT, Reason TEXT)",
            "CREATE TRIGGER IF NOT EXISTS audit_no_update BEFORE UPDATE ON AuditLog BEGIN SELECT RAISE(ABORT, 'The audit log is read-only'); END",
            "CREATE TRIGGER IF NOT EXISTS audit_no_delete BEFORE DELETE ON AuditLog BEGIN SELECT RAISE(ABORT, 'The audit log is read-only'); END"
        }
        Using c = OpenConn()
            For Each stmt In ddl
                ExecOn(c, Nothing, stmt, Nothing)
            Next
            ' Schema versioning: add future upgrades as "If ver < 2 Then ... : PRAGMA user_version = 2"
            Dim ver As Integer = Convert.ToInt32(ScalarOn(c, Nothing, "PRAGMA user_version", Nothing))
            If ver < 1 Then ExecOn(c, Nothing, "PRAGMA user_version = 1", Nothing)
            If ver < 2 Then
                Try
                    ExecOn(c, Nothing, "ALTER TABLE AuditLog ADD COLUMN Hash TEXT", Nothing)
                Catch
                End Try
                ExecOn(c, Nothing, "PRAGMA user_version = 2", Nothing)
            End If
            If ver < 3 Then
                Try
                    ExecOn(c, Nothing, "ALTER TABLE Students ADD COLUMN PersonId TEXT", Nothing)
                Catch
                End Try
                Try
                    ExecOn(c, Nothing, "ALTER TABLE Payments ADD COLUMN Batch TEXT", Nothing)
                Catch
                End Try
                ExecOn(c, Nothing, "UPDATE Students SET PersonId = (SELECT MIN(s2.Id) FROM Students s2 WHERE LOWER(s2.Name) = LOWER(Students.Name) AND IFNULL(s2.Phone, '') = IFNULL(Students.Phone, '')) WHERE PersonId IS NULL", Nothing)
                ExecOn(c, Nothing, "UPDATE Payments SET Batch = Id WHERE Batch IS NULL", Nothing)
                ExecOn(c, Nothing, "PRAGMA user_version = 3", Nothing)
            End If
        End Using
        If Convert.ToInt32(Scalar("SELECT COUNT(*) FROM Users")) = 0 Then
            Using tx As New Tx("system")
                Dim salt = NewSalt()
                tx.Exec("INSERT INTO Users(FullName, Username, PasswordHash, Salt, Role, MustChange) VALUES (@p0, @p1, @p2, @p3, @p4, 1)",
                        "Super Admin", "admin", HashPassword("admin123", salt), salt, "Super admin")
                For Each cl In {"JHS 1", "JHS 2", "JHS 3"}
                    For Each tm In {"Term 1", "Term 2", "Term 3"}
                        tx.Exec("INSERT INTO FeeSettings(Class, Term, Fee) VALUES (@p0, @p1, @p2)", cl, tm, If(cl = "JHS 3", 450, 400))
                    Next
                Next
                tx.Exec("INSERT OR IGNORE INTO Settings(Key, Value) VALUES ('SchoolName', 'Your School Name')")
                AuditLogger.Log(tx, "SYSTEM SETUP", "Database created", "", "Default super admin account created")
                tx.Commit()
            End Using
        End If
    End Sub

    Public Sub BackupTo(targetFile As String)
        If File.Exists(targetFile) Then File.Delete(targetFile)
        Using c = OpenConn()
            ExecOn(c, Nothing, "VACUUM INTO '" & targetFile.Replace("'", "''") & "'", Nothing)
        End Using
    End Sub

    ' Keeps the 10 most recent daily automatic backups
    Public Sub AutoBackup()
        Try
            Dim dir As String = Path.Combine(DataDir, "backups")
            Directory.CreateDirectory(dir)
            BackupTo(Path.Combine(dir, "fees_auto_" & Now.ToString("yyyyMMdd") & ".db"))
            Dim old = New DirectoryInfo(dir).GetFiles("fees_auto_*.db").OrderByDescending(Function(f) f.Name).Skip(10).ToList()
            For Each f In old
                f.Delete()
            Next
        Catch
        End Try
    End Sub

    ' Returns "" if the file looks like a valid backup, otherwise the reason it does not
    Public Function ValidateBackup(backupFile As String) As String
        Try
            Using c As New SqliteConnection("Data Source=" & backupFile & ";Mode=ReadOnly")
                c.Open()
                For Each tbl In {"Users", "Students", "Payments", "AuditLog"}
                    Using cmd = c.CreateCommand()
                        cmd.CommandText = "SELECT COUNT(*) FROM " & tbl
                        cmd.ExecuteScalar()
                    End Using
                Next
            End Using
            SqliteConnection.ClearAllPools()
            Return ""
        Catch ex As Exception
            Return "This file is not a valid School Fees Tracker backup (" & ex.Message & ")."
        End Try
    End Function

    ' Called at start-up: swaps in a backup chosen earlier from Fee settings
    Public Function ApplyPendingRestore() As Boolean
        Dim pending As String = Path.Combine(DataDir, "restore.pending")
        If Not File.Exists(pending) Then Return False
        Try
            If File.Exists(DbPath) Then File.Copy(DbPath, Path.Combine(DataDir, "fees_before_restore_" & Now.ToString("yyyyMMdd_HHmmss") & ".db"), True)
            File.Copy(pending, DbPath, True)
            File.Delete(pending)
            Return True
        Catch ex As Exception
            MessageBox.Show("The restore could not be completed: " & ex.Message, "School Fees Tracker")
            Return False
        End Try
    End Function

    ' Links a new term record to the same pupil's earlier records (same name and phone). Nothing if none or no phone.
    Public Function FindPersonId(tx As Tx, name As String, phone As String) As String
        If phone Is Nothing OrElse phone.Trim() = "" Then Return Nothing
        Dim v = tx.Scalar("SELECT IFNULL(PersonId, Id) FROM Students WHERE LOWER(Name) = LOWER(@p0) AND IFNULL(Phone, '') = @p1 ORDER BY Id LIMIT 1", name, phone)
        Return If(v Is Nothing, Nothing, v.ToString())
    End Function

    Public Function SchoolName() As String
        Dim v = Scalar("SELECT Value FROM Settings WHERE Key = 'SchoolName'")
        Return If(v Is Nothing, "School", v.ToString())
    End Function

    Public Function SuggestedFee(cls As String, term As String) As Decimal
        Dim v = Scalar("SELECT Fee FROM FeeSettings WHERE Class = @p0 AND Term = @p1", cls, term)
        Return If(v Is Nothing, 0D, Convert.ToDecimal(v))
    End Function
End Module

' One transaction: data changes and their audit entries are saved together or not at all
Public Class Tx
    Implements IDisposable
    Private ReadOnly conn As SqliteConnection
    Private ReadOnly trn As SqliteTransaction
    Private ReadOnly pendingLines As New List(Of String)
    Private committed As Boolean
    Public ReadOnly Property Actor As String

    Public Sub New(Optional actor As String = Nothing)
        Me.Actor = If(actor, Session.UserName)
        conn = Db.OpenConn()
        trn = conn.BeginTransaction()
    End Sub

    Public Sub Exec(sql As String, ParamArray args() As Object)
        Db.ExecOn(conn, trn, sql, args)
    End Sub

    Public Function Scalar(sql As String, ParamArray args() As Object) As Object
        Return Db.ScalarOn(conn, trn, sql, args)
    End Function

    Friend Sub AddLogLine(line As String)
        pendingLines.Add(line)
    End Sub

    Public Sub Commit()
        trn.Commit()
        committed = True
        Try
            File.AppendAllLines(Db.LogPath, pendingLines)
        Catch
            ' the database copy is the master record; the text file is a convenience copy
        End Try
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If Not committed Then trn.Rollback()
        trn.Dispose()
        conn.Dispose()
    End Sub
End Class

Public Module AuditLogger
    ' Writes one audit entry inside the caller's transaction (and, on commit, to audit.log)
    Public Function ComputeHash(prev As String, ParamArray parts() As String) As String
        Dim raw As String = prev & "|" & String.Join("|", parts.Select(Function(p) If(p, "")))
        Return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(raw)))
    End Function

    ' Writes one audit entry inside the caller's transaction (and, on commit, to audit.log).
    ' Each entry stores a checksum that includes the previous entry's checksum (a hash chain).
    Public Sub Log(tx As Tx, action As String, record As String, Optional oldValue As String = "", Optional newValue As String = "", Optional reason As String = "")
        Dim t As String = Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim prev As Object = tx.Scalar("SELECT Hash FROM AuditLog ORDER BY Id DESC LIMIT 1")
        Dim prevHash As String = If(prev Is Nothing, "GENESIS", prev.ToString())
        Dim h As String = ComputeHash(prevHash, t, tx.Actor, action, record, oldValue, newValue, reason)
        tx.Exec("INSERT INTO AuditLog(Time, UserName, Action, Record, OldValue, NewValue, Reason, Hash) VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7)",
                t, tx.Actor, action, record, oldValue, newValue, reason, h)
        tx.AddLogLine(String.Join(" | ", {t, tx.Actor, action, record, "before: " & oldValue, "after: " & newValue, "reason: " & reason}).Replace(vbCr, " ").Replace(vbLf, " ") & " | hash: " & h)
    End Sub

    ' Re-checks the whole chain and compares audit.log with the database
    Public Function Verify(ByRef ok As Boolean) As String
        Dim dt As DataTable = Db.Query("SELECT Id, Time, UserName, Action, Record, OldValue, NewValue, Reason, Hash FROM AuditLog ORDER BY Id")
        Dim prev As String = "GENESIS"
        Dim problems As New List(Of String)
        Dim dbHashes As New HashSet(Of String)
        For Each r As DataRow In dt.Rows
            If r("Hash") Is DBNull.Value Then
                prev = "GENESIS"
                Continue For
            End If
            Dim stored As String = r("Hash").ToString()
            Dim expected As String = ComputeHash(prev, Convert.ToString(r("Time")), Convert.ToString(r("UserName")), Convert.ToString(r("Action")), Convert.ToString(r("Record")), Convert.ToString(r("OldValue")), Convert.ToString(r("NewValue")), Convert.ToString(r("Reason")))
            If expected <> stored Then
                problems.Add("Entry #" & r("Id").ToString() & " (" & Convert.ToString(r("Time")) & ") fails its checksum: it was changed, or an entry before it was removed.")
            End If
            prev = stored
            dbHashes.Add(stored)
        Next
        If File.Exists(Db.LogPath) Then
            Dim fileHashes As New HashSet(Of String)
            For Each line In File.ReadAllLines(Db.LogPath)
                Dim i As Integer = line.LastIndexOf("| hash: ")
                If i >= 0 Then fileHashes.Add(line.Substring(i + 8).Trim())
            Next
            Dim notInDb As Integer = fileHashes.Where(Function(x) Not dbHashes.Contains(x)).Count()
            Dim notInFile As Integer = dbHashes.Where(Function(x) Not fileHashes.Contains(x)).Count()
            If notInDb > 0 Then problems.Add(notInDb & " line(s) in audit.log do not match the database (edited, or from another database).")
            If notInFile > 0 Then problems.Add(notInFile & " database entries are missing from audit.log (lines removed).")
        Else
            problems.Add("audit.log was not found.")
        End If
        ok = problems.Count = 0
        If ok Then Return "The audit log is intact. " & dbHashes.Count & " entries checked; audit.log matches the database."
        Return String.Join(vbCrLf & vbCrLf, problems)
    End Function

    ' For events with no other data change (sign-in, export, print)
    Public Sub LogOnly(action As String, record As String, Optional oldValue As String = "", Optional newValue As String = "", Optional reason As String = "", Optional actor As String = Nothing)
        Using tx As New Tx(actor)
            Log(tx, action, record, oldValue, newValue, reason)
            tx.Commit()
        End Using
    End Sub
End Module
