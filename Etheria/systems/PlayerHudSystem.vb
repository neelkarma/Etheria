Imports SFML.Graphics
Imports SFML.System
Public Class PlayerHudSystem
    Inherits System

    Public Property healthSpriteIds As List(Of Integer) = New List(Of Integer)
    Public Property abilitySpriteIds As List(Of Integer) = New List(Of Integer)
    Public Property highScoreTextId As Integer
    Public Property scoreTextId As Integer
    Public Const scorePadding As Integer = 18

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponent("PlayerHUDComponent")
    End Function
    Public Overrides Sub Init(entities As IEnumerable(Of Entity))
        ' Dim hasPlayer As Scenes.CurrentScene.("player")
        For Each entity In entities
            Dim hud = entity.GetComponent(Of PlayerHUDComponent)("PlayerHUD")

            For i = 0 To 2
                Dim healthEntity As Entity = New Entity(
                        New SpriteComponent(1,,, True),
                        New TransformComponent(i * 8, 0, 0, 0)
                    )
                healthSpriteIds.Add(healthEntity.id)

                scenes.CurrentScene.AddEntity(healthEntity)

            Next
            For i = 0 To 2
                Dim healthEntity As Entity = New Entity(
                    New SpriteComponent(1,,, True),
                    New TransformComponent(36 + i * 8, 0, 0, 0)
                )
                healthSpriteIds.Add(healthEntity.id)

                scenes.CurrentScene.AddEntity(healthEntity)
            Next
            For i = 0 To 1
                Dim healthEntity As Entity = New Entity(
                    New SpriteComponent(1,,, True),
                    New TransformComponent(24 + i * 8, 0, 0, 0)
                )
                healthSpriteIds.Add(healthEntity.id)

                scenes.CurrentScene.AddEntity(healthEntity)
            Next

        Next

    End Sub
    Public Overrides Sub Update(entities As IEnumerable(Of Entity))

        If scenes.CurrentScene.Type <> "GameScene" Then
            Return
        End If
        ' Dim _playerComponent = Entity.GetComponent(PlayerComponent)("PLayer")

    End Sub
End Class