Imports SFML.Window
Imports SFML.Graphics
Imports SFML.System
Public Class PLayer
    Inherits Entity
    Private Const width = -1
    Private Const height = -1

    Public Sub New(Optional ByVal c As String = "Pink", Optional num As Integer = 1, Optional x As Integer = 0, Optional y As Integer = 0)
        MyBase.New()
        AddComponents(
            New SpriteComponent("player", , New Vector2f(1.2, 1.2)),
            New PlayerComponent(c),
            New ColliderComponent(New IntRect(0, 0, width, height)),
            New AutoShootComponent("basic", 10, 35, 7),
            New ScreenColliderComponent("collide", 11, 1, 37, 13),
            New PlayerControlComponent()
        )

    End Sub
End Class
