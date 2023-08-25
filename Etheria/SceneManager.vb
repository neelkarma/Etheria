Public Class SceneManager
    Public currentSceneName As String

    Public ReadOnly Property CurrentScene As Scene
        Get
            Return scenes(currentSceneName)
        End Get
    End Property
    Private ReadOnly scenes As New Dictionary(Of String, Scene)

    Public Sub New(initialScene As String)
        ' init scenes
        Dim title As New TitleScene
        Dim controls As New ControlsScene
        Dim game As New GameScene
        Dim endScene As New EndScene
        Dim leaderboard As New LeaderboardScene
        Dim test As New TestScene
        Dim settings As New SettingsScene

        scenes(title.Type) = title
        scenes(controls.Type) = controls
        scenes(game.Type) = game
        scenes(endScene.Type) = endScene
        scenes(test.Type) = test
        scenes(leaderboard.Type) = leaderboard
        scenes(settings.Type) = settings

        Open(initialScene)
    End Sub

    Public Sub Open(name As String, Optional init As Boolean = True)
        currentSceneName = name
        CurrentScene.Open(init)
    End Sub
End Class
