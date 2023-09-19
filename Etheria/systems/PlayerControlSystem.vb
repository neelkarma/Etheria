Imports SFML.Window

Public Class PlayerControlSystem
    Inherits System

    Public Overrides Function Match(e As Entity) As Boolean ' get entities with PlayerControlComponent and TransformComponent
        Return e.HasComponents("Player", "Velocity")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim velocity = entity.GetComponent(Of VelocityComponent)("Velocity")
            Dim player = entity.GetComponent(Of PlayerComponent)("Player")

            Dim speed As Integer = player.speed
            Dim upPressed = Keyboard.IsKeyPressed(Keyboard.Key.Up)
            Dim downPressed = Keyboard.IsKeyPressed(Keyboard.Key.Down)

            If upPressed And Not downPressed Then
                velocity.vel.Y = -speed
            ElseIf downPressed And Not upPressed Then
                velocity.vel.Y = speed
            Else
                velocity.vel.Y = 0
            End If

            Dim leftPressed = Keyboard.IsKeyPressed(Keyboard.Key.Left)
            Dim rightPressed = Keyboard.IsKeyPressed(Keyboard.Key.Right)

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
