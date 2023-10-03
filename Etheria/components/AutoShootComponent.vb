Imports SFML.System

Public Class AutoShootComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "AutoShoot"
    Public pos As Vector2f ' bullet fire pos offset from entity pos
    Public fireRate As Integer ' fire every x frames
    Public fireCounter As Integer ' frame counter for fireRate

    Public Sub New(rate As Integer)
        pos = New Vector2f()
        fireRate = rate
        fireCounter = 0
    End Sub

    Public Sub New(fireRate As Integer, pos As Vector2f)
        Me.pos = pos
        Me.fireRate = fireRate
        fireCounter = 0
    End Sub
End Class