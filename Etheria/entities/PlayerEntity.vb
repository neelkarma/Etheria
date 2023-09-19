Imports SFML.Graphics
Imports SFML.System
Public Class PlayerEntity
    Inherits Entity

    Public Sub New(Optional playerColor As String = "blue")
        Dim spriteComponent As New SpriteComponent($"ship-{playerColor}", , 0.8)
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
