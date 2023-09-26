Public Class ShopPriceComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "ShopPrice"

    Public powerup As Powerup

    Public Sub New(powerup As Powerup)
        Me.powerup = powerup
    End Sub
End Class
