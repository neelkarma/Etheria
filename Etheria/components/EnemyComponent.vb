Public Class EnemyComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Enemy"
    Public enemyType As String ' Type of enemy AI
    Public health As Integer ' Each basic player shot deals 1 damage
    Public score As Integer ' Base score awarded for destroying this enemy
    Public shoots As Boolean
    Public fireRate As Integer ' Number of frames between each shot from this enemy
    Public fireCounter As Integer
    Public moveCycleCounter As Integer ' Counter for position in movement pattern, use depends on AI type
    Public projectile As String
    Public firePattern As String
    Public fireSound As String
    Public speed As Single
    Public bulletPos As SFML.System.Vector2i
    Public startY As Integer ' starting Y value
    Public debris As String
    Public deathSound As String

    Public spriteNormal As String

    Public Sub New(Optional _enemyType As String = "", Optional _health As Integer = 1, Optional _score As Integer = 1, Optional _speed As Single = 1,
                       Optional _shoots As Boolean = False, Optional _fireRate As Integer = 60, Optional _fireCoutnerStart As Integer = 0, Optional _projectile As String = "OxygenZero.BasicEnemyBullet",
                       Optional _firePattern As String = "basic", Optional _fireSound As String = "fire", Optional _spriteNormal As String = "",
                       Optional _bulletPos As SFML.System.Vector2i = Nothing, Optional _startY As Integer = 0, Optional _debris As String = "OxygenZero.ShipDebris", Optional _deathSound As String = "explosion2")
        If _bulletPos = Nothing Then
            _bulletPos = New SFML.System.Vector2i(0, 0)
        End If

        speed = _shoots
        enemyType = _enemyType
        health = _health
        score = _score
        fireCounter = _fireCoutnerStart
        shoots = _shoots
        fireRate = _fireRate
        moveCycleCounter = 0
        projectile = _projectile
        firePattern = _firePattern
        fireSound = _fireSound
        speed = _speed
        bulletPos = _bulletPos
        spriteNormal = _spriteNormal
        startY = _startY
        debris = _debris
        deathSound = _deathSound
    End Sub


End Class