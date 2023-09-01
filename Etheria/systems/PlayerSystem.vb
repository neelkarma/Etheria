Imports SFML.Graphics
Imports SFML.System

Public Class PlayerSystem
    Inherits System
    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Paddle", "Position", "Velocity", "Collider")

    End Function



    Public Overrides Sub Init(entities As List(Of Entity))
        score = 0
    End Sub


    Public Overrides Sub Update(entities As List(Of Entity))
        For Each entity In entities
            Dim _playerComponent = entity.GetComponent(Of PlayerComponent)("Player")
            Dim _spriteComponent = entity.GetComponent(Of SpriteComponent)("Sprite")
            Dim _colliderComponent = entity.GetComponent(Of ColliderComponent)("Collider")
            Dim _transformComponent = entity.GetComponent(Of TransformComponent)("Transform")

            If _playerComponent.flashing Then
                _playerComponent.flashSubCycle += 1
                If _playerComponent.flashSubCycle >= _spriteComponent.frameSpeed Then
                    _playerComponent.flashSubCycle = 0
                    _playerComponent.flashCycle = 1


                    If _playerComponent.flashCycle >= 6 Then
                        _playerComponent.flashCycle = 0

                    End If

                    Dim tints As Integer(,) = {{255, 0, 0}, {255, 255, 0}, {0, 255, 0}, {0, 255, 255}, {0, 0, 255}, {255, 0, 255}}
                    _spriteComponent.colour = New Color(tints(_playerComponent.flashCycle, 0), tints(_playerComponent.flashCycle, 1), tints(_playerComponent.flashCycle, 2))

                End If

            Else
                _spriteComponent.colour = _playerComponent.spriteColour
            End If


            For Each f As Entity In _colliderComponent.collisions
                If f.HasComponent("EnemyProjectileComponent") Then

                End If
            Next

        Next

    End Sub



End Class

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
        ElseIf position.pos.Y > windowHeight - collider.rect.Height Then
            position.pos.Y = windowHeight - collider.rect.Height
            velocity.vel.Y = 0
        End If
    Next
End Sub
End Class
