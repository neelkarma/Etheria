Imports System.Net.Security

Public Class SceneManager
    Public currentSceneName As String
    Public sceneJustChanged As Boolean = False

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
        Dim leaderboard As New LeaderboardScene
        Dim test As New TestScene
        Dim settings As New SettingsScene
        Dim shipSelect As New ShipSelectScene
        Dim gameOver As New GameOverScene
        Dim confirmExit As New ConfirmExitScene
        Dim shop As New ShopScene

        scenes(title.Type) = title
        scenes(shipSelect.Type) = shipSelect
        scenes(controls.Type) = controls
        scenes(game.Type) = game
        scenes(test.Type) = test
        scenes(leaderboard.Type) = leaderboard
        scenes(settings.Type) = settings
        scenes(gameOver.Type) = gameOver
        scenes(confirmExit.Type) = confirmExit
        scenes(shop.Type) = shop

        Open(initialScene)
    End Sub

    Public Sub Open(name As String, Optional init As Boolean = True)
        currentSceneName = name
        sceneJustChanged = True

        ' this is here as a crappy solution to InteractableComponent.holdIsLocked not being reset on scene change (i.e. if the held entity was destroyed)
        InteractableComponent.holdIsLocked = -1

        CurrentScene.Open(init)
    End Sub
End Class
