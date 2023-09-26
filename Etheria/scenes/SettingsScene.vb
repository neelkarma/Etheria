Imports SFML.System

Public Class SettingsScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "Settings"

    Public Overrides Sub InitEntities()
        ' background
        AddEntity(New MenuBackgroundEntity)

        ' title
        AddEntity(New TextComponent("Settings",, 1.5), New PositionComponent(New Vector2i(50, 50)))

        ' music slider
        AddEntity(New TextComponent("Music Vol"), New PositionComponent(New Vector2i(50, 150)))
        AddEntity(New SliderEntity(190, 100, 500, Sub(value) audio.BgmVolume = value * 100, audio.BgmVolume / 100))

        ' sfx slider
        AddEntity(New TextComponent("SFX Vol"), New PositionComponent(New Vector2i(50, 250)))
        AddEntity(New SliderEntity(290, 100, 500, Sub(value) audio.SfxVolume = value * 100, audio.SfxVolume / 100))

        ' fullscreen button
        AddEntity(New TextButtonEntity("Enter Fullscreen", New Vector2i(50, 360), Sub() Console.WriteLine("Fullscreen Triggered!")))

        ' back button
        AddEntity(New TextButtonEntity("Back", New Vector2i(50, 430), Sub() scenes.Open("Title")))
    End Sub
End Class
