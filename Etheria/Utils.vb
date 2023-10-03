Imports SFML.Graphics
Imports SFML.System
Imports SFML.Window

Public Module Utils
    Public Iterator Function Enumerate(Of T)(input As IEnumerable(Of T), Optional start As Integer = 0) As IEnumerable(Of (Integer, T))
        For Each item In input
            Yield (start, item)
            start += 1
        Next
    End Function

    Public Function GetGlobalRect(p As PositionComponent, c As ColliderComponent) As FloatRect
        Return New FloatRect(p.pos.X + c.rect.Left, p.pos.Y + c.rect.Top, c.rect.Width, c.rect.Height)
    End Function

    Public Function GetRectCenter(rect As FloatRect) As Vector2f
        Return New Vector2f(rect.Left + (rect.Width / 2), rect.Top + (rect.Height / 2))
    End Function

    Public Function CalculateTextRect(text As String, Optional size As Integer = 36) As FloatRect
        Return New Text(text, font, size).GetGlobalBounds()
    End Function

    Public Function GetCurrentlyPressedAlphaKey() As Keyboard.Key
        For Each key In New Keyboard.Key() {
            Keyboard.Key.A,
            Keyboard.Key.B,
            Keyboard.Key.C,
            Keyboard.Key.D,
            Keyboard.Key.E,
            Keyboard.Key.F,
            Keyboard.Key.G,
            Keyboard.Key.H,
            Keyboard.Key.I,
            Keyboard.Key.J,
            Keyboard.Key.K,
            Keyboard.Key.L,
            Keyboard.Key.M,
            Keyboard.Key.N,
            Keyboard.Key.O,
            Keyboard.Key.P,
            Keyboard.Key.Q,
            Keyboard.Key.R,
            Keyboard.Key.S,
            Keyboard.Key.T,
            Keyboard.Key.U,
            Keyboard.Key.V,
            Keyboard.Key.W,
            Keyboard.Key.X,
            Keyboard.Key.Y,
            Keyboard.Key.Z
        }

            If Keyboard.IsKeyPressed(key) Then Return key
        Next

        Return Keyboard.Key.Unknown
    End Function

    Public Function KeyboardKeyToChar(key As Keyboard.Key) As Char
        Select Case key
            Case Keyboard.Key.A
                Return "A"
            Case Keyboard.Key.B
                Return "B"
            Case Keyboard.Key.C
                Return "C"
            Case Keyboard.Key.D
                Return "D"
            Case Keyboard.Key.E
                Return "E"
            Case Keyboard.Key.F
                Return "F"
            Case Keyboard.Key.G
                Return "G"
            Case Keyboard.Key.H
                Return "H"
            Case Keyboard.Key.I
                Return "I"
            Case Keyboard.Key.J
                Return "J"
            Case Keyboard.Key.K
                Return "K"
            Case Keyboard.Key.L
                Return "L"
            Case Keyboard.Key.M
                Return "M"
            Case Keyboard.Key.N
                Return "N"
            Case Keyboard.Key.O
                Return "O"
            Case Keyboard.Key.P
                Return "P"
            Case Keyboard.Key.Q
                Return "Q"
            Case Keyboard.Key.R
                Return "R"
            Case Keyboard.Key.S
                Return "S"
            Case Keyboard.Key.T
                Return "T"
            Case Keyboard.Key.U
                Return "U"
            Case Keyboard.Key.V
                Return "V"
            Case Keyboard.Key.W
                Return "W"
            Case Keyboard.Key.X
                Return "X"
            Case Keyboard.Key.Y
                Return "Y"
            Case Keyboard.Key.Z
                Return "Z"
            Case Else
                Return ""
        End Select
    End Function
End Module
