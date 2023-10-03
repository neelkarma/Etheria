Imports SFML.System
Imports SFML.Window

Public Class ControlsScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "Controls"

    Public Overrides Sub InitEntities()
        ' p to pause
        AddEntity(
            New TextComponent("P - Pause",, 14),
            New PositionComponent(New Vector2f(50, 200))
        )

        ' wasd -> movement
        AddEntity(
            New TextComponent("Move",, 14),
            New PositionComponent(New Vector2f(300, 370))
        )
        AddEntity(
            New PositionComponent(New Vector2f(300, 230)),
            New SpriteComponent("wasd", , 0.5)
        )

        ' shift -> speed up
        AddEntity(
            New TextComponent("Speed Up",, 14),
            New PositionComponent(New Vector2f(70, 345))
        )
        AddEntity(
            New PositionComponent(New Vector2f(70, 270)),
            New SpriteComponent("shift", , 0.5)
        )

        ' left mouse -> shoot
        AddEntity(
            New TextComponent("Shoot",, 14),
            New PositionComponent(New Vector2f(560, 360))
        )
        AddEntity(
            New PositionComponent(New Vector2f(560, 180)),
            New SpriteComponent("mouse", , 0.5)
        )

        ' title
        AddEntity(
            New TextComponent("Controls", , 42),
            New PositionComponent(New Vector2f(50, 50))
        )

        ' back button
        AddEntity(New TextButtonEntity("Back", New Vector2f(330, 470), Sub() scenes.Open("Title")))
    End Sub
End Class
