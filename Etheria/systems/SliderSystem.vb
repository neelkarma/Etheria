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
            Dim mousePos = Mouse.GetPosition(Window)

            ' if the mouse is being held, set the slider value and call the action.
            If interactable.isHeld Then
                Console.WriteLine("Held")
            End If
            If interactable.isHeld And GetGlobalRect(position, collider).Contains(mousePos.X, mousePos.Y) Or slider.dragging Then
                slider.dragging = True
                ' update the value
                position.pos.X = Math.Clamp(mousePos.X, slider.leftX, slider.rightX)

                Dim value = (position.pos.X - slider.leftX) / (slider.rightX - slider.leftX)
                slider.action(value)
            ElseIf Not interactable.isHeld Then
                slider.dragging = False
            End If

            ' render the slider
            Dim barRect As New RectangleShape() With {
                .Position = New Vector2i(slider.leftX, position.pos.Y),
                .FillColor = New Color(200, 200, 200),
                .Size = New Vector2i(slider.rightX - slider.leftX, collider.rect.Height)
            }
            Dim handleRect As New RectangleShape() With {
                .Position = New Vector2i(position.pos.X, position.pos.Y),
                .FillColor = Color.White,
                .Size = New Vector2i(collider.rect.Width, collider.rect.Height)
            }
            Window.Draw(barRect)
            Window.Draw(handleRect)

        Next
    End Sub
End Class
