Imports SFML.System

Public Class RectRenderSystem
    Inherits System
    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Position", "Rect")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim position = entity.GetComponent(Of PositionComponent)("Position")
            Dim rect = entity.GetComponent(Of RectComponent)("Rect")

            Dim renderable = rect.DrawableRect
            renderable.Position += New Vector2f(position.pos.X, position.pos.Y)

            Window.Draw(renderable)
        Next
    End Sub
End Class
