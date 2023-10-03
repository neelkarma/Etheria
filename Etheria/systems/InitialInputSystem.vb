Imports SFML.Graphics
Imports SFML.System
Imports SFML.Window

Public Class InitialInputSystem
    Inherits System

    Private pressed As Keyboard.Key = Keyboard.Key.Unknown
    Private continueBtnEnt As Entity = Nothing

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("InitialInput", "Position")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        Dim currentChar = GetCurrentlyPressedAlphaKey()
        If Keyboard.IsKeyPressed(Keyboard.Key.Backspace) Then currentChar = Keyboard.Key.Backspace

        Dim wasInput = currentChar <> pressed
        If wasInput Then
            pressed = currentChar
        End If

        For Each entity In entities
            Dim initialInput = entity.GetComponent(Of InitialInputComponent)("InitialInput")
            Dim position = entity.GetComponent(Of PositionComponent)("Position")

            ' input logic
            If wasInput And pressed <> Keyboard.Key.Unknown Then
                If pressed = Keyboard.Key.Backspace Then
                    If initialInput.value.Length = 0 Then Return
                    initialInput.value = initialInput.value.Substring(0, initialInput.value.Length - 1)
                Else
                    If initialInput.value.Length = 3 Then Return
                    initialInput.value += KeyboardKeyToChar(pressed)
                End If
            End If

            ' rendering
            Dim textRenderable As New Text With {
                .DisplayedString = initialInput.value,
                .Position = position.pos,
                .FillColor = Color.White,
                .Font = font
            }

            Window.Draw(textRenderable)

            ' Draw cursor
            If initialInput.value.Length <> 3 Then
                Static cursorSize As New Vector2f(3, 27) ' do not change this
                Dim textBounds = textRenderable.GetGlobalBounds()

                Window.Draw(New RectangleShape(cursorSize) With {
                     .Position = New Vector2f(textBounds.Left + textBounds.Width + 3, textBounds.Top),
                     .FillColor = Color.White
                })
            End If

            ' handle the continue button if we're in the gameover scene
            If scenes.currentSceneName = "GameOver" Then
                If initialInput.value.Length = 3 And IsNothing(continueBtnEnt) Then
                    ' add continue button
                    continueBtnEnt = New TextButtonEntity("Continue", New Vector2f(50, 370), Sub()
                                                                                                 leaderboard.RecordScore(initialInput.value, session.score)
                                                                                                 scenes.Open("Title")
                                                                                             End Sub)
                    scenes.CurrentScene.AddEntity(continueBtnEnt)
                ElseIf initialInput.value.Length <> 3 And Not IsNothing(continueBtnEnt) Then
                    ' remove continue button
                    scenes.CurrentScene.RemoveEntity(continueBtnEnt)
                    continueBtnEnt = Nothing
                End If
            End If
        Next
    End Sub
End Class
