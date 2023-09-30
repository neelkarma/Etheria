Public Class EnemySpawnerSystem
    Inherits System

    Const enemyCap = 20

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponent("EnemySpawner")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        ' too many enemies can slow down the game - we're capping them here.
        ' temporarily disabling - removed a memory leak that resulted in bullets not being destroyed as they exited the screen
        'If scenes.CurrentScene.GetEntities(Function(ent) ent.HasComponent("Enemy")).Length >= enemyCap Then Return

        For Each entity In entities
                Dim enemies = GetEnemiesForLevel(session.level)
                Dim spawner = entity.GetComponent(Of EnemySpawnerComponent)("EnemySpawner")

                If spawner.framesUntilNext > 0 Then
                    spawner.framesUntilNext -= 1
                    Continue For
                End If

                Dim chosenEnemy = enemies(rng.Next(0, enemies.Length - 1))
                scenes.CurrentScene.AddEntity(New EnemyEntity(chosenEnemy))
                spawner.framesUntilNext = spawner.rate + rng.Next(-spawner.spread, spawner.spread)
            Next
    End Sub
End Class
