Imports SFML.Graphics

Public Class TextComponent
    Inherits Component
    Public Overrides ReadOnly Property Type As String = "Text"

    Public ReadOnly Property Text As Text
        Get
            Return New Text(content, font, size) With {
                .FillColor = color
            }
        End Get
    End Property

    Public content As String
    Public size As Decimal
    Public color As Color

    Public Sub New(Optional content As String = "", Optional color As Color = Nothing, Optional size As Integer = 30)
        If color = Nothing Then color = Color.White

        Me.content = content
        Me.size = size
        Me.color = color
    End Sub
End Class
