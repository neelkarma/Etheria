Imports SFML.Graphics

Public Class RectRenderSystem
    Inherits System
    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Position", "Size", "Color")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim position = entity.GetComponent(Of PositionComponent)("Position")
            Dim size = entity.GetComponent(Of SizeComponent)("Size")
            Dim color = entity.GetComponent(Of ColorComponent)("Color")

            Window.Draw(New RectangleShape(size.size) With {
                .Position = position.pos,
                .FillColor = color.color
            })
        Next
    End Sub
End Class
