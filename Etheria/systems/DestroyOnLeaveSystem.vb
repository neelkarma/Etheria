Public Class DestroyOnLeaveSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("DestroyOnLeave", "Position")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim position = entity.GetComponent(Of PositionComponent)("Position")

            If position.pos.X < 0 Or position.pos.X > windowWidth Or position.pos.Y < 0 Or position.pos.Y > windowHeight Then scenes.CurrentScene.RemoveEntity(entity)
        Next
    End Sub
End Class
