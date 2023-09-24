Public Class DebugSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return False
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        ' Console.WriteLine(InteractableComponent.holdIsLocked)
    End Sub
End Class
