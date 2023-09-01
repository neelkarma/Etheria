Imports SFML.Graphics

Public Module Utils
    Public Iterator Function Enumerate(Of T)(input As IEnumerable(Of T), Optional start As Integer = 0) As IEnumerable(Of (Integer, T))
        For Each item In input
            Yield (start, item)
            start += 1
        Next
    End Function

    Public Function GetGlobalRect(p As PositionComponent, c As ColliderComponent) As IntRect
        Return New IntRect(c.rect.Left + p.pos.X, c.rect.Top + p.pos.Y, c.rect.Width, c.rect.Height)
    End Function

    Public Function GetSideName(side As PlayerSide) As String
        Select Case side
            Case PlayerSide.Left
                Return "Left Player"
            Case PlayerSide.Right
                Return "Right Player"
        End Select
#Disable Warning BC42105 ' we have covered all enum variants, so this warning is irrelevant
    End Function
#Enable Warning BC42105

    Public Function CalculateTextRect(text As String, Optional scale As Decimal = 1) As FloatRect
        Return New Text(text, font, scale).GetLocalBounds()
    End Function

    Public Sub CheckHighScore(score As Integer)
        For i As Integer = 0 To 9
            If score > highscores(i) Then
                highscores.Insert(i, score)
                If highscores.Count > 10 Then
                    highscores.RemoveAt(10)
                End If
                Exit For
            End If
        Next
    End Sub
    Public Sub SaveHighScore()
        Dim temp As String = ""
        For i = 0 To highscores.Count - 1
            temp += $"{highscores(i)}{vbCrLf}"
        Next

        IO.File.WriteAllText("../../../resources/data/highscores.txt", temp)
    End Sub
    Public Sub LoadHighScore()
        highscores.Clear()
        For Each line In IO.File.ReadLines("../../../resources/data/highscores.txt")
            highscores.Add(line)
        Next line
        While highscores.Count < 10
            highscores.Add(0)
        End While
    End Sub
End Module
