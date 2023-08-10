Imports SFML
Imports SFML.Graphics

Public Class SpriteManager
    Private ReadOnly sprites As New Dictionary(Of String, Sprite())

    Public Sub New()
        ' TODO: Load all sprites here
        LoadSingle("sample.png", "sampleSingle")
        LoadAnimation("sample", "sampleAnimation", 4)
    End Sub

    Private Sub LoadSingle(filename As String, name As String)
        Dim t As New Texture("../../../resources/sprites/singles/" + filename)
        sprites(name) = New Sprite() {New Sprite(t)}
    End Sub

    Private Sub LoadAnimation(directory As String, name As String, num_frames As Integer)
        ' TODO: We don't actually need num_frames if we can read all files in the directory!
        Dim frames As New List(Of Sprite)
        For i = 0 To num_frames - 1
            Dim filename = $"../../../resources/sprites/animations/{directory}/{i}.png"
            frames.Add(New Sprite(New Texture(filename)))
        Next
        sprites(name) = frames.ToArray()
    End Sub

    Public Function GetSprites(name As String) As Sprite()
        If sprites.ContainsKey(name) Then
            Return sprites(name)
        Else
            Throw New KeyNotFoundException($"No sprites with name {name} exists in the SpriteManager.")
        End If
    End Function

End Class
