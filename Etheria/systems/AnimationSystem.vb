Public Class AnimationSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponent("Sprite")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim sprite = entity.GetComponent(Of SpriteComponent)("Sprite")

            sprite.framesUntilNext -= 1
            If sprite.framesUntilNext < 0 Then
                sprite.framesUntilNext = sprite.frameDuration
                sprite.frame += 1
                If sprite.frame >= sprites.GetSprites(sprite.name).Length Then
                    sprite.frame = 0
                End If
            End If
        Next
    End Sub
End Class
