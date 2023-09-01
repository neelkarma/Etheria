Public Class SpriteRenderSystem
    Inherits System
    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Position", "Sprite")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim sprite = entity.GetComponent(Of SpriteComponent)("Sprite")

            If sprite.hidden Then
                Continue For
            End If

            Dim position = entity.GetComponent(Of PositionComponent)("Position")

            Dim spriteRenderable = sprite.Sprite
            spriteRenderable.Position = position.pos

            Window.Draw(spriteRenderable)
        Next
    End Sub
End Class
