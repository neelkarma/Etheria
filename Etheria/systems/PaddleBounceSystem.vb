Public Class PaddleBounceSystem
    Inherits System

    Private hasBouncedLastFrame As Boolean = False

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Ball", "Collider", "Velocity")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim collider = entity.GetComponent(Of ColliderComponent)("Collider")
            Dim velocity = entity.GetComponent(Of VelocityComponent)("Velocity")

            Dim paddleEntity = collider.collisions.Find(Function(other) other.HasComponent("Paddle"))

            If paddleEntity Is Nothing Then
                hasBouncedLastFrame = False
                Return
            End If

            Dim paddle = paddleEntity.GetComponent(Of PaddleComponent)("Paddle")

            If Not hasBouncedLastFrame Then
                audio.PlaySFX("ui-select")
                hasBouncedLastFrame = True
            End If

            winning = paddle.side

            Select Case paddle.side
                Case PlayerSide.Left
                    velocity.vel.X = Math.Abs(velocity.vel.X)
                Case PlayerSide.Right
                    velocity.vel.X = -Math.Abs(velocity.vel.X)
            End Select
        Next
    End Sub
End Class
