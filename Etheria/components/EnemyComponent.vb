Imports SFML.System

Public Class EnemyComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Enemy"

    Public health As Integer ' Each basic player shot deals 1 damage
    Public value As Integer ' this affects awarded score and shinies

    Public fireRate As Integer ' Number of frames between each shot from this enemy
    Public framesUntilCanFire As Integer

    Public bulletPos As Vector2i
    Public bulletSpeed As Integer
    Public bulletScale As Single

    Public Sub New(enemyInfo As EnemyInfo)
        bulletPos = enemyInfo.bulletPos
        bulletSpeed = enemyInfo.bulletSpeed
        bulletScale = enemyInfo.bulletScale

        health = enemyInfo.health
        value = enemyInfo.value

        fireRate = enemyInfo.fireRate
        framesUntilCanFire = fireRate
    End Sub
End Class