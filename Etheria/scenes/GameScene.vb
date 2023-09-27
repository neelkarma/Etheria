Imports SFML.Graphics
Imports SFML.System

Public Class GameScene
    Inherits Scene
    Public Overrides ReadOnly Property Type As String = "Game"

    Public Overrides Sub InitEntities()
        ' scrolling background
        AddEntity(New ScrollingBackgroundComponent("menu-bg")) ' todo: change sprite

        ' level, score, high score, shinies
        AddEntity(New PlayerHUDEntity(Function() $"LVL {session.level}  SCORE {session.score}  HI {leaderboard.leaderboard.First().Item2}  {session.shinies} SHN", New Vector2i(5, 5)))

        ' lives
        AddEntity(
            New LivesComponent(),
            New PositionComponent(New Vector2i(windowWidth - 5, 5))
        )

        ' player
        AddEntity(New PlayerEntity())

    End Sub

End Class
