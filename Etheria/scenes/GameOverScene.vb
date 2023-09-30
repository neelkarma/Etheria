Imports System.Runtime.InteropServices
Imports System.Threading
Imports SFML.System

Public Class GameOverScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "GameOver"

    Public Overrides Sub Open(Optional init As Boolean = True)
        MyBase.Open(init)
        audio.PlayBGM("gameover")
    End Sub

    Public Overrides Sub InitEntities()
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
            ' leaderboard message
            AddEntity(
                    New TextComponent("Congratulations! You made the leaderboard!",, 0.5),
                    New PositionComponent(New Vector2i(50, 200))
                )
            AddEntity(
                New TextComponent("Type your initials below (3 letters):",, 0.5),
                New PositionComponent(New Vector2i(50, 250))
            )

            ' initial input
            AddEntity(
                New InitialInputComponent(),
                New PositionComponent(New Vector2i(50, 300))
            )

            ' continue button is added in the InitialInputSystem on completion
        Else
            AddEntity(New TextButtonEntity("Continue", New Vector2i(50, 250), Sub() scenes.Open("Title")))
        End If

        ' continue button
    End Sub
End Class
