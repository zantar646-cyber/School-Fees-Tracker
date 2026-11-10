Public Module Session
    Public Property UserId As Integer
    Public Property UserName As String = ""
    Public Property FullName As String = ""
    Public Property Role As String = ""
    Public ReadOnly Property IsAdmin As Boolean
        Get
            Return Role = "Super admin"
        End Get
    End Property
    Public Sub Clear()
        UserId = 0 : UserName = "" : FullName = "" : Role = ""
    End Sub
End Module
