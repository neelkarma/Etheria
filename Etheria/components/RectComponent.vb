Imports SFML.Graphics
Imports SFML.System

Public Class RectComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Rect"

    Public rect As FloatRect
    Public fillColor As Color
    Public outlineColor As Color
    Public outlineThickness As Integer

    Public ReadOnly Property DrawableRect As RectangleShape
        Get
            Return New RectangleShape(New Vector2f(rect.Width, rect.Height)) With {
                .FillColor = fillColor,
                .OutlineColor = outlineColor,
                .OutlineThickness = outlineThickness,
                .Position = New Vector2f(rect.Left, rect.Top)
            }
        End Get
    End Property

    Public Sub New(rect As FloatRect, Optional fillColor As Color = Nothing, Optional outlineColor As Color = Nothing, Optional outlineThickness As Integer = 0)
        If IsNothing(fillColor) Then fillColor = Color.Black
        If IsNothing(outlineColor) Then outlineColor = Color.White

        Me.rect = rect
        Me.fillColor = fillColor
        Me.outlineColor = outlineColor
        Me.outlineThickness = outlineThickness
    End Sub
End Class
