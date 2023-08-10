Imports SFML.Graphics
Imports SFML.System

Public Class TextComponent
    Inherits Component
    Public Overrides ReadOnly Property Type As String = "Text"

    Public ReadOnly Property Text As Text
        Get
            Return New Text With {
                .Font = font,
                .DisplayedString = content,
                .Scale = New Vector2f(scale, scale) * windowScale,
                .FillColor = color
            }
        End Get
    End Property

    Public content As String
    Public scale As Decimal
    Public color As Color

    Public Sub New(Optional content As String = "", Optional color As Color = Nothing, Optional scale As Decimal = 1)
        If color = Nothing Then color = Color.White

        Me.content = content
        Me.scale = scale
        Me.color = color
    End Sub
End Class
