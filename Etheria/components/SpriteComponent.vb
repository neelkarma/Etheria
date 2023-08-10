
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
    Public scale As Vector2i
    Public frame As Integer
    Public framesUntilNext As Integer
    Public frameDuration As Integer

    Public Sub New(name As String, Optional frameDuration As Integer = 1, Optional scale As Vector2i = Nothing)
        If scale = Nothing Then scale = New Vector2i(1, 1)

        Me.name = name
        Me.frameDuration = frameDuration
        Me.scale = scale
    End Sub
End Class
