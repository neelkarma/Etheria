Imports SFML.System
Imports SFML.Window

Public Class ControlsScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "Controls"

    Public Overrides Sub InitEntities()
        AddEntity(
            New MenuBackgroundEntity()
        )
        AddEntity(
            New PositionComponent(New Vector2i(250, 290)),
            New SpriteComponent("spacebar", , 0.5)
        )
        AddEntity(
            New PositionComponent(New Vector2i(250, 155)),
            New SpriteComponent("wasd", , 0.5)
        )
        AddEntity(
            New PositionComponent(New Vector2i(70, 250)),
            New SpriteComponent("shift", , 0.5)
        )
        AddEntity(
            New PositionComponent(New Vector2i(560, 160)),
            New SpriteComponent("mouse", , 0.5)
        )

        AddEntity(
            New TextComponent("Controls", , 1.5),
            New PositionComponent(New Vector2i(50, 50))
        )

        AddEntity(New TextButtonEntity("Back", New Vector2i(330, 470), Sub() scenes.Open("Title")))
    End Sub
End Class
