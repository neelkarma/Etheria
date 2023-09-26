Public Class ReactiveTextSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Text", "ReactiveText")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim text = entity.GetComponent(Of TextComponent)("Text")
            Dim reactiveText = entity.GetComponent(Of ReactiveTextComponent)("ReactiveText")

            text.content = reactiveText.predicate()
        Next
    End Sub
End Class
