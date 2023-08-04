Imports SFML.Window

Public Class InteractableSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Interactable", "Position", "Collider")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim position = entity.GetComponent(Of PositionComponent)("Position")
            Dim collider = entity.GetComponent(Of ColliderComponent)("Collider")
            Dim interactable = entity.GetComponent(Of InteractableComponent)("Interactable")
            Dim rect = GetGlobalRect(position, collider)
            Dim mousePosition = Mouse.GetPosition(Window)

            interactable.isHovered = rect.Contains(mousePosition.X, mousePosition.Y)
            interactable.isHeld = interactable.isHovered And Mouse.IsButtonPressed(Mouse.Button.Left)
            interactable.wasClicked = interactable.isHeld And Not interactable.wasHeldLastFrame

            interactable.wasHeldLastFrame = Mouse.IsButtonPressed(Mouse.Button.Left)
        Next
    End Sub
End Class
