Imports SFML.System

Public Class SpriteEntity
    Inherits Entity

    Public Sub New(Optional x As Integer = 0, Optional y As Integer = 0, Optional s As String = "error", Optional layer As Integer = 4)

        'AddComponents(
        'New SpriteComponent(s, layer),
        'New TransformComponent(x, y, 0, 0)
        ')
    End Sub

End Class

