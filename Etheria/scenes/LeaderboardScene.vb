﻿Imports SFML.System

Public Class LeaderboardScene
    Inherits Scene
    Public Overrides ReadOnly Property Type As String = "Leaderboard"

    Public Overrides Sub InitEntities()
        ' title
        AddEntity(
            New TextComponent("Leaderboard",, 42),
            New PositionComponent(New Vector2f(50, 50))
        )

        ' leaderboard entries
        Const scorePadding As Integer = 120
        Const scoreGap As Integer = 40

        For Each entry In Enumerate(leaderboard.Leaderboard)
            Dim i = entry.Item1
            Dim lbEntry = entry.Item2
            Dim name = lbEntry.Item1
            Dim score = lbEntry.Item2

            AddEntity(
                New TextComponent($"{(i + 1):D2}: {name} {score:D8}",, 24),
                New PositionComponent(New Vector2f(50, scorePadding + (scoreGap * i)))
            )
        Next

        ' back button
        AddEntity(New TextButtonEntity("Back", New Vector2f(50, 530), Sub() scenes.Open("Title")))
    End Sub
End Class
