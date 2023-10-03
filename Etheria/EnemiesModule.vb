Imports SFML.System

Public Module EnemiesModule
    Public Class EnemyInfo
        ''' <summary>
        ''' Name of the sprite.
        ''' </summary>
        Public spriteName As String

        ''' <summary>
        ''' Scale of the sprite
        ''' </summary>
        Public spriteScale As Single

        ''' <summary>
        ''' Number of frames per frame of the sprite's animation, if any.
        ''' </summary>
        Public spriteRate As Integer = 1

        ''' <summary>
        ''' Number of hits the enemy can take before dying.  
        ''' </summary>
        Public health As Integer

        ''' <summary>
        ''' The enemy's value. Used to calculate score and shinies obtained upon kill.
        ''' </summary>
        Public value As Integer

        ''' <summary>
        ''' Speed of the enemy.
        ''' </summary>
        Public speed As Integer

        ''' <summary>
        ''' How many frames between successive shots.
        ''' </summary>
        Public fireRate As Integer

        ''' <summary>
        ''' Bullet sprite.
        ''' </summary>
        Public bulletSprite As String
        ''' <summary>
        ''' How many frames per frame of the bullet sprite's animation, if any.
        ''' </summary>
        Public bulletSpriteRate As Integer
        ''' <summary>
        ''' The bullet's speed
        ''' </summary>
        Public bulletSpeed As Integer
        ''' <summary>
        ''' The bullet's scale
        ''' </summary>
        Public bulletScale As Single
        ''' <summary>
        ''' The bullet's position, relative to the enemy position.
        ''' This is automatically calculated, so in most cases, this doesn't have to be set.
        ''' </summary>
        Public bulletPos As Vector2f

        ''' <summary>
        ''' The sfx to play on enemy hit
        ''' </summary>
        Public hitSfx As String
        ''' <summary>
        ''' The sfx to play on enemy death
        ''' </summary>
        Public deathSfx As String

        Public Sub New(spriteName As String, spriteScale As Single)
            Me.spriteName = spriteName
            Me.spriteScale = spriteScale
            Dim sprite = sprites.GetSprites(spriteName)(0)
            sprite.Scale = New Vector2f(spriteScale, spriteScale)
            Dim spriteBounds = sprite.GetGlobalBounds()
            bulletPos = New Vector2f(-20, spriteBounds.Height / 2)
        End Sub
    End Class

    ''' <summary>
    ''' All enemy data, as a 2D array.
    ''' The first dimension is the level (technically level - 1, since arrays are 0-indexed), and the second dimension is the enemy.
    ''' </summary>
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
        },
        New EnemyInfo() {
            New EnemyInfo("lvl2-elfcopter-enemy", 1) With {
                .health = 2,
                .value = 2,
                .speed = 3,
                .fireRate = 60,
                .bulletSprite = "lvl2-icebolt-projectile",
                .bulletScale = 1,
                .bulletSpeed = 4,
                .hitSfx = "lvl2-elfcopter-enemy-hit",
                .deathSfx = "lvl2-elfcopter-enemy-death"
            }
        }
    }

    Public Function GetEnemiesForLevel(level As Integer) As EnemyInfo()
        If level > enemyData.Length Then
            Console.WriteLine("ENEMIES: WARNING: Level is greater than enemy data length, returning dummy enemy data")
            Return New EnemyInfo() {
                New EnemyInfo("error", 0.5) With {
                    .health = 1,
                    .value = 1,
                    .speed = 1,
                    .fireRate = 60,
                    .bulletSprite = "enemy-bullet",
                    .bulletScale = 0.3,
                    .bulletSpeed = 3,
                    .hitSfx = "",
                    .deathSfx = ""
                }
            }
        End If

        Return enemyData(level - 1)
    End Function
End Module
