Public Class GameScene
    Inherits Scene
    Public Overrides ReadOnly Property Type As String = "Game"

    Public Overrides Sub InitEntities()
        ' paddles
        AddEntity(New PaddleEntity(PlayerSide.Left))
        AddEntity(New PaddleEntity(PlayerSide.Right))

        ' ball
        AddEntity(New BallEntity)

    End Sub

End Class
