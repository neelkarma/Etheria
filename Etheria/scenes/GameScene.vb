Imports SFML.Graphics

Public Class GameScene
    Inherits Scene
    Public Overrides ReadOnly Property Type As String = "Game"

    Public Overrides Sub InitEntities()
        AddEntity(New PlayerEntity(playerColor))

        AddEntity(New PlayerHUDComponent())
    End Sub

End Class
