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
    Public ReadOnly scenes As New SceneManager("Title")
    Public ReadOnly sprites As New SpriteManager
    Public ReadOnly audio As New AudioManager
    Public highscores As New List(Of Integer)
    Public mouseWasHeldLastFrame As Boolean = False
    Public WithEvents Window As New RenderWindow(New VideoMode(windowWidth, windowHeight), "Pong")

    Sub Main()
        Window.SetVerticalSyncEnabled(True)
        LoadHighScore()
        ' TODO: remove this after some time
        audio.PlayBGM("grass-beach")

        While Window.IsOpen()
            ' enforce set fps
            If clock.ElapsedTime.AsSeconds < 1 / fps Then
                Continue While
            End If
            Dim dt As Single = clock.Restart().AsSeconds()
            ' Console.WriteLine(1 / dt) ' fps

            Window.DispatchEvents()
            Window.Clear()
            scenes.CurrentScene.Update()
            mouseWasHeldLastFrame = Mouse.IsButtonPressed(Mouse.Button.Left)
            Window.Display()

        End While
    End Sub

    Sub HandleWindowClose() Handles Window.Closed
        ' this handles clicking the x button
        Window.Close()
    End Sub
End Module
