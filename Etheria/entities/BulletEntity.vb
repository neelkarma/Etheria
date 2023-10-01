﻿Imports SFML.System

Public Class BulletEntity
    Inherits Entity

    Public Sub New(spriteName As String, velocity As Vector2i, initialPosition As Vector2i, Optional scale As Single = 0.3)
        AddComponents(
            New PositionComponent(initialPosition),
            New VelocityComponent(velocity),
            New SpriteComponent(spriteName,, scale),
            New ColliderComponent(),
            New DestroyOnLeaveComponent()
        )
    End Sub
End Class