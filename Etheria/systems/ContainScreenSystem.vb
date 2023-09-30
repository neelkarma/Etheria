Public Class ContainScreenSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Position", "Collider", "ContainScreen")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim position = entity.GetComponent(Of PositionComponent)("Position")
            Dim collider = entity.GetComponent(Of ColliderComponent)("Collider")

            position.pos.X = Math.Clamp(position.pos.X, 0, windowWidth - collider.rect.Width)
            position.pos.Y = Math.Clamp(position.pos.Y, 0, windowHeight - collider.rect.Height)
        Next
    End Sub
End Class