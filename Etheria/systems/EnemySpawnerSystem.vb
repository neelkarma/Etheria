Public Class EnemySpawnerSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponent("EnemySpawner")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim enemies = GetEnemiesForLevel(session.TrueLevel)
            Dim spawner = entity.GetComponent(Of EnemySpawnerComponent)("EnemySpawner")

            If spawner.framesUntilNext > 0 Then
                spawner.framesUntilNext -= 1
                Continue For
            End If

            Dim chosenEnemy = enemies(0)

            Dim chosen = rng.NextDouble()
            For Each enemy In enemies
                If chosen < enemy.chance Then
                    chosenEnemy = enemy
                    Exit For
                End If
                chosen -= enemy.chance
            Next

            ' increase difficulty for each 10 levels
            Dim diffInc = Math.Floor((session.level - 1) / 10) ' this will evaluate to 0 for levels 1-10, 1 for 11-20, etc.
            chosenEnemy.bulletSpeed += diffInc
            chosenEnemy.value += diffInc
            chosenEnemy.health += diffInc
            chosenEnemy.fireRate = Math.Max(chosenEnemy.fireRate - diffInc * 5, 10) ' this prevents very low, zero or negative fireRates

            scenes.CurrentScene.AddEntity(New EnemyEntity(chosenEnemy))
            spawner.framesUntilNext = spawner.rate + rng.Next(-spawner.spread, spawner.spread)
        Next
    End Sub
End Class
