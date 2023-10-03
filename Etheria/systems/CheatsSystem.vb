Imports SFML.Window

Public Class CheatsSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return False
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        If Not Keyboard.IsKeyPressed(Keyboard.Key.F1) Then Return

        Console.WriteLine("Choose which variable you wish to modify:")
        Console.WriteLine("0) Cancel 1) Score 2) Shinies 3) Level 4) Lives")
        Console.Write("> ")
        Dim variable = CInt(Console.ReadLine())
        Console.Write("Value: ")
        Dim value = CInt(Console.ReadLine())

        Dim modified As String
        Select Case variable
            Case 0
                Return
            Case 1
                session.score = value
                modified = "score"
            Case 2
                session.shinies = value
                modified = "shinies"
            Case 3
                session.level = value
                modified = "level"
            Case 4
                session.lives = value
                modified = "lives"
            Case Else
                Console.WriteLine("Invalid variable provided.")
                Return
        End Select
        Console.WriteLine($"Set {modified} to {value}.")
    End Sub
End Class
