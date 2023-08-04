Public Class VelocitySystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Position", "Velocity")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim position = entity.GetComponent(Of PositionComponent)("Position")
            Dim velocity = entity.GetComponent(Of VelocityComponent)("Velocity")
            position.pos += velocity.vel
        Next
    End Sub
End Class
