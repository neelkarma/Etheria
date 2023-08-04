Imports SFML.Graphics
Imports SFML.System

Public Class PaddleEntity
    Inherits Entity

    Private Const padding = 10
    Private Const width = 20
    Private Const height = 200

    Public Sub New(side As PlayerSide)
        Dim x As Integer

        Select Case side
            Case PlayerSide.Left
                x = padding
            Case PlayerSide.Right
                x = windowWidth - width - padding
        End Select

        AddComponents(
            New PaddleComponent(side),
            New PositionComponent(New Vector2i(x, (windowHeight - height) / 2)),
            New VelocityComponent,
            New SizeComponent(New Vector2i(width, height)),
            New ColliderComponent(New IntRect(0, 0, width, height)),
            New ColorComponent(Color.White)
        )
    End Sub

End Class
