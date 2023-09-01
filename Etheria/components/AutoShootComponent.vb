Imports SFML.System

Public Class AutoShootComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "AutoShoot"
    Public pos As Vector2i ' bullet fire pos offset from entity pos
    Public bulletType As String ' bullet type
    Public fireRate As Integer ' fire every x frames
    Public fireCounter As Integer ' frame counter for fireRate

    Public Sub New(t As String, rate As Integer)
        pos = New Vector2i()
        bulletType = t
        fireRate = rate
        fireCounter = 0
    End Sub

    Public Sub New(t As String, rate As Integer, x As Integer, y As Integer)
        pos = New Vector2i(x, y)
        bulletType = t
        fireRate = rate
        fireCounter = 0
    End Sub
End Class