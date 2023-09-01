Imports System.IO
Imports SFML.Audio

Public Class AudioManager
    Private ReadOnly sfx As New Dictionary(Of String, Sound)
    Private currentSfx As Sound
    Private ReadOnly bgm As New Dictionary(Of String, Music)
    Private currentBgm As Music

    Public Sub New()
        LoadSFX()
        LoadBGM()
    End Sub

    Private Sub LoadSFX()
        For Each filename In Directory.EnumerateFiles("../../../resources/audio/sfx/")
            sfx(Path.GetFileNameWithoutExtension(filename)) = New Sound(New SoundBuffer(filename))
        Next
    End Sub

    Private Sub LoadBGM()
        For Each filename In Directory.EnumerateFiles("../../../resources/audio/bgm/")
            bgm(Path.GetFileNameWithoutExtension(filename)) = New Music(filename) With {.[Loop] = True}
        Next
    End Sub

    Public Sub PlaySFX(name As String)
        currentSfx = sfx(name)
        currentSfx.Play()
    End Sub

    Public Sub PlayBGM(name As String)
        currentBgm = bgm(name)
        currentBgm.Play()
    End Sub

    Public Sub SetBGMVol(value As Single)
        currentBgm.Volume = value
    End Sub

    Public Sub SetSFXVol(value As Single)
        currentSfx.Volume = value
    End Sub
End Class
