Public Class ButtonActionSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Button", "Interactable")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim interactable = entity.GetComponent(Of InteractableComponent)("Interactable")
            Dim button = entity.GetComponent(Of ButtonComponent)("Button")
            If interactable.wasClicked Then
                button.action.Invoke()
            End If
        Next
    End Sub
End Class
