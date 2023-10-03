Imports SFML.Graphics
Imports SFML.System

Public Class SpriteColliderSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Sprite", "Collider")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim sprite = entity.GetComponent(Of SpriteComponent)("Sprite")
            If Not sprite.overrideCollider Then Continue For

            Dim collider = entity.GetComponent(Of ColliderComponent)("Collider")
            sprite.Sprite.Position = New Vector2f()
            Dim spriteBounds = sprite.Sprite.GetGlobalBounds()
            collider.rect = spriteBounds
        Next
    End Sub
End Class
