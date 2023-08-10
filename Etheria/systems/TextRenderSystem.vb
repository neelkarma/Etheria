Imports SFML.Graphics
Imports SFML.System

Public Class TextRenderSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Text", "Position")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim text = entity.GetComponent(Of TextComponent)("Text")
            Dim position = entity.GetComponent(Of PositionComponent)("Position")

            Dim textRenderable = text.Text
            textRenderable.Position = position.pos
            Window.Draw(textRenderable)
        Next
    End Sub
End Class
