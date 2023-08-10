Imports SFML.System

Public Class TestScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "Test"

    Public Overrides Sub InitEntities()
        AddEntity(
            New PositionComponent(New Vector2i(0, 0)),
            New SpriteComponent("sampleSingle")
        )

        AddEntity(
            New PositionComponent(New Vector2i(300, 0)),
            New SpriteComponent("sampleAnimation", 10)
        )
    End Sub
End Class
