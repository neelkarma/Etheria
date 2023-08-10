Imports SFML.System

Public Class EndScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "End"

    Public Overrides Sub InitEntities()
        AddEntity(
            New TextComponent("Game Over", Nothing, 1.5),
            New PositionComponent(New Vector2i(50, 50))
        )

        AddEntity(
            New TextComponent($"Winner: {GetSideName(winning)}"),
            New PositionComponent(New Vector2i(50, 210))
        )

        AddEntity(New TextButtonEntity("Restart", New Vector2i(50, 100), Sub() scenes.Open("Game")))
        AddEntity(New TextButtonEntity("Quit To Title", New Vector2i(50, 150), Sub() scenes.Open("Title")))
    End Sub
End Class
