Imports SFML.Graphics

Public Module Utils
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
End Module
