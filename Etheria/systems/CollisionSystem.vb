Imports SFML.Graphics
Imports SFML.System

Public Class CollisionSystem
    Inherits System
    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Position", "Collider")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each e1 In entities
            Dim p1 = e1.GetComponent(Of PositionComponent)("Position")
            Dim c1 = e1.GetComponent(Of ColliderComponent)("Collider")
            Dim r1 = GetGlobalRect(p1, c1)

            c1.collisions.Clear()

            For Each e2 In entities
                If e1 Is e2 Then Continue For

                Dim p2 = e2.GetComponent(Of PositionComponent)("Position")
                Dim c2 = e2.GetComponent(Of ColliderComponent)("Collider")
                Dim r2 = GetGlobalRect(p2, c2)

                If r1.Intersects(r2) Then
                    c1.collisions.Add(e2)
                End If
            Next
        Next
    End Sub
End Class
