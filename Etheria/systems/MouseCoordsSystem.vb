Imports System.ComponentModel
Imports System.Security.Cryptography
Imports SFML.Graphics
Imports SFML.System
Imports SFML.Window

Public Class MouseCoordsSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return False
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        If Not isDebug Then Return

        Dim mousePos = GetMousePosition()

        Dim xLine As New VertexArray
        For y = 0 To windowHeight
            xLine.Append(New Vertex(New Vector2f(mousePos.X, y)))
        Next

        Dim yLine As New VertexArray()
        For x = 0 To windowWidth
            yLine.Append(New Vertex(New Vector2f(x, mousePos.Y)))
        Next

        Dim coordsText As New Text With {
            .FillColor = Color.White,
            .Font = font,
            .DisplayedString = $"({mousePos.X},{mousePos.Y})",
            .Scale = New Vector2f(0.3, 0.3),
            .Position = New Vector2f(mousePos.X + 3, mousePos.Y + 3)
        }

        Window.Draw(xLine)
        Window.Draw(yLine)
        Window.Draw(coordsText)
    End Sub
End Class
