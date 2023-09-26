﻿Imports System.IO
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
        currentSfx.Volume = sfxVolume
        currentSfx.Play()
    End Sub

    Public Sub PlayBGM(name As String)
        currentBgm = bgm(name)
        currentBgm.Volume = bgmVolume
        currentBgm.Play()
    End Sub
End Class
