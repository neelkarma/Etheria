Imports SFML.System

Public Class PositionComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Position"
    Public pos As Vector2f

    Public Sub New()
        pos = New Vector2f
    End Sub

    Public Sub New(pos As Vector2f)
        Me.pos = pos
    End Sub
End Class
