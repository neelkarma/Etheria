Imports SFML.Window

Public Class WarpSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return False
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        If Not Keyboard.IsKeyPressed(Keyboard.Key.F3) Then Return

        Console.Write("Warp to (leave blank to cancel): ")
        Dim scene = Console.ReadLine()
        If scene.Length = 0 Then Return
        If Not scenes.HasScene(scene) Then
            Console.WriteLine("Invalid scene provided.")
            Return
        End If
        scenes.Open(scene)
        Console.WriteLine($"Warped to {scene}.")
    End Sub
End Class
