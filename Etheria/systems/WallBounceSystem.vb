Imports SFML.System

Public Class WallBounceSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Ball", "Position", "Velocity", "Collider")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim position = entity.GetComponent(Of PositionComponent)("Position")
            Dim velocity = entity.GetComponent(Of VelocityComponent)("Velocity")
            Dim collider = entity.GetComponent(Of ColliderComponent)("Collider")

            If position.pos.Y < 0 Then
                velocity.vel.Y = Math.Abs(velocity.vel.Y)
            ElseIf position.pos.Y > windowHeight - collider.rect.Height Then
                velocity.vel.Y = -Math.Abs(velocity.vel.Y)
            End If

            If position.pos.X < 0 Or position.pos.X > windowWidth - collider.rect.Width Then
                scenes.Open("End")
            End If
        Next
    End Sub
End Class
