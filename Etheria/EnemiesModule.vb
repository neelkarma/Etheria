Imports SFML.System

Public Module EnemiesModule
    Public Class EnemyInfo
        Public spriteName As String
        Public spriteScale As Single

        Public health As Integer
        Public value As Integer
        Public speed As Integer

        Public fireRate As Integer
        Public bulletSpeed As Integer
        Public bulletScale As Single
        Public bulletPos As Vector2i

        Public Sub New(spriteName As String, value As Integer, Optional spriteScale As Single = 1, Optional health As Integer = 1, Optional speed As Integer = 5, Optional fireRate As Integer = 60, Optional bulletSpeed As Integer = 5, Optional bulletScale As Single = 0.3)
            Me.spriteName = spriteName
            Me.spriteScale = spriteScale

            Me.health = health
            Me.value = value
            Me.speed = speed

            Me.fireRate = fireRate
            Me.bulletSpeed = bulletSpeed
            Me.bulletScale = bulletScale

            Dim sprite = sprites.GetSprites(spriteName)(0)
            sprite.Scale = New Vector2f(spriteScale, spriteScale)
            Dim spriteBounds = sprite.GetGlobalBounds()
            bulletPos = New Vector2i(-20, spriteBounds.Height / 2)
        End Sub
    End Class

    Private ReadOnly enemyData()() As EnemyInfo = {
        New EnemyInfo() {
            New EnemyInfo("error", 10, 0.3, 3)
        }
    }

    Public Function GetEnemiesForLevel(level As Integer) As EnemyInfo()
        Return enemyData(level - 1)
    End Function
End Module
