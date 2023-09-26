Imports SFML.Graphics

Public Class ShopPriceSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Text", "ShopPrice")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        ' todo: why no work
        For Each entity In entities
            Dim text = entity.GetComponent(Of TextComponent)("Text")
            Dim shopPrice = entity.GetComponent(Of ShopPriceComponent)("ShopPrice")

            Dim pow = powerups(shopPrice.powerup)

            If shopPrice.powerup = session.equippedPowerup Then
                text.content = "[EQUIPPED]"
                text.color = Color.Green
                Continue For
            End If

            If session.boughtPowerUps.Contains(shopPrice.powerup) Then
                text.content = "[BOUGHT]"
                text.color = Color.White
                Continue For
            End If

            text.content = $"{pow.price} SHN"
            text.color = If(pow.price > session.shinies, Color.Red, Color.White)
        Next
    End Sub
End Class
