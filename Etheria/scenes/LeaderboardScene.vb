﻿Imports SFML.System

Public Class LeaderboardScene
    Inherits Scene
    Public Overrides ReadOnly Property Type As String = "Leaderboard"

    Public Overrides Sub InitEntities()
        AddEntity(New MenuBackgroundEntity())
        AddEntity(
            New TextComponent("Highscores", Nothing, 1.5),
            New PositionComponent(New Vector2i(200, 15))
        )

        AddEntity(New TextButtonEntity("Back", New Vector2i(330, 470), Sub() scenes.Open("Title")))

        Const scorePadding As Integer = 35

        For i = 0 To 9
            'New PositionComponent(New Vector2i(windowWidth / 2 - CalculateTextRect("00:    000000").Width / 2, 60 + 15 * i))
            AddEntity(
                New TextComponent($"{(i + 1).ToString(StrDup(2, "0"))}:    {highscores(i).ToString(StrDup(scorePadding, "0"))}"),
                New PositionComponent(New Vector2i(200, 60 + 15 * i))
            )
        Next


    End Sub

End Class
