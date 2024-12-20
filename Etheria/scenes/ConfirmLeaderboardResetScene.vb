﻿Imports SFML.System

Public Class ConfirmLeaderboardResetScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "ConfirmLeaderboardReset"

    Public Overrides Sub InitEntities()
        ' text
        AddEntity(
            New TextComponent("Are you sure you want to reset the leaderboard?",, 14),
            New PositionComponent(New Vector2f(50, 50))
        )
        AddEntity(
            New TextComponent("This action is irreversible.",, 14),
            New PositionComponent(New Vector2f(50, 100))
        )

        ' yes button
        AddEntity(New TextButtonEntity("Yes", New Vector2f(50, 150), Sub()
                                                                         leaderboard.Reset()
                                                                         scenes.Open("Title")
                                                                     End Sub))

        ' no button
        AddEntity(New TextButtonEntity("No", New Vector2f(200, 150), Sub() scenes.Open("Title")))
    End Sub
End Class
