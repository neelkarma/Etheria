
Imports SFML.Graphics
Imports SFML.System

Public Class SpriteComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Sprite"

    Public ReadOnly Property Sprite As Sprite
        Get
            Dim s = sprites.GetSprites(name)(frame)
            s.Scale = scale
            Return s
        End Get
    End Property

    Public name As String
    Public scale As Vector2f
    Public frame As Integer
    Public framesUntilNext As Integer
    Public frameSpeed As Integer
    Public subFrame As Integer
    Public frameDuration As Integer
    Public hidden As Boolean = False
    Public Property colour As SFML.Graphics.Color

    Public Sub New(name As String, Optional frameDuration As Integer = 1, Optional scale As Vector2f = Nothing, Optional hidden As Boolean = False)
        If scale = Nothing Then scale = New Vector2f(1, 1)
        'If c = Nothing Then c = New Color(255, 255, 255)

        Me.name = name
        Me.frameDuration = frameDuration
        Me.scale = scale
        Me.hidden = hidden


    End Sub
End Class
