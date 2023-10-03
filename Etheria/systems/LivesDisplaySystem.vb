Imports SFML.System

Public Class LivesDisplaySystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Lives", "Position")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim position = entity.GetComponent(Of PositionComponent)("Position")

            Dim heartSprite = sprites.GetSprites("heart")(0)
            heartSprite.Scale = New Vector2f(0.07, 0.07)

            Dim heartBounds = heartSprite.GetGlobalBounds()

            For i = 1 To session.lives
                heartSprite.Position = New Vector2f(position.pos.X - ((heartBounds.Width + 2) * i), position.pos.Y)
                Window.Draw(heartSprite)
            Next
        Next
    End Sub
End Class
