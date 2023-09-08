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
        Dim mousePos = Mouse.GetPosition(Window)

        Dim xLine As New VertexArray
        For y = 0 To windowHeight
            xLine.Append(New Vertex(New Vector2i(mousePos.X, y)))
        Next

        Dim yLine As New VertexArray()
        For x = 0 To windowWidth
            yLine.Append(New Vertex(New Vector2i(x, mousePos.Y)))
        Next

        Window.Draw(xLine)
        Window.Draw(yLine)
        Console.WriteLine($"MOUSE: ({mousePos.X}, {mousePos.Y})")
    End Sub
End Class
