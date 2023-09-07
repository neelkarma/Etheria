Public Class ScreenCollisionSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return False
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim pos = entity.GetComponent(Of TransformComponent)("Transform")
            Dim collider = entity.GetComponent(Of ScreenColliderComponent)("ScreenCollider")
            If collider.Type = "remove" Then
                If pos.pos.X + collider.pos1.X > windowWidth - 1 Or pos.pos.X + collider.pos2.X < 0 Or
                   pos.pos.Y + collider.pos1.Y > windowHeight - 1 Or pos.pos.Y + collider.pos2.Y < 0 Then
                    scenes.CurrentScene.RemoveEntity(entity)
                End If
            ElseIf collider.Type = "removeLeft" Then
                If pos.pos.X + collider.pos2.X < 0 Then
                    scenes.CurrentScene.RemoveEntity(entity)
                End If

            ElseIf collider.Type = "collide" Then
                If pos.pos.X + collider.pos2.X > windowWidth - 1 Then
                    pos.pos.X = windowWidth - 1 - collider.pos2.X
                ElseIf pos.pos.X + collider.pos1.X < 0 Then
                    pos.pos.X = -collider.pos1.X
                End If

                If pos.pos.Y + collider.pos2.Y > windowHeight - 1 Then
                    pos.pos.Y = windowHeight - 1 - collider.pos2.Y
                ElseIf pos.pos.Y + collider.pos1.Y < 0 Then
                    pos.pos.Y = -collider.pos1.Y
                End If
            End If

        Next

    End Sub
End Class