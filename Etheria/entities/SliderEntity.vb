Imports SFML.Graphics
Imports SFML.System

Public Class SliderEntity
    Inherits Entity

    Private Const size = 30

    Public Sub New(_type As String, x As Integer, y As Integer, leftX As Integer, rightX As Integer)
        MyBase.New()
        AddComponents(
            New SpriteComponent("SliderHandle"),
           New TransformComponent(x, y, 0, 0),
           New ColliderComponent(New IntRect(0, 0, size, size)),
           New InteractableComponent(),
           New SliderComponent(_type, x, y, leftX, rightX)
        )
    End Sub


End Class
