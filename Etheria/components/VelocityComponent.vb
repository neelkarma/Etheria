Imports SFML.System

Public Class VelocityComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Velocity"
    Public vel As Vector2f

    Public Sub New()
        vel = New Vector2f
    End Sub

    Public Sub New(vel As Vector2f)
        Me.vel = vel
    End Sub
End Class
