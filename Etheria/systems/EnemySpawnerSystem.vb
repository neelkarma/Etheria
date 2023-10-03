Public Class EnemySpawnerSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponent("EnemySpawner")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim enemies = GetEnemiesForLevel(session.level)
            Dim spawner = entity.GetComponent(Of EnemySpawnerComponent)("EnemySpawner")

            If spawner.framesUntilNext > 0 Then
                spawner.framesUntilNext -= 1
                Continue For
            End If

            Dim chosenEnemy = enemies(rng.Next(0, enemies.Length))
            scenes.CurrentScene.AddEntity(New EnemyEntity(chosenEnemy))
            spawner.framesUntilNext = spawner.rate + rng.Next(-spawner.spread, spawner.spread)
        Next
    End Sub
End Class
