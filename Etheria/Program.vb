Imports System
Imports SFML.Graphics
Imports SFML.System
Imports SFML.Window

Public Module Program
    Public Const fps As Integer = 60
    Public Const windowWidth As Integer = 800
    Public Const windowHeight As Integer = 600

    Public Enum PlayerSide
        Left
        Right
    End Enum

    Public winning As PlayerSide = Nothing
    Public windowScale As Integer = 1
    Public ReadOnly font As New Font("../../../resources/fonts/PublicPixel.ttf")
    Public ReadOnly clock As New Clock
    Public ReadOnly scenes As New Dictionary(Of String, Scene)
    Public ReadOnly sprites As New SpriteManager
    Public current_scene As String
    Public WithEvents Window As New RenderWindow(New VideoMode(windowWidth, windowHeight), "Pong")

    Sub Main()
        Window.SetVerticalSyncEnabled(True)

        InitScenes()

        While Window.IsOpen()
            ' enforce set fps
            If clock.ElapsedTime.AsSeconds < 1 / fps Then
                Continue While
            End If
            Dim dt As Single = clock.Restart().AsSeconds()
            ' Console.WriteLine(1 / dt) ' fps

            Window.DispatchEvents()
            Window.Clear()
            scenes(current_scene).Update()
            Window.Display()
        End While
    End Sub

    Sub InitScenes()
        Dim title As New TitleScene
        Dim game As New GameScene
        Dim endScene As New EndScene

        scenes(title.Type) = title
        scenes(game.Type) = game
        scenes(endScene.Type) = endScene

        scenes("Title").Open()
    End Sub
End Module
