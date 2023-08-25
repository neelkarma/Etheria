Imports SFML.Graphics
Imports SFML.System

Public Class SliderEntity
    Inherits Entity

    Private Const size = 30

    Public Sub New(sound As String, x As Integer, y As Integer, leftX As Integer, rightX As Integer, action As Action(Of Decimal))
        MyBase.New()
        AddComponents(
            New PositionComponent(New Vector2i(x, y)),
            New ColliderComponent(New IntRect(0, 0, size, size)),
            New InteractableComponent(),
            New SliderComponent(sound, leftX, rightX, action)
        )
    End Sub


End Class
