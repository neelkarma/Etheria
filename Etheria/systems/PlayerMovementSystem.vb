Imports SFML.Window

Public Class PlayerMovementSystem
    Inherits System

    Public Overrides Function Match(e As Entity) As Boolean
        Return e.HasComponents("Player", "Velocity")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim velocity = entity.GetComponent(Of VelocityComponent)("Velocity")
            Dim player = entity.GetComponent(Of PlayerComponent)("Player")

            Dim speed As Integer = PlayerComponent.speed

            Dim speedUp = Keyboard.IsKeyPressed(Keyboard.Key.LShift) Or session.equippedPowerup = Powerup.PermanentSpeedUp
            If speedUp Then
                speed *= 2
            End If

            Dim upPressed = Keyboard.IsKeyPressed(Keyboard.Key.W)
            Dim downPressed = Keyboard.IsKeyPressed(Keyboard.Key.S)

            If upPressed And Not downPressed Then
                velocity.vel.Y = -speed
            ElseIf downPressed And Not upPressed Then
                velocity.vel.Y = speed
            Else
                velocity.vel.Y = 0
            End If

            Dim leftPressed = Keyboard.IsKeyPressed(Keyboard.Key.A)
            Dim rightPressed = Keyboard.IsKeyPressed(Keyboard.Key.D)

            If leftPressed And Not rightPressed Then
                velocity.vel.X = -speed
            ElseIf rightPressed And Not leftPressed Then
                velocity.vel.X = speed
            Else
                velocity.vel.X = 0
            End If
        Next
    End Sub
End Class
