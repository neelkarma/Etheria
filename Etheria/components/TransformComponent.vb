Imports SFML.System
Public Class TransformComponent
    Inherits Component
    Public Overrides ReadOnly Property Type As String = "Transform"
    Public pos As Vector2i
    Public vel As Vector2f
    Public decimalVel As Vector2f

    Public Sub New()

        pos = New Vector2i()
        vel = New Vector2f()
        decimalVel = New Vector2f()
    End Sub


    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal vx As Single, ByVal vy As Single)
        pos = New Vector2i(x, y)
        vel = New Vector2f(vx, vy)
    End Sub
End Class
