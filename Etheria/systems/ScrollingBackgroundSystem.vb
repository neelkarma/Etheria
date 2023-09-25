Imports SFML.System

Public Class ScrollingBackgroundSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("ScrollingBackground")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim scrollingBackground = entity.GetComponent(Of ScrollingBackgroundComponent)("ScrollingBackground")

            Dim sprite = scrollingBackground.Sprite
            Dim spriteBounds = sprite.GetGlobalBounds()

            Dim repeatX = Math.Ceiling((windowWidth + scrollingBackground.offset) / spriteBounds.Width)
            Dim repeatY = Math.Ceiling(windowHeight / spriteBounds.Height)

            For y = 0 To repeatY
                For x = 0 To repeatX
                    sprite.Position = New Vector2i(x * spriteBounds.Width - scrollingBackground.offset, y * spriteBounds.Height)
                    Window.Draw(sprite)
                Next
            Next

            scrollingBackground.offset = (scrollingBackground.offset + scrollingBackground.speed) Mod spriteBounds.Width
        Next
    End Sub
End Class
