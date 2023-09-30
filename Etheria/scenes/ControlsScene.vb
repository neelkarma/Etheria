Imports SFML.System
Imports SFML.Window

Public Class ControlsScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "Controls"

    Public Overrides Sub InitEntities()
        ' wasd -> movement
        AddEntity(
            New TextComponent("Move",, 0.5),
            New PositionComponent(New Vector2i(300, 370))
        )
        AddEntity(
            New PositionComponent(New Vector2i(300, 230)),
            New SpriteComponent("wasd", , 0.5)
        )

        ' shift -> speed up
        AddEntity(
            New TextComponent("Speed Up",, 0.5),
            New PositionComponent(New Vector2i(70, 345))
        )
        AddEntity(
            New PositionComponent(New Vector2i(70, 270)),
            New SpriteComponent("shift", , 0.5)
        )

        ' left mouse -> shoot
        AddEntity(
            New TextComponent("Shoot",, 0.5),
            New PositionComponent(New Vector2i(560, 360))
        )
        AddEntity(
            New PositionComponent(New Vector2i(560, 180)),
            New SpriteComponent("mouse", , 0.5)
        )

        ' title
        AddEntity(
            New TextComponent("Controls", , 1.5),
            New PositionComponent(New Vector2i(50, 50))
        )

        ' back button
        AddEntity(New TextButtonEntity("Back", New Vector2i(330, 470), Sub() scenes.Open("Title")))
    End Sub
End Class
