Imports SFML.System

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

        Const scorePadding As Integer = 60
        Const scoreGap As Integer = 40

        For Each entry In Enumerate(leaderboard.Leaderboard)
            Dim i = entry.Item1
            Dim lbEntry = entry.Item2
            Dim name = lbEntry.Item1
            Dim score = lbEntry.Item2

            AddEntity(
                New TextComponent($"{(i + 1):D2}: {name} {score:D8}",, 0.8),
                New PositionComponent(New Vector2i(100, scorePadding + (scoreGap * i)))
            )
        Next
    End Sub
End Class
