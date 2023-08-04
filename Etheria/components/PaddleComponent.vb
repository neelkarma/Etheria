Public Class PaddleComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Paddle"

    Public ReadOnly side As PlayerSide

    Public Sub New(side As PlayerSide)
        Me.side = side
    End Sub
End Class
