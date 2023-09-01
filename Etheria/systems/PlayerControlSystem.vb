Imports SFML.Window

Public Class PlayerControlSystem
    Inherits System


    Public Overrides Function Match(e As Entity) As Boolean ' get entities with PlayerControlComponent and TransformComponent
        Return e.HasComponents("PlayerControl", "Transform")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each e In entities
            Dim _PlayerControlComponent = e.GetComponent(Of PlayerControlComponent)("PlayerControlComponent")
            Dim _TransformComponent = e.GetComponent(Of TransformComponent)("TransformComponent")

            Dim speed As Integer = _PlayerControlComponent.speed

            If Keyboard.IsKeyPressed(_PlayerControlComponent.upKey) And Not Keyboard.IsKeyPressed(_PlayerControlComponent.downKey) Then
                _TransformComponent.vel.Y = -speed
            ElseIf Keyboard.IsKeyPressed(_PlayerControlComponent.downKey) And Not Keyboard.IsKeyPressed(_PlayerControlComponent.upKey) Then
                _TransformComponent.vel.Y = speed
            Else
                _TransformComponent.vel.Y = 0
            End If

            If Keyboard.IsKeyPressed(_PlayerControlComponent.leftKey) And Not Keyboard.IsKeyPressed(_PlayerControlComponent.rightKey) Then
                _TransformComponent.vel.X = -speed
            ElseIf Keyboard.IsKeyPressed(_PlayerControlComponent.rightKey) And Not Keyboard.IsKeyPressed(_PlayerControlComponent.leftKey) Then
                _TransformComponent.vel.X = speed
            Else
                _TransformComponent.vel.X = 0
            End If
        Next
    End Sub
End Class
