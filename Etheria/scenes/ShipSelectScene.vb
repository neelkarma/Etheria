Imports SFML.Graphics
Imports SFML.System

Public Class ShipSelectScene
    Inherits Scene
    Public Overrides ReadOnly Property Type As String = "ShipSelect"


    Public Overrides Sub InitEntities()
        ' Background
        AddEntity(New MenuBackgroundEntity())

        ' Text: Select a Ship
        AddEntity(
            New TextComponent("Drag your ship into the box to continue!",, 0.6),
            New PositionComponent(New Vector2i(10, 50))
        )

        ' Drop Target
        Dim dropTarget = AddEntity(
                New PositionComponent(New Vector2i(300, 300)),
                New ColliderComponent(New IntRect(New Vector2i(), New Vector2i(200, 200))),
                New SpriteComponent("ship-blue",, New Vector2f(0.4, 0.4))
            )

        ' Ships
        For Each tup In Enumerate({"ship-blue", "ship-purple", "ship-red", "ship-yellow", "ship-green"})
            Dim i = tup.Item1
            Dim sprite = tup.Item2
            Dim spriteSize = sprites.GetSprites(sprite)(0).GetLocalBounds()
            Const scale = 0.3

            AddEntity(
                New PositionComponent(New Vector2i(30 + i * 150, 200)),
                New SpriteComponent(sprite,, New Vector2f(scale, scale)),
                New ColliderComponent(New IntRect(New Vector2i(0, 0), New Vector2i(spriteSize.Width * scale, spriteSize.Height * scale))),
                New InteractableComponent(),
                New DraggableComponent(New Integer() {dropTarget.id}, sprite)
            )
        Next

        ' Back Button
        AddEntity(
            New TextButtonEntity("Back", New Vector2i(100, 600), Sub() scenes.Open("Title"))
        )

        ' Advance Button
        AddEntity(
            New TextButtonEntity("Advance", New Vector2i(600, 600), Sub() Console.WriteLine("Advance Clicked"))
        )


    End Sub
End Class
