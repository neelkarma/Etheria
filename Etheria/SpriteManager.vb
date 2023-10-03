Imports System.IO
Imports System.Text.RegularExpressions
Imports SFML.Graphics



Public Class SpriteManager
    Private Class FileNameComparer
        Implements IComparer(Of FileInfo)

        Private Shared Function ExtractNumber(str As String) As Integer
            If Not Regex.IsMatch(str, "\d+") Then
                Console.WriteLine($"FileNameComparer: Warning: No number found in file name {str} - sprite animation frame order may be incorrect!")
                Return -1
            End If
            Return Regex.Match(str, "\d+").Value
        End Function

        Private Function Compare(x As FileInfo, y As FileInfo) As Integer Implements IComparer(Of FileInfo).Compare
            Return ExtractNumber(x.Name).CompareTo(ExtractNumber(y.Name))
        End Function
    End Class

    Private ReadOnly sprites As New Dictionary(Of String, Sprite())

    Public Sub New()
        ' Load all sprites
        LoadSingles()
        LoadAnimations()
    End Sub

    Private Sub LoadSingles()
        For Each filename In Directory.EnumerateFiles("../../../resources/sprites/singles/")
            sprites(Path.GetFileNameWithoutExtension(filename)) = New Sprite() {New Sprite(New Texture(filename))}
            Console.WriteLine($"SPRITES: Single {Path.GetFileNameWithoutExtension(filename)} loaded")
        Next
    End Sub


    Private Sub LoadAnimations()
        For Each d In New DirectoryInfo("../../../resources/sprites/animations/").EnumerateDirectories()
            Dim frames As New List(Of Sprite)

            ' file order by GetFiles() is not guaranteed - we have to sort manually
            Dim files = d.GetFiles()
            Array.Sort(files, New FileNameComparer())

            For Each file In files
                frames.Add(New Sprite(New Texture(file.FullName)))
            Next

            sprites(d.Name) = frames.ToArray()
            Console.WriteLine($"SPRITES: Animation {d.Name} loaded ({frames.Count} frames)")
        Next
    End Sub

    Public Function GetSprites(name As String) As Sprite()
        If sprites.ContainsKey(name) Then
            Return sprites(name)
        Else
            Console.WriteLine($"SPRITES: Warning: No sprites with name {name} exist in the SpriteManager.")
            Return sprites("error")
        End If
    End Function

End Class
