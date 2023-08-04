Imports SFML.System

Public Class VelocityComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Velocity"
    Public vel As Vector2i

    Public Sub New()
        vel = New Vector2i
    End Sub

    Public Sub New(vel As Vector2i)
        Me.vel = vel
    End Sub
End Class
