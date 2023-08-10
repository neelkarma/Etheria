Public Class SceneManager
    Public currentSceneName As String

    Public ReadOnly Property CurrentScene As Scene
        Get
            Return scenes(currentSceneName)
        End Get
    End Property
    Private ReadOnly scenes As New Dictionary(Of String, Scene)

    Public Sub New()
        ' init scenes
        Dim title As New TitleScene
        Dim game As New GameScene
        Dim endScene As New EndScene

        scenes(title.Type) = title
        scenes(game.Type) = game
        scenes(endScene.Type) = endScene

        Open(title.Type)
    End Sub

    Public Sub Open(name As String, Optional init As Boolean = True)
        currentSceneName = name
        CurrentScene.Open(init)
    End Sub
End Class
