Imports SFML.Window

Public Class WarpSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return False
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        If Not Keyboard.IsKeyPressed(Keyboard.Key.F3) Then Return

        Console.Write("Warp to: ")
        Dim scene = Console.ReadLine()
        scenes.Open(scene)
        Console.WriteLine($"Warped to {scene}.")
    End Sub
End Class
