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
        Public spriteScale As Double

        ''' <summary>
        ''' Number of frames per frame of the sprite's animation, if any.
        ''' </summary>
        Public spriteRate As Integer = 1

        ''' <summary>
        ''' Probability of this enemy spawning, from 0 to 1
        ''' </summary>
        Public chance As Double

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
        Public speed As Double

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
        Public bulletSpeed As Double
        ''' <summary>
        ''' The bullet's sprite's scale
        ''' </summary>
        Public bulletScale As Double
        ''' <summary>
        ''' The bullet's position, relative to the enemy position.
        ''' This is automatically calculated, so in most cases, this doesn't have to be set.
        ''' </summary>
        Public bulletPos As Vector2f

        ''' <summary>
        ''' The sfx to play on enemy hit
        ''' </summary>
        Public hitSfx As String = ""
        ''' <summary>
        ''' The sfx to play on enemy death
        ''' </summary>
        Public deathSfx As String = ""


        ''' <summary>
        ''' Creates a new EnemyInfo instance.
        ''' </summary>
        ''' <param name="spriteName">The name of the enemy's sprite</param>
        ''' <param name="spriteScale">The scale of the enemy's sprite</param>
        Public Sub New(spriteName As String, spriteScale As Double)
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
                .chance = 0.2,
                .spriteScale = 1.5,
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
                .chance = 0.4,
                .spriteScale = 1.5,
                .health = 1,
                .value = 1,
                .speed = 2,
                .fireRate = 90,
                .bulletSprite = "lvl1-parrotfeather-projectile",
                .bulletScale = 1,
                .bulletSpeed = 3,
                .hitSfx = "lvl1-parrot-enemy-hit",
                .deathSfx = "lvl1-parrot-enemy-death"
            },
            New EnemyInfo("lvl1-piratescurse-enemy", 1) With {
                .chance = 0.4,
                .spriteScale = 1.5,
                .health = 2,
                .value = 2,
                .speed = 2,
                .fireRate = 90,
                .bulletSprite = "lvl1-piratebullet-projectile",
                .bulletScale = 1.5,
                .bulletSpeed = 3,
                .hitSfx = "",
                .deathSfx = "lvl1-piratescurse-enemy-death"
            }
        },
        New EnemyInfo() {
            New EnemyInfo("lvl2-elfcopter-enemy", 1) With {
                .chance = 0.4,
                .spriteScale = 1.5,
                .health = 2,
                .value = 2,
                .speed = 3,
                .fireRate = 60,
                .bulletSprite = "lvl2-icebolt-projectile",
                .bulletScale = 1,
                .bulletSpeed = 4,
                .hitSfx = "lvl2-elfcopter-enemy-hit",
                .deathSfx = "lvl2-elfcopter-enemy-death"
            },
            New EnemyInfo("lvl2-flocko-enemy", 1) With {
                .chance = 0.4,
                .spriteScale = 1.5,
                .health = 3,
                .value = 3,
                .speed = 3,
                .fireRate = 180,
                .bulletSprite = "lvl2-icemist-projectile",
                .bulletScale = 0.5,
                .bulletSpeed = 1,
                .hitSfx = "",
                .deathSfx = "lvl2-flocko-enemy-death"
            },
            New EnemyInfo("lvl2-icequeen-enemy", 1) With {
                .chance = 0.2,
                .spriteScale = 2,
                .spriteRate = 2,
                .health = 5,
                .value = 5,
                .speed = 3,
                .fireRate = 120,
                .bulletSprite = "lvl2-icesickle-projectile",
                .bulletSpriteRate = 2,
                .bulletScale = 1,
                .bulletSpeed = 3,
                .hitSfx = "lvl2-icequeen-enemy-hit",
                .deathSfx = "lvl2-icequeen-enemy-death"
            }
        },
        New EnemyInfo() {
            New EnemyInfo("lvl3-antlion-enemy", 1) With {
                .chance = 0.5,
                .health = 2,
                .value = 2,
                .speed = 1,
                .fireRate = 90,
                .bulletSprite = "lvl3-fireball-projectile",
                .bulletScale = 2,
                .bulletSpeed = 2.5,
                .hitSfx = "lvl3-antlion-enemy-hit",
                .deathSfx = "lvl3-antlion-enemy-death"
            },
            New EnemyInfo("lvl3-desertspirit-enemy", 1) With {
                .chance = 0.35,
                .spriteScale = 1.2,
                .health = 2,
                .value = 2,
                .speed = 3,
                .fireRate = 200,
                .bulletSprite = "lvl3-spiritflame-projectile",
                .bulletSpriteRate = 2,
                .bulletScale = 1,
                .bulletSpeed = 1,
                .hitSfx = "lvl3-desertspirit-enemy-teleport",
                .deathSfx = "lvl3-desertspirit-enemy-death"
            },
            New EnemyInfo("lvl3-golem-enemy", 1) With {
                .chance = 0.15,
                .spriteScale = 2.5,
                .health = 10,
                .value = 10,
                .speed = 1,
                .fireRate = 50,
                .bulletSprite = "lvl3-eyebeam-projectile",
                .bulletScale = 1,
                .bulletSpeed = 5,
                .hitSfx = "lvl3-golem-enemy-hit",
                .deathSfx = "lvl3-golem-enemy-death"
            }
        },
                New EnemyInfo() {
            New EnemyInfo("lvl4-pixie-enemy", 1) With {
                .chance = 0.7,
                .spriteScale = 2,
                .health = 2,
                .value = 2,
                .speed = 1,
                .fireRate = 150,
                .bulletSprite = "lvl4-greenfairy-projectile",
                .bulletScale = 0.5,
                .bulletSpeed = 4,
                .hitSfx = "lvl4-pixie-enemy-hit",
                .deathSfx = "lvl4-pixie-enemy-death"
            },
            New EnemyInfo("lvl4-ocram-enemy", 1) With {
                .chance = 0.1,
                .health = 15,
                .value = 15,
                .speed = 3,
                .fireRate = 200,
                .bulletSprite = "lvl4-ocramscythe-projectile",
                .bulletSpriteRate = 2,
                .bulletScale = 1,
                .bulletSpeed = 3,
                .hitSfx = "lvl4-ocram-enemy-hit",
                .deathSfx = "lvl4-ocram-enemy-death"
            },
            New EnemyInfo("lvl4-ocram-enemy", 1) With {
                .chance = 0.1,
                .health = 15,
                .value = 15,
                .speed = 3,
                .fireRate = 60,
                .bulletSprite = "lvl4-ocramlaser-projectile",
                .bulletScale = 1,
                .bulletSpeed = 4,
                .hitSfx = "lvl4-ocram-enemy-hit",
                .deathSfx = "lvl4-ocram-enemy-death"
            },
            New EnemyInfo("lvl4-lightempress-enemy", 1) With {
                .chance = 0.05,
                .spriteScale = 1.2,
                .spriteRate = 2,
                .health = 16,
                .value = 16,
                .speed = 1,
                .fireRate = 90,
                .bulletSprite = "lvl4-ethereallance-projectile",
                .bulletScale = 1.2,
                .bulletSpeed = 6,
                .hitSfx = "lvl4-lightempress-enemy-hit",
                .deathSfx = "lvl4-lightempress-enemy-death"
            },
            New EnemyInfo("lvl4-lightempress-enemy", 1) With {
                .chance = 0.05,
                .spriteScale = 1.5,
                .spriteRate = 2,
                .health = 16,
                .value = 16,
                .speed = 1,
                .fireRate = 60,
                .bulletSprite = "lvl4-everlastingrainbow-projectile",
                .bulletScale = 1,
                .bulletSpeed = 3,
                .hitSfx = "lvl4-lightempress-enemy-hit",
                .deathSfx = "lvl4-lightempress-enemy-death"
            }
        },
        New EnemyInfo() {
            New EnemyInfo("lvl5-probe-enemy", 1) With {
                .chance = 0.7,
                .health = 2,
                .value = 2,
                .speed = 1,
                .fireRate = 60,
                .bulletSprite = "lvl5-laser-projectile",
                .bulletScale = 1,
                .bulletSpeed = 8,
                .hitSfx = "lvl5-probe-enemy-hit",
                .deathSfx = "lvl5-probe-enemy-death"
            },
            New EnemyInfo("lvl5-martiandrone-enemy", 1) With {
                .chance = 0.25,
                .health = 6,
                .value = 6,
                .speed = 3,
                .fireRate = 200,
                .bulletSprite = "lvl5-laser2-projectile",
                .bulletScale = 1,
                .bulletSpeed = 8,
                .hitSfx = "lvl5-martiandrone-enemy-hit",
                .deathSfx = "lvl5-martiandrone-enemy-death"
            },
            New EnemyInfo("lvl5-martiansaucer-enemy", 1) With {
                .chance = 0.05,
                .spriteScale = 2,
                .spriteRate = 2,
                .health = 25,
                .value = 25,
                .speed = 1,
                .fireRate = 100,
                .bulletSprite = "lvl5-saucerdebris-projectile",
                .bulletScale = 2,
                .bulletSpeed = 8,
                .hitSfx = "lvl5-martiansaucer-enemy-hit",
                .deathSfx = "lvl5-martiansaucer-enemy-death"
            }
        },
        New EnemyInfo() {
            New EnemyInfo("lvl6-bloodjelly-enemy", 1) With {
                .chance = 0.5,
                .health = 2,
                .spriteScale = 1.5,
                .value = 2,
                .speed = 4,
                .fireRate = 160,
                .bulletSprite = "lvl6-bloodcloud-projectile",
                .bulletScale = 1,
                .bulletSpeed = 1,
                .hitSfx = "lvl6-bloodjelly-enemy-hit",
                .deathSfx = "lvl6-bloodjelly-enemy-death"
            },
            New EnemyInfo("lvl6-bloodfeeder-enemy", 1) With {
                .chance = 0.46,
                .spriteScale = 1.5,
                .health = 3,
                .value = 3,
                .speed = 3,
                .fireRate = 300,
                .bulletSprite = "lvl6-bloodcloud-projectile",
                .bulletScale = 0.5,
                .bulletSpeed = 8,
                .hitSfx = "lvl6-bloodfeeder-enemy-hit",
                .deathSfx = "lvl6-bloodfeeder-enemy-death"
            },
            New EnemyInfo("lvl6-betsy-enemy", 1) With {
                .chance = 0.04,
                .spriteScale = 3,
                .spriteRate = 2,
                .health = 40,
                .value = 40,
                .speed = 2.5,
                .fireRate = 550,
                .bulletSprite = "lvl6-betsysfireball-projectile",
                .bulletScale = 1,
                .bulletSpeed = 4,
                .hitSfx = "lvl6-betsy-enemy-hit",
                .deathSfx = "lvl6-betsy-enemy-death"
            }
        },
        New EnemyInfo() {
            New EnemyInfo("lvl7-shark-enemy", 1) With {
                .chance = 0.5,
                .health = 3,
                .value = 3,
                .speed = 4,
                .fireRate = 450,
                .bulletSprite = "lvl7-sharknadobolt-projectile",
                .bulletScale = 0.5,
                .bulletSpeed = 8,
                .hitSfx = "lvl7-shark-enemy-hit",
                .deathSfx = "lvl7-shark-enemy-death"
            },
            New EnemyInfo("lvl7-orca-enemy", 1) With {
                .chance = 0.4,
                .health = 5,
                .value = 5,
                .speed = 3,
                .fireRate = 355,
                .bulletSprite = "lvl7-sharknadobolt-projectile",
                .bulletScale = 0.5,
                .bulletSpeed = 8,
                .hitSfx = "lvl7-orca-enemy-hit",
                .deathSfx = "lvl7-orca-enemy-death"
            },
            New EnemyInfo("lvl7-dukefishron-enemy", 1) With {
                .chance = 0.1,
                .spriteScale = 1.2,
                .spriteRate = 2,
                .health = 50,
                .value = 50,
                .speed = 2,
                .fireRate = 450,
                .bulletSprite = "lvl7-sharknado-projectile",
                .bulletScale = 1,
                .bulletSpeed = 4,
                .hitSfx = "lvl7-dukefishron-enemy-hit",
                .deathSfx = "lvl7-dukefishron-enemy-death"
            }
        },
         New EnemyInfo() {
            New EnemyInfo("lvl8-ghost-enemy", 1) With {
                .chance = 0.3,
                .spriteScale = 2,
                .health = 60,
                .value = 20,
                .speed = 0.2,
                .fireRate = 1050,
                .bulletSprite = "lvl8-spiritmist-projectile",
                .bulletScale = 0.5,
                .bulletSpeed = 0.5,
                .hitSfx = "",
                .deathSfx = "lvl8-ghost-enemy-death"
            },
            New EnemyInfo("lvl8-spirit-enemy", 1) With {
                .chance = 0.65,
                .health = 1,
                .value = 1,
                .speed = 3,
                .fireRate = 100,
                .bulletSprite = "lvl8-spiritbolt-projectile",
                .bulletScale = 1,
                .bulletSpeed = 8,
                .hitSfx = "lvl8-spirit-enemy-hit",
                .deathSfx = "lvl8-spirit-enemy-death"
            },
            New EnemyInfo("lvl8-lunaticcultist-enemy", 1) With {
                .chance = 0.025,
                .spriteScale = 2,
                .spriteRate = 2,
                .health = 50,
                .value = 50,
                .speed = 0.1,
                .fireRate = 450,
                .bulletSprite = "lvl8-lunaticcultistfireball-projectile",
                .bulletScale = 1,
                .bulletSpeed = 4,
                .hitSfx = "lvl8-lunaticcultist-enemy-hit",
                .deathSfx = "lvl8-lunaticcultist-enemy-death"
            },
            New EnemyInfo("lvl8-lunaticcultist-enemy", 1) With {
                .chance = 0.025,
                .spriteScale = 2,
                .spriteRate = 2,
                .health = 70,
                .value = 70,
                .speed = 0.1,
                .fireRate = 450,
                .bulletSprite = "lvl8-lunaticcultistlightning-projectile",
                .bulletScale = 1.2,
                .bulletSpeed = 1,
                .hitSfx = "lvl8-lunaticcultist-enemy-hit",
                .deathSfx = "lvl8-lunaticcultist-enemy-death"
            }
        },
        New EnemyInfo() {
            New EnemyInfo("lvl9-queenbee-enemy", 1) With {
                .chance = 0.35,
                .spriteRate = 2,
                .health = 10,
                .value = 10,
                .speed = 5,
                .fireRate = 90,
                .bulletSprite = "lvl9-beestinger-projectile",
                .bulletScale = 1,
                .bulletSpeed = 5,
                .hitSfx = "lvl9-queenbee-enemy-hit",
                .deathSfx = "lvl9-queenbee-enemy-death"
            },
            New EnemyInfo("lvl9-queenbee-enemy", 1) With {
                .chance = 0.15,
                .spriteRate = 2,
                .health = 15,
                .value = 10,
                .speed = 3,
                .fireRate = 180,
                .bulletSprite = "lvl9-bee-projectile",
                .bulletScale = 1.2,
                .bulletSpeed = 6,
                .hitSfx = "lvl9-queenbee-enemy-hit",
                .deathSfx = "lvl9-queenbee-enemy-death"
            },
            New EnemyInfo("lvl9-darkmage-enemy", 1) With {
                .chance = 0.46,
                .spriteRate = 2,
                .health = 12,
                .value = 12,
                .speed = 1.4,
                .fireRate = 650,
                .bulletSprite = "lvl9-darksigil-projectile",
                .bulletScale = 1,
                .bulletSpeed = 1,
                .hitSfx = "lvl9-darkmage-enemy-hit",
                .deathSfx = "lvl9-darkmage-enemy-death"
            },
            New EnemyInfo("lvl9-moonlord-enemy", 1) With {
                .chance = 0.04,
                .spriteScale = 2.5,
                .health = 85,
                .value = 85,
                .speed = 0.1,
                .fireRate = 450,
                .bulletSprite = "lvl9-phantasmalsphere-projectile",
                .bulletScale = 1.5,
                .bulletSpeed = 3,
                .hitSfx = "lvl9-moonlord-enemy-hit",
                .deathSfx = "lvl9-moonlord-enemy-death"
            }
        },
        New EnemyInfo() {
            New EnemyInfo("lvl10-floatygross-enemy", 1) With {
                .chance = 0.45,
                .spriteScale = 2,
                .health = 4,
                .value = 4,
                .speed = 5,
                .fireRate = 180,
                .bulletSprite = "lvl10-imp-projectile",
                .bulletScale = 0.6,
                .bulletSpeed = 3,
                .hitSfx = "lvl10-floatygross-enemy-hit",
                .deathSfx = "lvl10-floatygross-enemy-death"
            },
            New EnemyInfo("lvl10-brainofcthulu-enemy", 1) With {
                .chance = 0.25,
                .spriteScale = 1.2,
                .spriteRate = 2,
                .health = 20,
                .value = 20,
                .speed = 3,
                .fireRate = 620,
                .bulletSprite = "lvl6-bloodcloud-projectile",
                .bulletScale = 3.6,
                .bulletSpeed = 0.5,
                .hitSfx = "lvl10-brainofcthulu-enemy-hit",
                .deathSfx = "lvl10-brainofcthulu-enemy-death"
            },
            New EnemyInfo("lvl10-thetwins-enemy", 1) With {
                .chance = 0.25,
                .spriteScale = 1.1,
                .spriteRate = 2,
                .health = 20,
                .value = 20,
                .speed = 3,
                .fireRate = 250,
                .bulletSprite = "lvl10-eyefire-projectile",
                .bulletScale = 1,
                .bulletSpeed = 2,
                .hitSfx = "lvl10-thetwins-enemy-hit",
                .deathSfx = "lvl10-thetwins-enemy-death"
            },
            New EnemyInfo("lvl10-brimstoneelement-enemy", 1) With {
                .chance = 0.05,
                .spriteScale = 1,
                .health = 120,
                .value = 120,
                .speed = 1,
                .fireRate = 450,
                .bulletSprite = "lvl10-ghast-projectile",
                .bulletScale = 1.5,
                .bulletSpeed = 3,
                .hitSfx = "lvl10-brimstoneelemental-enemy-hit",
                .deathSfx = "lvl10-brimstoneelemental-enemy-death"
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
