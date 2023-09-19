Imports SFML.System
Public Class PlayerHUDSystem
    Inherits System

    Public healthSpriteIds As New List(Of Integer)
    Public abilitySpriteIds As New List(Of Integer)
    Public highScoreTextId As Integer
    Public scoreTextId As Integer

    Public Const scorePadding As Integer = 18

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponent("PlayerHUDComponent")
    End Function

    Public Overrides Sub Init(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim hud = entity.GetComponent(Of PlayerHUDComponent)("PlayerHUD")

            For i = 0 To 2
                Dim healthEntity = New Entity(
                        New SpriteComponent(1,,, True),
                        New PositionComponent(New Vector2i(i * 8, 0))
                    )
                healthSpriteIds.Add(healthEntity.id)
                scenes.CurrentScene.AddEntity(healthEntity)
            Next

            For i = 0 To 2
                Dim healthEntity As New Entity(
                    New SpriteComponent(1,,, True),
                    New PositionComponent(New Vector2i(36 + i * 8, 0))
                )
                healthSpriteIds.Add(healthEntity.id)
                scenes.CurrentScene.AddEntity(healthEntity)
            Next

            For i = 0 To 1
                Dim healthEntity As New Entity(
                    New SpriteComponent(1,,, True),
                    New PositionComponent(New Vector2i(24 + i * 8, 0))
                )
                healthSpriteIds.Add(healthEntity.id)
                scenes.CurrentScene.AddEntity(healthEntity)
            Next
        Next
    End Sub

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            If scenes.CurrentScene.Type <> "GameScene" Then Continue For

            Dim player = entity.GetComponent(Of PlayerComponent)("Player")
            For i = 0 To 2
                If Not scenes.CurrentScene.HasEntityWithId(healthSpriteIds(i)) Then Continue For

                Dim healthEntity As Entity = scenes.CurrentScene.GetEntityById(healthSpriteIds(i))
                Dim sprite As SpriteComponent = healthEntity.GetComponent(Of SpriteComponent)("SpriteComponent")

                If i <= player.lives - 1 Then
                    sprite.hidden = False
                Else
                    sprite.hidden = True
                End If
                sprite.name = $"health"
            Next
        Next
    End Sub
End Class