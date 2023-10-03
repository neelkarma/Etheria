Imports SFML.System

Public Class EnemySystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Enemy", "Position", "Velocity", "Collider")
    End Function


    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim enemy = entity.GetComponent(Of EnemyComponent)("Enemy")
            Dim position = entity.GetComponent(Of PositionComponent)("Position")
            Dim collider = entity.GetComponent(Of ColliderComponent)("Collider")
            Dim velocity = entity.GetComponent(Of VelocityComponent)("Velocity")

            ' keep enemy in the right half of the screen
            position.pos.X = Math.Clamp(position.pos.X, windowWidth / 2, windowWidth)
            If position.pos.X - windowWidth < -1 Then velocity.vel.X = (1 / (position.pos.X - windowWidth)) * 200


            ' shoot
            Dim canShoot = enemy.framesUntilCanFire <= 0
            If canShoot Then
                ' Make bullets shoot in the direction of the player
                Dim bulletOrigin = position.pos + enemy.info.bulletPos

                Dim bulletEntity = New BulletEntity(enemy.info.bulletSprite, New Vector2f(-5, 0), position.pos + enemy.info.bulletPos, enemy.info.bulletScale)
                bulletEntity.AddComponent(New EnemyBulletComponent())

                Dim playerEntity = scenes.CurrentScene.GetEntity(Function(ent) ent.HasComponents("Player", "Position", "Collider"))
                If Not IsNothing(playerEntity) Then
                    Dim bulletBounds = bulletEntity.GetComponent(Of SpriteComponent)("Sprite").Sprite.GetGlobalBounds()
                    Dim bulletCenter = GetRectCenter(GetGlobalRect(New PositionComponent(bulletOrigin), New ColliderComponent(bulletBounds)))

                    Dim playerPos = playerEntity.GetComponent(Of PositionComponent)("Position")
                    Dim playerCollider = playerEntity.GetComponent(Of ColliderComponent)("Collider")
                    Dim playerCenter = GetRectCenter(GetGlobalRect(playerPos, playerCollider))

                    Dim angle = Math.Atan2(playerCenter.Y - bulletCenter.Y, playerCenter.X - bulletCenter.X)

                    Dim bulletVelocity = New Vector2f(Math.Cos(angle) * enemy.info.bulletSpeed, Math.Sin(angle) * enemy.info.bulletSpeed)

                    bulletEntity.AddComponent(New VelocityComponent(bulletVelocity))

                    scenes.CurrentScene.AddEntity(bulletEntity)
                    enemy.framesUntilCanFire = enemy.info.fireRate
                End If
            Else
                enemy.framesUntilCanFire -= 1
            End If

            ' check for collisions with player bullet
            For Each playerBullet In collider.collisions.FindAll(Function(ent As Entity) ent.HasComponent("PlayerBullet"))
                scenes.CurrentScene.RemoveEntity(playerBullet)
                enemy.health -= 1
                If enemy.health <= 0 Then ' die
                    session.score += enemy.info.value * session.level * 100
                    session.shinies += enemy.info.value * rng.Next(1, 20)
                    audio.PlaySFX(enemy.info.deathSfx)
                    scenes.CurrentScene.RemoveEntity(entity)
                Else
                    audio.PlaySFX(enemy.info.hitSfx)
                End If
            Next
        Next
    End Sub
End Class