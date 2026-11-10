Public Class IdleFilter
    Implements IMessageFilter
    Public LastActivity As DateTime = Now
    Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
        Select Case m.Msg
            Case &H200, &H201, &H204, &H100, &H20A   ' mouse move/click, key down, wheel
                LastActivity = Now
        End Select
        Return False
    End Function
End Class
