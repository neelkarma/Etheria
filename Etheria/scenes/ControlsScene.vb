Imports SFML.System

Public Class ControlsScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "Controls"

    Public Overrides Sub InitEntities()
        AddEntity(
            New PositionComponent(),
            New SpriteComponent("menu-bg")
        )
        AddEntity(
            New PositionComponent(New Vector2i(100, 100)),
            New SpriteComponent("spacebar", 1, New Vector2i(0.1, 0.1))
        )
        AddEntity(
            New PositionComponent(),
            New SpriteComponent("wasd", 1, New Vector2i(0.1, 0.1))
        )
        AddEntity(
            New PositionComponent(),
            New SpriteComponent("shift", 1, New Vector2i(0.1, 0.1))
        )

        AddEntity(
            New TextComponent("Controls", Nothing, 1.5),
            New PositionComponent(New Vector2i(50, 50))
        )

        AddEntity(New TextButtonEntity("Back", New Vector2i(50, 300), Sub() scenes.Open("Title")))
    End Sub
End Class
