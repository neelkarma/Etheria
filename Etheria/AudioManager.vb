Imports System.IO
Imports SFML.Audio

Public Class AudioManager
    Private ReadOnly sfx As New Dictionary(Of String, Sound)
    Private currentSfx As Sound
    Private setSfxVolume As Single = 100
    Private ReadOnly bgm As New Dictionary(Of String, Music)
    Private currentBgm As Music
    Private setBgmVolume As Single = 100

    Public Property BgmVolume As Integer
        Get
            Return setBgmVolume
        End Get
        Set(value As Integer)
            setBgmVolume = value
            If Not IsNothing(currentBgm) Then
                currentBgm.Volume = value
            End If
        End Set
    End Property

    Public Property SfxVolume As Integer
        Get
            Return setSfxVolume
        End Get
        Set(value As Integer)
            setSfxVolume = value
            If Not IsNothing(currentSfx) Then
                currentSfx.Volume = value
            End If
        End Set
    End Property

    Public Sub New()
        LoadSFX()
        LoadBGM()
    End Sub

    Private Sub LoadSFX()
        sfx("") = New Sound() ' for no sound
        For Each filename In Directory.EnumerateFiles("../../../resources/audio/sfx/")
            sfx(Path.GetFileNameWithoutExtension(filename)) = New Sound(New SoundBuffer(filename))
            Console.WriteLine($"AUDIO: SFX {Path.GetFileNameWithoutExtension(filename)} loaded")
        Next
    End Sub

    Private Sub LoadBGM()
        For Each filename In Directory.EnumerateFiles("../../../resources/audio/bgm/")
            bgm(Path.GetFileNameWithoutExtension(filename)) = New Music(filename) With {.[Loop] = True}
            Console.WriteLine($"AUDIO: BGM {Path.GetFileNameWithoutExtension(filename)} loaded")
        Next
    End Sub

    Public Sub PlaySFX(name As String)
        If Not sfx.ContainsKey(name) Then
            Console.WriteLine($"AUDIO: Warning: No SFX with name {name} exists in the AudioManager!")
            Return
        End If

        currentSfx = sfx(name)
        currentSfx.Volume = sfxVolume
        currentSfx.Play()
    End Sub

    Public Sub PlayBGM(name As String, Optional restart As Boolean = False)
        If Not bgm.ContainsKey(name) Then
            Console.WriteLine($"AUDIO: Warning: No BGM with name {name} exists in the AudioManager!")
            Return
        End If

        If bgm(name) Is currentBgm And Not restart Then Return

        If Not IsNothing(currentBgm) Then currentBgm.Stop()
        currentBgm = bgm(name)
        currentBgm.Volume = BgmVolume
        currentBgm.Play()
    End Sub

    Public Sub TogglePauseBGM()
        If IsNothing(currentBgm) Then Return

        Select Case currentBgm.Status
            Case SoundStatus.Playing
                currentBgm.Pause()
            Case SoundStatus.Paused
                currentBgm.Play()
            Case SoundStatus.Stopped
                Console.WriteLine("AUDIO: Warning: Attempted to pause stopped BGM")
        End Select
    End Sub
End Class
