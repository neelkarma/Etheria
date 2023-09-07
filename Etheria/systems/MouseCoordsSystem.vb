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
        ' TODO: Mouse crosshairs
        Dim mousePos = Mouse.GetPosition(Window)

        Dim xLine As New VertexArray
        For y = 0 To windowHeight
            xLine.Append(New Vertex(New Vector2i(mousePos.X, y)))
        Next

        Dim yLine As New VertexArray()
        For x = 0 To windowWidth
            yLine.Append(New Vertex(New Vector2i(x, mousePos.Y)))
        Next

        ' TODO: fix this not showing
        Dim text As New Text With {
            .DisplayedString = $"{mousePos.X}, {mousePos.Y}",
            .Font = font,
            .FillColor = Color.White,
            .Position = mousePos + New Vector2i(20, 20),
            .Scale = New Vector2i(0.5, 0.5)
        }

        Window.Draw(xLine)
        Window.Draw(yLine)
        Window.Draw(text)
        Console.WriteLine($"MOUSE: ({mousePos.X}, {mousePos.Y})")
    End Sub
End Class
