Imports SFML.Graphics
Imports SFML.System
Imports SFML.Window

Public Class SliderSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Position", "Interactable", "Collider", "Slider")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim interactable = entity.GetComponent(Of InteractableComponent)("Interactable")
            Dim slider = entity.GetComponent(Of SliderComponent)("Slider")
            Dim collider = entity.GetComponent(Of ColliderComponent)("Collider")
            Dim position = entity.GetComponent(Of PositionComponent)("Position")

            ' if the mouse is being held, set the slider value and call the action.
            If interactable.isHeld Then
                ' update the value
                Dim mousePos = Mouse.GetPosition(Window)
                slider.value = Math.Clamp((mousePos.X - position.pos.X) / collider.rect.Width, 0, 1)

                ' call the action
                slider.action(slider.value)
            End If

            ' render the slider
            ' Dim outerRect As New RectangleShape(New Vector2i(collider.rect.Width, collider.rect.Height)) With {
            ' .Position = position ==
            ' }

        Next
    End Sub
End Class
