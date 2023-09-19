Public Class PlayerComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Player"

    Public lives As Integer
    Public score As Integer
    Public invulnerable As Boolean
    Public dead As Boolean
    Public speed As Integer = 10

    Public Sub New()
        lives = 3
        score = 0
        invulnerable = False
        dead = False
    End Sub
End Class
