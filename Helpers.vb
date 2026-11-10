Public Module Helpers
    Public Sub ApplyIcon(f As Form)
        Try
            f.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        Catch
        End Try
    End Sub

    Public Function FormTable() As TableLayoutPanel
        Dim t As New TableLayoutPanel With {.Dock = DockStyle.Top, .AutoSize = True, .ColumnCount = 2, .Padding = New Padding(0, 0, 0, 8)}
        t.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
        t.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
        Return t
    End Function

    Public Sub AddRow(t As TableLayoutPanel, caption As String, c As Control)
        Dim r As Integer = t.RowCount
        t.RowCount = r + 1
        t.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        Dim l As Label = Theme.Lbl(caption, False, True)
        l.Margin = New Padding(0, 8, 14, 0)
        c.Margin = New Padding(0, 4, 0, 4)
        c.Dock = DockStyle.Fill
        t.Controls.Add(l, 0, r)
        t.Controls.Add(c, 1, r)
    End Sub

    Public Function BaseDialog(title As String, w As Integer, h As Integer) As Form
        Dim f As New Form With {.Text = title, .Font = Theme.BaseFont, .StartPosition = FormStartPosition.CenterParent,
            .FormBorderStyle = FormBorderStyle.FixedDialog, .MaximizeBox = False, .MinimizeBox = False, .ShowInTaskbar = False,
            .ClientSize = New Size(w, h), .BackColor = Color.White, .Padding = New Padding(20)}
        Return f
    End Function

    Public Function ButtonBar(ParamArray b() As Button) As FlowLayoutPanel
        Dim p As New FlowLayoutPanel With {.Dock = DockStyle.Bottom, .Height = Theme.S(52), .FlowDirection = FlowDirection.RightToLeft}
        For Each x In b
            p.Controls.Add(x)
        Next
        Return p
    End Function

    Public Function ToCsv(dt As DataTable, path As String) As Boolean
        Try
            Dim sb As New StringBuilder
            sb.AppendLine(String.Join(",", dt.Columns.Cast(Of DataColumn).Select(Function(c) Q(c.ColumnName))))
            For Each r As DataRow In dt.Rows
                sb.AppendLine(String.Join(",", r.ItemArray.Select(Function(v) Q(Convert.ToString(v)))))
            Next
            File.WriteAllText(path, sb.ToString(), New UTF8Encoding(True))
            Return True
        Catch ex As Exception
            MessageBox.Show("Could not save the file: " & ex.Message)
            Return False
        End Try
    End Function

    Private Function Q(s As String) As String
        Return """" & If(s, "").Replace("""", """""") & """"
    End Function

    ' Exports the rows currently shown in a grid, and logs the export
    Public Sub ExportView(dv As DataView, name As String)
        Using sfd As New SaveFileDialog With {.Filter = "CSV file (*.csv)|*.csv", .FileName = name & "_" & Now.ToString("yyyyMMdd") & ".csv"}
            If sfd.ShowDialog() <> DialogResult.OK Then Return
            If ToCsv(dv.ToTable(), sfd.FileName) Then
                AuditLogger.LogOnly("EXPORT", name, "", dv.Count & " rows saved to " & Path.GetFileName(sfd.FileName))
                MessageBox.Show("Saved " & dv.Count & " rows.", "Export")
            End If
        End Using
    End Sub
End Module
