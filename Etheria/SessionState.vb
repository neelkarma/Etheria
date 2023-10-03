''' <summary>
''' This class is for any global state throughout a play session (that is, one playthrough of the game, ignoring restarts)
''' 
''' Things like level, score, shinies, selected ship, available powerups go here.
''' </summary>
Public Class SessionState
    Public ReadOnly Property TrueLevel
        Get
            Return ((level - 1) Mod 10) + 1
        End Get
    End Property

    Public level As Integer = 0
    Public score As Integer = 0
    Public shinies As Integer = 0
    Public lives As Integer = 3
    Public shipSprite As String = "ship-blue"
    Public boughtPowerUps As New HashSet(Of Powerup)
    Public equippedPowerup As Powerup? = Nothing

    Public Sub Reset()
        level = 0
        score = 0
        shinies = 0
        lives = 3
        shipSprite = "ship-blue"
        boughtPowerUps.Clear()
        equippedPowerup = Nothing
    End Sub
End Class
