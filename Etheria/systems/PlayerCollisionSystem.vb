Imports SFML.Graphics
Imports SFML.System

Public Class PlayerCollisionSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Player", "Collider", "Position")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim player = entity.GetComponent(Of PlayerComponent)("Player")
            Dim position = entity.GetComponent(Of PositionComponent)("Position")
            Dim collider = entity.GetComponent(Of ColliderComponent)("Collider")

            ' skip if the player is invincible
            If player.invincibilityFrames > 0 Then
                player.invincibilityFrames -= 1

                ' draw invincibility barrier
                Dim rect = GetGlobalRect(position, collider)
                Window.Draw(New RectangleShape(New Vector2i(rect.Width, rect.Height)) With {
                    .FillColor = Color.Transparent,
                    .OutlineColor = Color.Yellow,
                    .OutlineThickness = 3,
                    .Position = New Vector2i(rect.Left, rect.Top)
                })

                Continue For
            End If

            Dim enemyBullet = collider.collisions.Find(Function(ent As Entity) ent.HasComponent("EnemyBullet"))

            If IsNothing(enemyBullet) Then Continue For ' no collision

            scenes.CurrentScene.RemoveEntity(enemyBullet)
            session.lives -= 1
            player.invincibilityFrames = 300

            If session.lives <= 0 Then ' die
                audio.PlaySFX("player-death")
                scenes.Open("GameOver")
            End If
        Next
    End Sub
End Class
