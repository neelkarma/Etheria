Imports SFML.System

Public Class EnemyEntity
    Inherits Entity

    Public Sub New(enemyInfo As EnemyInfo)
        Dim sprite = New SpriteComponent(enemyInfo.spriteName,, enemyInfo.spriteScale)
        Dim bounds = sprite.Sprite.GetGlobalBounds()

        Dim y = If(bounds.Height < windowHeight / 2, rng.Next(bounds.Height, windowHeight - bounds.Height), rng.Next(windowHeight - bounds.Height, bounds.Height))
        AddComponents(
            New PositionComponent(New Vector2f(windowWidth, y)),
            New VelocityComponent(New Vector2f(-enemyInfo.speed, 0)),
            sprite,
            New ColliderComponent(),
            New EnemyComponent(enemyInfo)
        )
    End Sub
End Class
