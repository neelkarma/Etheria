Public Class UIDGenerator
    Private Shared count As Long = 0

    Public Shared Function Generate() As Long
        count += 1
        Return count
    End Function
End Class
