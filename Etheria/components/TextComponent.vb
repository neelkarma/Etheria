﻿Imports SFML.Graphics
Imports SFML.System

Public Class TextComponent
    Inherits Component
    Public Overrides ReadOnly Property Type As String = "Text"
    Public text As String
    Public scale As Decimal
    Public color As Color

    Public Sub New(Optional text As String = "", Optional color As Color = Nothing, Optional scale As Decimal = 1)
        If color = Nothing Then color = Color.White

        Me.text = text
        Me.scale = scale
        Me.color = color
    End Sub

    Public Function BuildText() As Text
        Return New Text With {
            .Font = font,
            .DisplayedString = text,
            .Scale = New Vector2f(scale, scale) * windowScale,
            .FillColor = color
        }
    End Function
End Class
