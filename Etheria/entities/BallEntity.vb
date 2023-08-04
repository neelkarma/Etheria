Imports SFML.Graphics
Imports SFML.System

Public Class BallEntity
    Inherits Entity

    Private Const size = 30

    Public Sub New()
        AddComponents(
            New BallComponent,
            New PositionComponent(New Vector2i((windowWidth - size) / 2, (windowHeight - size) / 2)),
            New VelocityComponent(New Vector2i(5, 5)),
            New SizeComponent(New Vector2i(size, size)),
            New ColliderComponent(New IntRect(0, 0, size, size)),
            New ColorComponent(Color.White)
        )
    End Sub

End Class
