Public Class PlayerComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Player"

    Public Const speed As Integer = 10

    Public invincibilityFrames As Integer = 120

    Public fireRate As Integer = 10
    Public framesUntilCanFire As Integer = fireRate

    Public Sub New()
    End Sub
End Class
