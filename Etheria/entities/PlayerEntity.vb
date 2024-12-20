﻿Imports SFML.Graphics
Imports SFML.System

Public Class PlayerEntity
    Inherits Entity

    Public Sub New()
        Dim spriteComponent As New SpriteComponent(session.shipSprite, , 0.3,, False)
        Dim spriteBounds = spriteComponent.Sprite.GetGlobalBounds()

        AddComponents(
            spriteComponent,
            New VelocityComponent(),
            New PositionComponent(New Vector2f(15, windowHeight / 2)),
            New PlayerComponent(),
            New ColliderComponent(New FloatRect(60, 45, 50, 15)),
            New ContainScreenComponent()
        )
    End Sub
End Class
