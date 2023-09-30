Imports SFML.Graphics
Imports SFML.System

Public Class TitleScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "Title"

    Public Overrides Sub Open(Optional init As Boolean = True)
        MyBase.Open(init)
        audio.PlayBGM("menu")
    End Sub

    Public Overrides Sub InitEntities()
        ' title
        AddEntity(
            New TextComponent("Etheria", Nothing, 1.5),
            New PositionComponent(New Vector2i(50, 50))
        )

        ' buttons
        AddEntity(New TextButtonEntity("Start", New Vector2i(50, 150), Sub() scenes.Open("ShipSelect")))
        AddEntity(New TextButtonEntity("Controls", New Vector2i(50, 200), Sub() scenes.Open("Controls")))
        AddEntity(New TextButtonEntity("Leaderboard", New Vector2i(50, 250), Sub() scenes.Open("Leaderboard")))
        AddEntity(New TextButtonEntity("Settings", New Vector2i(50, 300), Sub() scenes.Open("Settings")))
        AddEntity(New TextButtonEntity("Quit", New Vector2i(50, 350), Sub() scenes.Open("ConfirmExit")))

        ' Copyright notice
        AddEntity(
            New TextComponent("© Sample Text Studios 2023", Color.White, 0.5),
            New PositionComponent(New Vector2i(50, 420))
        )
    End Sub
End Class
