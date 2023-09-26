Imports SFML.System
Imports SFML.Window

Public Class ControlsScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "Controls"

    Public Overrides Sub InitEntities()
        ' menu background
        AddEntity(
            New MenuBackgroundEntity()
        )

        ' shift -> activate powerup
        AddEntity(
            New TextComponent("Use Powerup",, 0.5),
            New PositionComponent(New Vector2i(250, 355))
        )
        AddEntity(
            New PositionComponent(New Vector2i(250, 290)),
            New SpriteComponent("spacebar",, 0.5)
        )

        ' wasd -> movement
        AddEntity(
            New TextComponent("Move",, 0.5),
            New PositionComponent(New Vector2i(230, 160))
        )
        AddEntity(
            New PositionComponent(New Vector2i(250, 155)),
            New SpriteComponent("wasd", , 0.5)
        )

        ' shift -> speed up
        AddEntity(
            New TextComponent("Speed Up",, 0.5),
            New PositionComponent(New Vector2i(70, 325))
        )
        AddEntity(
            New PositionComponent(New Vector2i(70, 250)),
            New SpriteComponent("shift", , 0.5)
        )

        ' left mouse -> shoot
        AddEntity(
            New TextComponent("Shoot",, 0.5),
            New PositionComponent(New Vector2i(560, 340))
        )
        AddEntity(
            New PositionComponent(New Vector2i(560, 160)),
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
