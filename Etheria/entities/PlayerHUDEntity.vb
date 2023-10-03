Imports SFML.System

Public Class PlayerHUDEntity
    Inherits Entity

    Public Sub New(content As Func(Of String), position As Vector2f)
        AddComponents(
            New TextComponent("",, 16),
            New ReactiveTextComponent(content),
            New PositionComponent(position)
        )
    End Sub

End Class
