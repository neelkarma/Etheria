Imports SFML.System

Public Class SettingsScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "Settings"

    Public Overrides Sub InitEntities()
        ' background
        ' TODO: add once the code is synced

        ' title
        AddEntity(New TextComponent("Settings"), New PositionComponent(New Vector2i(0, 0)))


        ' sliders for sfx and bgm
    End Sub
    Public Sub New(_soundType As String, _x As Integer, _y As Integer, _leftX As Integer, _rightX As Integer)

        AddEntity(New SliderComponent("music", windowWidth / 2 - 10 + musicSliderPos, 71, windowWidth / 2 - 10, windowWidth / 2 + 64))

        ' fullscreen
        AddEntity(New TextButtonEntity("Fullscreen", New Vector2i(0, 0), Sub() Console.WriteLine("Fullscreen Triggered!")))
        ' back button
        AddEntity(New TextButtonEntity("Back", New Vector2i(0, 0), Sub() scenes.Open("Title")))
    End Sub
End Class
