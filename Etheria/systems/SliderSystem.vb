﻿Imports SFML.Graphics
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

            Dim mousePos = GetMousePosition()
            Dim handleBounds = GetGlobalRect(position, collider)

            ' if the mouse is being held, set the slider value and call the action.
            If interactable.isHeld And handleBounds.Contains(mousePos.X, mousePos.Y) Or slider.dragging Then
                If Not slider.dragging Then
                    slider.dragging = True
                    slider.offset = handleBounds.Left - mousePos.X
                End If

                ' update the value
                position.pos.X = Math.Clamp(mousePos.X + slider.offset, slider.leftX, slider.rightX)

                Dim value = (position.pos.X - slider.leftX) / (slider.rightX - slider.leftX)
                slider.action(value)
            End If

            If Not interactable.isHeld And Not mouseWasHeldLastFrame Then
                slider.dragging = False
            End If

            ' render the slider
            Dim barRect As New RectangleShape() With {
                .Position = New Vector2f(slider.leftX, position.pos.Y),
                .FillColor = New Color(150, 150, 150),
                .Size = New Vector2f(slider.rightX - slider.leftX + collider.rect.Width, collider.rect.Height)
            }
            Dim handleRect As New RectangleShape() With {
                .Position = New Vector2f(position.pos.X, position.pos.Y),
                .FillColor = Color.White,
                .Size = New Vector2f(collider.rect.Width, collider.rect.Height)
            }

            Window.Draw(barRect)
            Window.Draw(handleRect)
        Next
    End Sub
End Class
