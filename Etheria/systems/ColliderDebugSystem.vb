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

            Dim rect = GetGlobalRect(position, collider)
            Window.Draw(
                New RectangleShape(New Vector2i(rect.Width, rect.Height)) With {
                    .Position = New Vector2i(rect.Left, rect.Top),
                    .FillColor = Color.Transparent,
                    .OutlineColor = Color.Red,
                    .OutlineThickness = 2
                }
            )

        Next
    End Sub
End Class
