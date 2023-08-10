Imports SFML.Audio

Public Class AudioManager
    Private ReadOnly sfx As New Dictionary(Of String, Sound)
    Private currentSfx As Sound
    Private ReadOnly bgm As New Dictionary(Of String, Music)
    Private currentBgm As Music

    Public Sub New()
        ' TODO: Load sfx here
        ' Load bgm here
        LoadBGM("grass-beach.wav", "spongebob")

    End Sub

    Private Sub LoadSFX(filename As String, name As String)
        sfx(name) = New Sound(New SoundBuffer("../../../resources/audio/sfx/" + filename))
    End Sub

    Private Sub LoadBGM(filename As String, name As String)
        bgm(name) = New Music("../../../resources/audio/bgm/" + filename) With {.[Loop] = True}
    End Sub

    Public Sub PlaySFX(name As String)
        currentSfx = sfx(name)
        currentSfx.Play()
    End Sub

    Public Sub PlayBGM(name As String)
        currentBgm = bgm(name)
        currentBgm.Play()
    End Sub
End Class
