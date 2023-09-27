Public Class PlayerComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Player"

    Public invulnerable As Boolean
    Public speed As Integer = 10

    Public Sub New()
        invulnerable = False
    End Sub
End Class
