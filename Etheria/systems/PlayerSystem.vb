Public Class PlayerSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Player", "Collider")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim player = entity.GetComponent(Of PlayerComponent)("Player")
            Dim collider = entity.GetComponent(Of ColliderComponent)("Collider")



            For Each f As Entity In collider.collisions
                If f.HasComponent("EnemyProjectileComponent") Then
                    If Not player.invulnerable Then
                        session.lives -= 1
                    End If
                End If
            Next

            If session.lives <= 0 Then
                ' kill player
                scenes.Open("GameOver")
            End If
        Next
    End Sub
End Class
