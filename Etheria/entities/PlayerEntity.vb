Imports SFML.System
Public Class PlayerEntity
    Inherits Entity

    Public Sub New()
        Dim spriteComponent As New SpriteComponent(session.shipSprite, , 0.3)
        AddComponents(
            spriteComponent,
            New VelocityComponent(),
            New PositionComponent(New Vector2i(15, windowHeight / 2)),
            New PlayerComponent(),
            New ColliderComponent(spriteComponent.Sprite.GetGlobalBounds()),
            New AutoShootComponent(10, New Vector2i(35, 7)),
            New ScreenColliderComponent("collide", 11, 1, 37, 13)
    )
    End Sub
End Class
