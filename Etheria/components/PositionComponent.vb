Imports SFML.System

Public Class PositionComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Position"
    Public pos As Vector2i

    Public Sub New()
        pos = New Vector2i
    End Sub

    Public Sub New(pos As Vector2i)
        Me.pos = pos
    End Sub
End Class
