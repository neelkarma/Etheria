
Imports SFML.Graphics
Imports SFML.System

Public Class SpriteComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Sprite"

    Public ReadOnly Property Sprite As Sprite
        Get
            Dim s = sprites.GetSprites(name)(frame)
            s.Scale = New Vector2f(scale, scale)
            s.Rotation = rotation
            Return s
        End Get
    End Property

    Public name As String
    Public scale As Double
    Public frame As Integer
    Public framesUntilNext As Integer
    Public frameDuration As Integer
    Public hidden As Boolean = False
    Public rotation As Double = 0
    Public overrideCollider As Boolean = True

    Public Sub New(name As String, Optional frameDuration As Integer = 1, Optional scale As Double = 1, Optional hidden As Boolean = False, Optional overrideCollider As Boolean = True)
        Me.name = name
        Me.frameDuration = frameDuration
        Me.overrideCollider = overrideCollider
        Me.scale = scale
        Me.hidden = hidden
    End Sub
End Class

