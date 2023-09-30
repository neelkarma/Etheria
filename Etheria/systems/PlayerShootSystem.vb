Imports SFML.System
Imports SFML.Window

Public Class PlayerShootSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Player", "Position")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim player = entity.GetComponent(Of PlayerComponent)("Player")
            Dim position = entity.GetComponent(Of PositionComponent)("Position")

            player.fireRate = If(session.equippedPowerup = Powerup.DoubleShot, 5, 10)

            Dim isTriggered = Mouse.IsButtonPressed(Mouse.Button.Left) Or session.equippedPowerup = Powerup.AutoShoot
            Dim canShoot = player.framesUntilCanFire <= 0

            If isTriggered And canShoot Then
                Dim bulletEntity = New BulletEntity("player-bullet", New Vector2i(15, 0), position.pos + New Vector2i(100, 50))
                bulletEntity.AddComponent(New PlayerBulletComponent())
                scenes.CurrentScene.AddEntity(bulletEntity)
                player.framesUntilCanFire = player.fireRate
            End If

            player.framesUntilCanFire -= 1
        Next
    End Sub
End Class
