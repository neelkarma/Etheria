Imports System.IO
Imports SFML
Imports SFML.Graphics

Public Class SpriteManager
    Private ReadOnly sprites As New Dictionary(Of String, Sprite())

    Public Sub New()
        ' Load all sprites
        LoadSingles()
        LoadAnimations()
    End Sub

    Private Sub LoadSingles()
        For Each filename In Directory.EnumerateFiles("../../../resources/sprites/singles/")
            sprites(Path.GetFileNameWithoutExtension(filename)) = New Sprite() {New Sprite(New Texture(filename))}
        Next
    End Sub


    Private Sub LoadAnimations()
        For Each dirName In Directory.EnumerateDirectories("../../../resources/sprites/animations/")

            Dim frames As New List(Of Sprite)
            For Each filename In Directory.EnumerateFiles(dirName)
                frames.Add(New Sprite(New Texture(filename)))
            Next

            sprites(dirName) = frames.ToArray()
        Next
    End Sub

    Public Function GetSprites(name As String) As Sprite()
        If sprites.ContainsKey(name) Then
            Return sprites(name)
        Else
            Throw New KeyNotFoundException($"No sprites with name {name} exists in the SpriteManager.")
        End If
    End Function

End Class
