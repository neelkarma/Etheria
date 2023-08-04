Public Class ButtonComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Button"

    Public action As Action

    Public Sub New(action As Action)
        Me.action = action
    End Sub
End Class
