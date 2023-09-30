Imports SFML.System

Public Class EnemyEntity
    Inherits Entity

    Public Sub New(enemyInfo As EnemyInfo)
        Dim sprite = New SpriteComponent(enemyInfo.spriteName,, enemyInfo.spriteScale)
        Dim bounds = sprite.Sprite.GetGlobalBounds()

        AddComponents(
            New PositionComponent(New Vector2i(windowWidth, rng.Next(bounds.Height, windowHeight - bounds.Height))),
            New VelocityComponent(New Vector2i(-enemyInfo.speed, 0)),
            sprite,
            New ColliderComponent(),
            New EnemyComponent(enemyInfo)
        )
    End Sub
End Class
