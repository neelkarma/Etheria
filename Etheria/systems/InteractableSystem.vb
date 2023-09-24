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
            interactable.isHeld = Mouse.IsButtonPressed(Mouse.Button.Left) And ((interactable.isHovered And InteractableComponent.holdIsLocked = -1) Or (InteractableComponent.holdIsLocked = entity.id))
            If interactable.isHeld Then
                InteractableComponent.holdIsLocked = entity.id
            End If
            interactable.wasClicked = interactable.isHeld And Not mouseWasHeldLastFrame
            interactable.wasReleased = (Not interactable.isHeld) And mouseWasHeldLastFrame And InteractableComponent.holdIsLocked = entity.id
            If InteractableComponent.holdIsLocked = entity.id And Not Mouse.IsButtonPressed(Mouse.Button.Left) Then
                InteractableComponent.holdIsLocked = -1
            End If
        Next
    End Sub
End Class
