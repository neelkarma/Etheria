Imports SFML.System

Public Class SettingsScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "Settings"

    Public Overrides Sub InitEntities()
        ' background
        AddEntity(New MenuBackgroundEntity)

        ' title
        AddEntity(New TextComponent("Settings"), New PositionComponent(New Vector2i(0, 0)))


        ' sliders for sfx and bgm

        '' Public Sub New(_soundType As String, _x As Integer, _y As Integer, _leftX As Integer, _rightX As Integer)



        '' AddEntity(New SliderComponent("music", windowWidth / 2 - 10 + musicSliderPos, 71, windowWidth / 2 - 10, windowWidth / 2 + 64))
        AddEntity(New TextComponent("Music"), New PositionComponent(New Vector2i(100, 150)))
        AddEntity(New TextComponent("SFX"), New PositionComponent(New Vector2i(100, 300)))
        AddEntity(New SliderEntity("music", 200, 150, 100, 500, Sub(value) audio.SetBGMVol(value * 100)))
        AddEntity(New SliderEntity("soundfx", 200, 300, 100, 500, Sub(value) audio.SetSFXVol(value * 100)))

        ' fullscreen
        AddEntity(New TextButtonEntity("Fullscreen", New Vector2i(0, 400), Sub() Console.WriteLine("Fullscreen Triggered!")))
        ' back button
        AddEntity(New TextButtonEntity("Back", New Vector2i(0, 500), Sub() scenes.Open("Title")))
        'End Sub
    End Sub
End Class
