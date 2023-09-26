Public Class ReactiveTextComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "ReactiveText"

    Public predicate As Func(Of String)

    Public Sub New(predicate As Func(Of String))
        Me.predicate = predicate
    End Sub
End Class
