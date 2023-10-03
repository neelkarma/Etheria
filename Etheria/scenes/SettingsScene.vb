Imports SFML.System

Public Class SettingsScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "Settings"

    Public Overrides Sub InitEntities()
        ' title
        AddEntity(New TextComponent("Settings",, 42), New PositionComponent(New Vector2f(50, 50)))

        ' music slider
        AddEntity(New TextComponent("Music Vol"), New PositionComponent(New Vector2f(50, 150)))
        AddEntity(New SliderEntity(190, 100, 500, Sub(value) audio.BgmVolume = value * 100, audio.BgmVolume / 100))

        ' sfx slider
        AddEntity(New TextComponent("SFX Vol"), New PositionComponent(New Vector2f(50, 250)))
        AddEntity(New SliderEntity(290, 100, 500, Sub(value) audio.SfxVolume = value * 100, audio.SfxVolume / 100))

        ' fullscreen button
        AddEntity(New TextButtonEntity("Enter Fullscreen", New Vector2f(50, 360), Sub() Console.WriteLine("Fullscreen Triggered!")))

        ' reset leaderboard button
        AddEntity(New TextButtonEntity("Reset Leaderboard", New Vector2f(50, 410), Sub() scenes.Open("ConfirmLeaderboardReset")))

        ' back button
        AddEntity(New TextButtonEntity("Back", New Vector2f(50, 460), Sub() scenes.Open("Title")))
    End Sub
End Class
