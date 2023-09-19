Imports SFML.Graphics

Public Module Utils
    Public Iterator Function Enumerate(Of T)(input As IEnumerable(Of T), Optional start As Integer = 0) As IEnumerable(Of (Integer, T))
        For Each item In input
            Yield (start, item)
            start += 1
        Next
    End Function

    Public Function GetGlobalRect(p As PositionComponent, c As ColliderComponent) As IntRect
        Return New IntRect(c.rect.Left + p.pos.X, c.rect.Top + p.pos.Y, c.rect.Width, c.rect.Height)
    End Function

    Public Function GetSideName(side As PlayerSide) As String
        Select Case side
            Case PlayerSide.Left
                Return "Left Player"
            Case PlayerSide.Right
                Return "Right Player"
        End Select
#Disable Warning BC42105 ' we have covered all enum variants, so this warning is irrelevant
    End Function
#Enable Warning BC42105

    Public Function CalculateTextRect(text As String, Optional scale As Decimal = 1) As IntRect
        Return New Text(text, font, scale).GetGlobalBounds()
    End Function
End Module
