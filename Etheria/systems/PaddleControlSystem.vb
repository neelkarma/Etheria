Imports SFML.Window

Public Class PaddleControlSystem
    Inherits System
    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Paddle", "Position", "Velocity", "Collider")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        Const movingVelocity As Integer = 10

        For Each entity In entities
            Dim paddle = entity.GetComponent(Of PaddleComponent)("Paddle")
            Dim position = entity.GetComponent(Of PositionComponent)("Position")
            Dim velocity = entity.GetComponent(Of VelocityComponent)("Velocity")
            Dim collider = entity.GetComponent(Of ColliderComponent)("Collider")

            Select Case paddle.side
                Case PlayerSide.Left
                    If Keyboard.IsKeyPressed(Keyboard.Key.W) Then
                        velocity.vel.Y = -movingVelocity
                    ElseIf Keyboard.IsKeyPressed(Keyboard.Key.S) Then
                        velocity.vel.Y = movingVelocity
                    Else
                        velocity.vel.Y = 0
                    End If
                Case PlayerSide.Right
                    If Keyboard.IsKeyPressed(Keyboard.Key.Up) Then
                        velocity.vel.Y = -movingVelocity
                    ElseIf Keyboard.IsKeyPressed(Keyboard.Key.Down) Then
                        velocity.vel.Y = movingVelocity
                    Else
                        velocity.vel.Y = 0
                    End If
            End Select

            If position.pos.Y < 0 Then
                position.pos.Y = 0
                velocity.vel.Y = 0
            ElseIf position.pos.Y > windowHeight - collider.Rect.Height Then
                position.pos.Y = windowHeight - collider.Rect.Height
                velocity.vel.Y = 0
            End If
        Next
    End Sub
End Class
