Imports SFML.Window

Public Class PlayerControlComponent
    Inherits Component
    Public Overrides ReadOnly Property Type As String = "PlayerControl"
    Public upKey As Keyboard.Key
    Public downKey As Keyboard.Key
    Public leftKey As Keyboard.Key
    Public rightKey As Keyboard.Key
    Public fireKey As Keyboard.Key
    Public speed As Integer = 3

    Public Sub New() ' Construct with default keybindings (player 1)

        upKey = Keyboard.Key.W
        downKey = Keyboard.Key.S
        leftKey = Keyboard.Key.A
        rightKey = Keyboard.Key.D
        fireKey = Keyboard.Key.Space
    End Sub


End Class
