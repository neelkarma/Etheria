Imports SFML.Graphics

Public Class ShopItemButtonSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Rect", "Interactable", "ShopItemButton")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim rect = entity.GetComponent(Of RectComponent)("Rect")
            Dim interactable = entity.GetComponent(Of InteractableComponent)("Interactable")

            rect.outlineColor = If(interactable.isHovered, Color.Green, Color.White)
        Next
    End Sub
End Class
