Imports SFML.Graphics
Imports SFML.System
Imports SFML.Window

Public Class PlayerSystem
    Inherits System
    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Position", "Velocity", "Collider")

    End Function



    Public Overrides Sub Init(entities As IEnumerable(Of Entity))
        score = 0
    End Sub


    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
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
                    If Not _playerComponent.invulnerable Then
                        _playerComponent.lives -= 1
                        _playerComponent.inIFrame = True
                        _playerComponent.remainingIFrames = _playerComponent.IFrameLength
                        '_playerComponent.iFrameFlashCycle = 0

                    End If
                    'Dim bulletPos As TransformComponent = f.components("TransformComponent")
                    'Dim projectile As E

                End If
            Next


            If _playerComponent.inIFrame And _playerComponent.lives >= 0 Then
                _playerComponent.IFrameFlashCycle += 1
                If _playerComponent.IFrameFlashCycle >= 8 Then
                    _playerComponent.IFrameFlashCycle = 0
                    _spriteComponent.hidden = Not _spriteComponent.hidden
                End If
                _playerComponent.remainingIFrames -= 1

                If _playerComponent.IFrameFlashCycle <= 0 Then
                    _playerComponent.inIFrame = False
                    _spriteComponent.hidden = True


                End If
            End If
            If _playerComponent.lives < 0 And Not _playerComponent.dead Then 'kys
                _playerComponent.dead = True
                ' Dim debris particles etc
            ElseIf _playerComponent.lives >= 0 And _playerComponent.dead Then 'respawn
                _playerComponent.dead = False
                _spriteComponent.hidden = True
                _transformComponent.pos = New Vector2i(0, 294)
            End If
            If _playerComponent.dead Then
                _spriteComponent.hidden = False
            End If
        Next

    End Sub



End Class

Public Class Thing
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return False
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
            ElseIf position.pos.Y > windowHeight - collider.rect.Height Then
                position.pos.Y = windowHeight - collider.rect.Height
                velocity.vel.Y = 0
            End If
        Next
    End Sub
End Class
