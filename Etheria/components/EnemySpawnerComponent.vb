Public Class EnemySpawnerComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "EnemySpawner"

    Public rate As Integer
    Public spread As Integer
    Public framesUntilNext As Integer

    Public Sub New(Optional rate As Integer = 120, Optional spread As Integer = 60)
        Me.rate = rate
        Me.spread = spread

        framesUntilNext = rate
    End Sub
End Class
