﻿Imports SFML.System

Public Class ConfirmExitScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "ConfirmExit"

    Public Overrides Sub InitEntities()
        ' text
        AddEntity(
            New TextComponent("Are you sure you want to exit?",, 24),
            New PositionComponent(New Vector2f(50, 50))
        )

        ' yes button
        AddEntity(New TextButtonEntity("Yes", New Vector2f(50, 100), Sub() Window.Close()))

        ' no button
        AddEntity(New TextButtonEntity("No", New Vector2f(200, 100), Sub() scenes.Open("Title")))
    End Sub
End Class
