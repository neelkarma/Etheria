Imports SFML.Graphics

Public Class GameScene
    Inherits Scene
    Public Overrides ReadOnly Property Type As String = "Game"
    Public Sub New()
        MyBase.New()

        cursorEnabled = False
    End Sub


    Public Overrides Sub InitEntities()
        Dim player As New Player(playerColour, 1, 0, windowHeight / 2 - 6)
        AddEntity(player)
        ' paddles
        AddEntity(New PaddleEntity(PlayerSide.Left))
        AddEntity(New PaddleEntity(PlayerSide.Right))

        ' ball
        AddEntity(New BallEntity)
    End Sub

End Class
