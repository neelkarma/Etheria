Imports SFML.Graphics
Imports SFML.System
Imports SFML.Window

Public Class GameScene
    Inherits Scene
    Public Overrides ReadOnly Property Type As String = "Game"

    Const durationSeconds = 60

    Private frameCount As Integer
    Private paused As Boolean

    Public Overrides Sub Open(Optional init As Boolean = True)
        MyBase.Open(init)
        frameCount = 0
        paused = False
        audio.PlayBGM($"lvl{session.TrueLevel}")
    End Sub

    Public Overrides Sub Update()
        ' i know putting pause in update is bad but i'm lazy
        ' its the only way to preserve scene state without a major rework of things

        If KeyWasPressed(Keyboard.Key.P) Or KeyWasPressed(Keyboard.Key.Escape) Then paused = Not paused

        If paused Then
            Window.Draw(New Text("PAUSED", font, 36) With {
                .Position = New Vector2f(50, 50),
                .FillColor = Color.White
            })
            Window.Draw(New Text("Press P or Escape to unpause", font, 24) With {
                .Position = New Vector2f(50, 120),
                .FillColor = Color.White
            })
            Window.Draw(New Text("Press Q to quit", font, 24) With {
                .Position = New Vector2f(50, 170),
                .FillColor = Color.White
            })
            If Keyboard.IsKeyPressed(Keyboard.Key.Q) Then scenes.Open("Title")
            Return
        End If

        MyBase.Update()

        frameCount += 1

        If frameCount / fps > durationSeconds Then
            audio.PlaySFX("level-clear")
            scenes.Open("Shop")
        End If
    End Sub

    Public Overrides Sub InitEntities()
        ' scrolling background
        AddEntity(New ScrollingBackgroundComponent($"lvl{session.TrueLevel}-bg",, 1.5))

        ' level, score, high score, shinies
        AddEntity(New PlayerHUDEntity(Function() $"LVL {session.level}  SCORE {session.score}  {session.shinies} SHN  TIME {durationSeconds - CInt(frameCount / fps)}", New Vector2f(5, 5)))

        ' lives
        AddEntity(
            New LivesComponent(),
            New PositionComponent(New Vector2f(windowWidth - 5, 5))
        )

        ' player
        AddEntity(New PlayerEntity())

        ' enemy spawner
        AddEntity(New EnemySpawnerComponent(90, 30))
    End Sub
End Class
