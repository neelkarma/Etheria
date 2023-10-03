Imports SFML.System

Public Class TextButtonEntity
    Inherits Entity

    Public Sub New(text As String, position As Vector2f, action As Action)
        AddComponents(
            New TextComponent(text),
            New PositionComponent(position),
            New ColliderComponent,
            New ButtonComponent(action),
            New InteractableComponent,
            New TextButtonComponent
        )
    End Sub

End Class
