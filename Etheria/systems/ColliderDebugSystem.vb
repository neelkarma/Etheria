Imports SFML.Graphics
Imports SFML.System
Imports SFML.Window

Public Class ColliderDebugSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Position", "Collider")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        If Not isDebug Then Return

        For Each entity In entities
            Dim position = entity.GetComponent(Of PositionComponent)("Position")
            Dim collider = entity.GetComponent(Of ColliderComponent)("Collider")
            Window.Draw(
                New RectangleShape() With {
                    .Position = position.pos,
                    .Size = New Vector2f(collider.rect.Width, collider.rect.Height),
                    .FillColor = Color.Transparent,
                    .OutlineColor = Color.Red,
                    .OutlineThickness = 2
                }
            )

        Next
    End Sub
End Class
