﻿Imports SFML.System

Public Class TitleScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "Title"

    Public Overrides Sub InitEntities()
        AddEntity(
            New TextComponent("Etheria", Nothing, 1.5),
            New PositionComponent(New Vector2i(50, 50))
        )

        AddEntity(New TextButtonEntity("Start", New Vector2i(50, 100), Sub() scenes.Open("Game")))
        AddEntity(New TextButtonEntity("Controls", New Vector2i(50, 150), Sub() Console.WriteLine("Controls")))
        AddEntity(New TextButtonEntity("Scoreboard", New Vector2i(50, 200), Sub() Console.WriteLine("Scoreboard")))
        AddEntity(New TextButtonEntity("Settings", New Vector2i(50, 250), Sub() Console.WriteLine("Settings")))
        AddEntity(New TextButtonEntity("Quit", New Vector2i(50, 300), Sub() Window.Close()))
    End Sub
End Class
