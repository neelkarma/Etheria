Imports SFML.Graphics
Imports SFML.System

Public Class ScrollingBackgroundComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "ScrollingBackground"

    Public ReadOnly Property Sprite As Sprite
        Get
            Dim s = sprites.GetSprites(name)(0)
            s.Scale = New Vector2f(scale, scale)
            Return s
        End Get
    End Property

    Public speed As Integer
    Public name As String
    Public scale As Single
    Public offset As Integer = 0

    Public Sub New(name As String, Optional speed As Integer = 1, Optional scale As Single = 1)
        Me.name = name
        Me.speed = speed
        Me.scale = scale
    End Sub
End Class
