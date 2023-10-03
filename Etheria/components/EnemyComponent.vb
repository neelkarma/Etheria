Imports SFML.System

Public Class EnemyComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Enemy"

    Public health As Integer ' Each basic player shot deals 1 damage
    Public framesUntilCanFire As Integer
    Public info As EnemyInfo

    Public Sub New(enemyInfo As EnemyInfo)
        info = enemyInfo
        health = enemyInfo.health
        framesUntilCanFire = enemyInfo.fireRate / 3
    End Sub
End Class