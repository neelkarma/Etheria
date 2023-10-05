Imports SFML.Graphics
Imports SFML.System
Imports SFML.Window

Public Module Program
    Public Const fps As Integer = 60
    Public Const windowWidth As Integer = 800
    Public Const windowHeight As Integer = 600

    Public WithEvents Window As RenderWindow
    Public isFullscreen As Boolean = False

    Public mouseWasHeldLastFrame As Boolean = False
    Public isDebug As Boolean = False

    Public ReadOnly rng As New Random()
    Public ReadOnly font As New Font("../../../resources/fonts/PublicPixel.ttf")
    Public ReadOnly clock As New Clock

    Public ReadOnly sprites As New SpriteManager
    Public ReadOnly audio As New AudioManager
    Public ReadOnly leaderboard As New LeaderboardManager
    Public ReadOnly session As New SessionState
    Public ReadOnly scenes As New SceneManager("Title")

    Sub Main()
        InitWindow()

        While Window.IsOpen()
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

    Public Sub InitWindow()
        If Not IsNothing(Window) Then Window.Close()
        Window = New RenderWindow(
            If(isFullscreen, New VideoMode(), New VideoMode(windowWidth, windowHeight)),
            "Etheria",
            If(isFullscreen, Styles.Fullscreen, Styles.Default)
        )
        Window.SetFramerateLimit(60)
        Window.SetVerticalSyncEnabled(True)
        UpdateViewportSize()
        Window.Display()
    End Sub

    Private Sub UpdateViewportSize()
        ' Dear future self: DO NOT FUCKING TOUCH THIS CODE YOU WILL BREAK IT SOMEHOW

        Dim viewport As New FloatRect(0, 0, 1, 1)

        If Window.Size.X > Window.Size.Y * (windowWidth / windowHeight) Then
            viewport.Width = (Window.Size.Y / Window.Size.X) * (windowWidth / windowHeight)
            viewport.Left = (1 - viewport.Width) / 2
        ElseIf Window.Size.Y > Window.Size.X * (windowHeight / windowWidth) Then
            viewport.Height = (Window.Size.X / Window.Size.Y) * (windowHeight / windowWidth)
            viewport.Top = (1 - viewport.Height) / 2
        End If

        Window.SetView(New View(New FloatRect(0, 0, windowWidth, windowHeight)) With {
            .Viewport = viewport
        })
    End Sub

    Private Sub HandleWindowClose() Handles Window.Closed
        ' this handles closing the app when the x button is clicked
        Window.Close()
    End Sub

    Private Sub HandleResize() Handles Window.Resized
        UpdateViewportSize()
    End Sub
End Module
