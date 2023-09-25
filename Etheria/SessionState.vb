''' <summary>
''' This class is for any global state throughout a play session (that is, one playthrough of the game, ignoring restarts)
''' 
''' Things like level, score, shinies, selected ship, available powerups go here.
''' </summary>
Public Class SessionState
    Public level As Integer = 0
    Public score As Integer = 0
    Public shinies As Integer = 0
    Public shipSprite As String = "ship-blue"
    Public boughtPowerUps As New HashSet(Of String)

    Public Sub Reset()
        level = 0
        score = 0
        shinies = 0
        shipSprite = "ship-blue"
        boughtPowerUps.Clear()
    End Sub
End Class
