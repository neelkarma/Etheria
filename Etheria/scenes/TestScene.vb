Imports SFML.System

Public Class TestScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "Test"

    Public Overrides Sub InitEntities()
        AddEntity(
            New InitialInputComponent(),
            New PositionComponent(New Vector2i(50, 50))
        )
    End Sub
End Class
