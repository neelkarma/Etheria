Imports System.ComponentModel
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
        xLine.Append(New Vertex(New Vector2i(mousePos.X, 0)))
        xLine.Append(New Vertex(New Vector2i(mousePos.X, windowHeight)))

        Dim yLine As New VertexArray()
        yLine.Append(New Vertex(New Vector2i(0, mousePos.Y)))
        yLine.Append(New Vertex(New Vector2i(windowWidth, mousePos.Y)))

        Window.Draw(xLine)
        Window.Draw(yLine)
        Console.WriteLine($"MOUSE: ({mousePos.X}, {mousePos.Y})")
    End Sub
End Class
