Public Class ScreenCollisionSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return False
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim position = entity.GetComponent(Of PositionComponent)("Position")
            Dim collider = entity.GetComponent(Of ScreenColliderComponent)("ScreenCollider")
            If collider.Type = "remove" Then
                If position.pos.X + collider.pos1.X > windowWidth - 1 Or position.pos.X + collider.pos2.X < 0 Or
                   position.pos.Y + collider.pos1.Y > windowHeight - 1 Or position.pos.Y + collider.pos2.Y < 0 Then
                    scenes.CurrentScene.RemoveEntity(entity)
                End If
            ElseIf collider.Type = "removeLeft" Then
                If position.pos.X + collider.pos2.X < 0 Then
                    scenes.CurrentScene.RemoveEntity(entity)
                End If

            ElseIf collider.Type = "collide" Then
                If position.pos.X + collider.pos2.X > windowWidth - 1 Then
                    position.pos.X = windowWidth - 1 - collider.pos2.X
                ElseIf position.pos.X + collider.pos1.X < 0 Then
                    position.pos.X = -collider.pos1.X
                End If

                If position.pos.Y + collider.pos2.Y > windowHeight - 1 Then
                    position.pos.Y = windowHeight - 1 - collider.pos2.Y
                ElseIf position.pos.Y + collider.pos1.Y < 0 Then
                    position.pos.Y = -collider.pos1.Y
                End If
            End If

        Next

    End Sub
End Class