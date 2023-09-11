Public Class EnemySystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Enemy", "Transform", "Collider", "Sprite")
    End Function


    Public Overrides Sub Update(entities As IEnumerable(Of Entity))



    End Sub

End Class