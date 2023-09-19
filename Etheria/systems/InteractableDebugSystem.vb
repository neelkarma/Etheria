Imports SFML.Graphics
Imports SFML.System
Imports SFML.Window

Public Class InteractableDebugSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Interactable", "Position")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        If Not isDebug Then Return

        For Each entity In entities
            Dim interactable = entity.GetComponent(Of InteractableComponent)("Interactable")
            Dim position = entity.GetComponent(Of PositionComponent)("Position")

            Dim indicatorList As New List(Of Color) From {
                Color.White
            }

            If interactable.isHovered Then indicatorList.Add(Color.Red)
            If interactable.isHeld Then indicatorList.Add(Color.Green)
            If interactable.wasReleased Then indicatorList.Add(Color.Blue)
            If entity.id = InteractableComponent.holdIsLocked Then indicatorList.Add(Color.Yellow)

            Const gap = 5
            Const size = 5

            For Each indicator In Enumerate(indicatorList)
                Dim i = indicator.Item1
                Dim color = indicator.Item2

                Window.Draw(
                    New RectangleShape() With {
                        .Position = New Vector2i(position.pos.X + (i * (size + gap)), position.pos.Y - gap - size),
                        .Size = New Vector2i(size, size),
                        .FillColor = color
                    }
                )
            Next
        Next
    End Sub
End Class
