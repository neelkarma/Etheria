Imports SFML.Graphics

Public Class ColorComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Color"
    Public color As Color

    Public Sub New(Optional color As Color = Nothing)
        If color = Nothing Then color = Color.White
        Me.color = color
    End Sub
End Class
