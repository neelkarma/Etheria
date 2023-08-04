Imports SFML.Graphics

Public Class TextButtonSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("TextButton", "Text", "Interactable")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim interactable = entity.GetComponent(Of InteractableComponent)("Interactable")
            Dim text = entity.GetComponent(Of TextComponent)("Text")

            If interactable.isHovered Then
                text.color = Color.Green
            Else
                text.color = Color.White
            End If
        Next
    End Sub
End Class
