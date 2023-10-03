Imports SFML.Graphics
Imports SFML.System

Public Class ShipSelectScene
    Inherits Scene
    Public Overrides ReadOnly Property Type As String = "ShipSelect"

    Public Overrides Sub Open(Optional init As Boolean = True)
        MyBase.Open(init)
        session.Reset()
    End Sub

    Public Overrides Sub InitEntities()
        ' Text: Select a Ship
        AddEntity(
            New TextComponent("Drag your ship into the box to continue!",, 18),
            New PositionComponent(New Vector2f(40, 50))
        )

        ' Drop Target
        Dim dropTarget = AddEntity(
                New PositionComponent(New Vector2f(300, 300)),
                New ColliderComponent(New FloatRect(New Vector2f(), New Vector2f(200, 200))),
                New DropTargetComponent(),
                New RectComponent(New FloatRect(-28, -37, 200, 200), Color.Transparent, Color.White, 5),
                New SpriteComponent("ship-blue",, 0.4, True)
            )

        ' Ships
        For Each tup In Enumerate({"ship-blue", "ship-purple", "ship-red", "ship-yellow", "ship-green"})
            Const scale = 0.3

            Dim i = tup.Item1
            Dim sprite = tup.Item2
            Dim spriteComponent As New SpriteComponent(sprite,, scale)

            AddEntity(
                New PositionComponent(New Vector2f(30 + i * 150, 150)),
                spriteComponent,
                New ColliderComponent(spriteComponent.Sprite.GetGlobalBounds()),
                New InteractableComponent(),
                New DraggableComponent(New Integer() {dropTarget.id}, sprite)
            )
        Next

        ' Back Button
        AddEntity(
            New TextButtonEntity("Back", New Vector2f(50, 400), Sub() scenes.Open("Title"))
        )

        ' the advance button gets added in the DraggableSystem after a valid item is dropped
    End Sub
End Class
