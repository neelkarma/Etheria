Public Class TextColliderSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Text", "Collider")
    End Function

    Public Overrides Sub Init(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim text = entity.GetComponent(Of TextComponent)("Text")
            Dim collider = entity.GetComponent(Of ColliderComponent)("Collider")

            collider.rect = text.Text.GetLocalBounds()
        Next
    End Sub
End Class
