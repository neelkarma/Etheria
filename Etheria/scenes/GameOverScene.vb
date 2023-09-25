Imports System.Runtime.InteropServices
Imports System.Threading
Imports SFML.System

Public Class GameOverScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "GameOver"

    Public Overrides Sub InitEntities()
        ' menu background
        AddEntity(New MenuBackgroundEntity())

        ' game over title

        AddEntity(
            New TextComponent("Game Over",, 1.5),
            New PositionComponent(New Vector2i(50, 50))
        )

        ' score: {score} (Level {level})
        AddEntity(
            New TextComponent($"Score: {session.score} (Level {session.level})"),
            New PositionComponent(New Vector2i(50, 120))
        )

        ' check if score made the leaderboard
        If leaderboard.CheckScore(session.score) Then
            AddEntity(
                New TextComponent("Congratulations! You made the leaderboard!"),
                New PositionComponent(New Vector2i(50, 200))
            )
            AddEntity(
                New TextComponent("Type your initials below:"),
                New PositionComponent(New Vector2i(50, 250))
            )

            AddEntity(
                New InitialInputComponent(),
                New PositionComponent(New Vector2i(50, 300))
            )
            AddEntity(New TextButtonEntity("Continue", New Vector2i(50, 350), Sub() scenes.Open("Title")))
        Else
            AddEntity(New TextButtonEntity("Continue", New Vector2i(50, 250), Sub() scenes.Open("Title")))
        End If

        ' continue button
    End Sub
End Class
