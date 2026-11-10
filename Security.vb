Public Module Security
    Private Const Iterations As Integer = 100000

    Public Function NewSalt() As String
        Return Convert.ToBase64String(RandomNumberGenerator.GetBytes(16))
    End Function

    Public Function HashPassword(password As String, salt As String) As String
        Dim h As Byte() = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), Convert.FromBase64String(salt), Iterations, HashAlgorithmName.SHA256, 32)
        Return Convert.ToBase64String(h)
    End Function

    Public Function Verify(password As String, salt As String, hash As String) As Boolean
        Return CryptographicOperations.FixedTimeEquals(Convert.FromBase64String(HashPassword(password, salt)), Convert.FromBase64String(hash))
    End Function

    ' Returns "" when the password is acceptable, otherwise the reason it is not
    Public Function PasswordProblem(pw As String) As String
        If pw.Length < 8 Then Return "Use at least 8 characters."
        If Not pw.Any(Function(ch) Char.IsLetter(ch)) Then Return "Include at least one letter."
        If Not pw.Any(Function(ch) Char.IsDigit(ch)) Then Return "Include at least one number."
        If pw.ToLower().Contains("password") OrElse pw = "admin123" Then Return "That password is too easy to guess."
        Return ""
    End Function
End Module
