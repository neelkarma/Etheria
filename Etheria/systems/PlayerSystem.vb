Imports SFML.Graphics
Imports SFML.System
Imports SFML.Window

Public Class PlayerSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Position", "Velocity", "Collider")
    End Function

    Public Overrides Sub Init(entities As IEnumerable(Of Entity))
        score = 0
    End Sub


    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim player = entity.GetComponent(Of PlayerComponent)("Player")
            Dim sprite = entity.GetComponent(Of SpriteComponent)("Sprite")
            Dim collider = entity.GetComponent(Of ColliderComponent)("Collider")



            For Each f As Entity In collider.collisions
                If f.HasComponent("EnemyProjectileComponent") Then
                    If Not player.invulnerable Then
                        player.lives -= 1

                    End If
                End If
            Next

            If player.lives < 0 And Not player.dead Then 'kys
                player.dead = True
                ' Dim debris particles etc
            ElseIf player.lives >= 0 And player.dead Then 'respawn
                player.dead = False
                sprite.hidden = True
                '_transformComponent.pos = New Vector2i(0, 294)
            End If
            If player.dead Then
                sprite.hidden = False
            End If
        Next
    End Sub
End Class
