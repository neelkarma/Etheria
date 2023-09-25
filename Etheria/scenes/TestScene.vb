Imports SFML.System

Public Class TestScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "Test"

    Public Overrides Sub InitEntities()
        AddEntity(
            New ScrollingBackgroundComponent("menu-bg", 1, 0.5)
        )
    End Sub
End Class
