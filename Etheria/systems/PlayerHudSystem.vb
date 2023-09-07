Imports SFML.Graphics
Imports SFML.System
Public Class PlayerHudSystem
    Inherits System

    Public Property healthSpriteIds As List(Of Integer) = New List(Of Integer)
    Public Property abilitySpriteIds As List(Of Integer) = New List(Of Integer)
    Public Property highScoreTextId As Integer
    Public Property scoreTextId As Integer
    Public Const scorePadding As Integer = 18

    Public Overrides Function Match(entity As Entity) As Boolean
        Return False
    End Function
    Public Overrides Sub Init(entities As IEnumerable(Of Entity))
        ' Dim hasPlayer As Scenes.CurrentScene.("player")
        For Each entity In entities
            For i = 0 To 2

                Dim healthEntity = entity.GetComponent(Of SpriteComponent)("Sprite")
                healthEntity.hidden = True
                'Dim healthEntity = entity.GetComponent(Of TransformComponent)("Transform")

            Next
        Next

    End Sub
    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        MyBase.Update(entities)

    End Sub
End Class