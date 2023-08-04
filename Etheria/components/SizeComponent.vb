Imports SFML.System

Public Class SizeComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Size"

    Public size As Vector2i

    Public Sub New(size As Vector2i)
        Me.size = size
    End Sub
End Class
