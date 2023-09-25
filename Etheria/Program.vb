Imports SFML.Graphics
Imports SFML.System
Imports SFML.Window

Public Module Program
    Public Const fps As Integer = 60
    Public Const windowWidth As Integer = 800
    Public Const windowHeight As Integer = 600

    Public windowScale As Integer = 1
    Public WithEvents Window As New RenderWindow(New VideoMode(windowWidth, windowHeight), "Etheria")

    Public mouseWasHeldLastFrame As Boolean = False
    Public isDebug As Boolean = False

    Public ReadOnly font As New Font("../../../resources/fonts/PublicPixel.ttf")
    Public ReadOnly clock As New Clock

    Public ReadOnly sprites As New SpriteManager
    Public ReadOnly audio As New AudioManager
    Public ReadOnly leaderboard As New LeaderboardManager
    Public ReadOnly session As New SessionState
    Public ReadOnly scenes As New SceneManager("Title")

    Sub Main()
        Window.SetVerticalSyncEnabled(True)

        ' TODO: change this after some time
        audio.PlayBGM("grass-beach")

        While Window.IsOpen()
            ' enforce set fps
            If clock.ElapsedTime.AsSeconds() < 1 / fps Then Continue While
            Dim dt As Single = clock.Restart().AsSeconds()
            ' Console.WriteLine(1 / dt) ' fps

            Window.DispatchEvents()
            Window.Clear()
            scenes.CurrentScene.Update()

            mouseWasHeldLastFrame = Mouse.IsButtonPressed(Mouse.Button.Left)
            If Keyboard.IsKeyPressed(Keyboard.Key.F2) Then
                isDebug = Not isDebug
            End If

            If Not (scenes.sceneJustChanged And mouseWasHeldLastFrame) Then
                scenes.sceneJustChanged = False
            End If

            Window.Display()
        End While
    End Sub

    Sub HandleWindowClose() Handles Window.Closed
        ' this handles closing the app when the x button is clicked
        Window.Close()
    End Sub
End Module
