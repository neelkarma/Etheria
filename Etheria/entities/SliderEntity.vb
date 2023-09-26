Imports SFML.Graphics
Imports SFML.System

Public Class SliderEntity
    Inherits Entity

    Private Const size = 30

    Public Sub New(y As Integer, leftX As Integer, rightX As Integer, action As Action(Of Decimal), Optional initialValue As Decimal = 0)
        Dim initialX = initialValue * (rightX - leftX) + leftX

        AddComponents(
            New PositionComponent(New Vector2i(initialX, y)),
            New ColliderComponent(New IntRect(0, 0, size, size)),
            New InteractableComponent(),
            New SliderComponent(leftX, rightX, action)
        )
    End Sub


End Class
