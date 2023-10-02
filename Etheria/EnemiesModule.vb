Imports SFML.System

Public Module EnemiesModule
    Public Class EnemyInfo
        Public spriteName As String
        Public spriteScale As Single
        Public spriteRate As Integer = 1

        Public health As Integer
        Public value As Integer
        Public speed As Integer

        Public fireRate As Integer

        Public bulletSprite As String
        Public bulletSpriteRate As Integer
        Public bulletSpeed As Integer
        Public bulletScale As Single
        Public bulletPos As Vector2i

        Public hitSfx As String
        Public deathSfx As String

        Public Sub New(spriteName As String, spriteScale As Single)
            Me.spriteName = spriteName
            Me.spriteScale = spriteScale
            Dim sprite = sprites.GetSprites(spriteName)(0)
            sprite.Scale = New Vector2f(spriteScale, spriteScale)
            Dim spriteBounds = sprite.GetGlobalBounds()
            bulletPos = New Vector2i(-20, spriteBounds.Height / 2)
        End Sub
    End Class

    Private ReadOnly enemyData()() As EnemyInfo = {
        New EnemyInfo() {
            New EnemyInfo("lvl1-flyingdutchman-enemy", 0.5) With {
                .health = 3,
                .value = 3,
                .speed = 1,
                .fireRate = 120,
                .bulletSprite = "lvl1-cannonball-projectile",
                .bulletScale = 2,
                .bulletSpeed = 2,
                .hitSfx = "lvl1-flyingdutchman-enemy-hit",
                .deathSfx = "lvl1-flyingdutchman-enemy-death"
            },
            New EnemyInfo("lvl1-parrot-enemy", 1) With {
                .health = 1,
                .value = 1,
                .speed = 2,
                .fireRate = 90,
                .bulletSprite = "lvl1-parrotfeather-projectile",
                .bulletScale = 1,
                .bulletSpeed = 3,
                .hitSfx = "lvl1-parrot-enemy-hit",
                .deathSfx = "lvl1-parrot-enemy-death"
            }
        }
    }

    Public Function GetEnemiesForLevel(level As Integer) As EnemyInfo()
        Return enemyData(level - 1)
    End Function
End Module
