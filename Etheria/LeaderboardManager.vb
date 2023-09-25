Public Class LeaderboardManager
    Private Const filepath As String = "../../../resources/data/highscores.txt"

    Public ReadOnly leaderboard As New List(Of (String, Integer))

    Public Sub New()
        Load()
    End Sub

    Private Sub Load()
        leaderboard.Clear()
        For Each line In IO.File.ReadLines(filepath)
            Dim segments = line.Split(";")
            leaderboard.Add((segments(0), segments(1)))
        Next

        ' Pad out remaining places if there are less than 10 high scores
        While leaderboard.Count < 10
            leaderboard.Add(("-", 0))
        End While
    End Sub

    Private Sub Save()
        Dim out As String = ""
        For Each entry In Leaderboard
            Dim name = entry.Item1
            Dim score = entry.Item2
            out += $"{name};{score}{vbCrLf}"
        Next
        IO.File.WriteAllText(filepath, out)
    End Sub

    Public Sub RecordScore(name As String, score As Integer)
        For i = 0 To 9
            If score <= leaderboard(i).Item2 Then Continue For

            leaderboard.Insert(i, (name, score))
            If leaderboard.Count > 10 Then leaderboard.RemoveAt(10)
            Exit For
        Next
        Save()
    End Sub

    Public Function CheckScore(score As Integer) As Boolean
        Return score > Leaderboard.Last().Item2
    End Function
End Class
