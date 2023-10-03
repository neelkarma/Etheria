Imports SFML.System
Imports SFML.Window

Public Class DraggableSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Position", "Interactable", "Collider", "Draggable")
    End Function

    ' note to future self: DO NOT FUCKING REMOVE THIS YOU WILL REGRET IT
    Public Overrides Sub Init(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim position = entity.GetComponent(Of PositionComponent)("Position")
            Dim draggable = entity.GetComponent(Of DraggableComponent)("Draggable")

            draggable.initialPosition = position.pos
        Next
    End Sub

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim interactable = entity.GetComponent(Of InteractableComponent)("Interactable")
            Dim position = entity.GetComponent(Of PositionComponent)("Position")
            Dim collider = entity.GetComponent(Of ColliderComponent)("Collider")
            Dim draggable = entity.GetComponent(Of DraggableComponent)("Draggable")

            Dim mousePosI = Mouse.GetPosition(Window)
            Dim mousePos = New Vector2f(mousePosI.X, mousePosI.Y)

            If interactable.isHeld Then
                ' make the entity move with the cursor
                If Not mouseWasHeldLastFrame Then
                    draggable.positionOffset = mousePos - position.pos
                End If
                position.pos = mousePos - draggable.positionOffset
            End If

            If interactable.wasReleased Then
                ' check if mouse cursor is over a valid drop target
                Dim other = collider.collisions.Find(Function(ent As Entity) ent.HasComponents("DropTarget", "Sprite") And draggable.validDropTargets.Contains(ent.id))
                If Not IsNothing(other) Then
                    ' if so, set the drop sprite to the thing
                    Dim sprite = other.GetComponent(Of SpriteComponent)("Sprite")
                    sprite.name = draggable.sprite
                    session.shipSprite = draggable.sprite
                    If sprite.hidden Then
                        ' unhide the drop target sprite
                        sprite.hidden = False

                        If scenes.currentSceneName = "ShipSelect" Then
                            ' add the advance button
                            scenes.CurrentScene.AddEntity(
                                New TextButtonEntity("Advance", New Vector2f(570, 400), Sub()
                                                                                            session.level = 1
                                                                                            scenes.Open("Game")
                                                                                        End Sub)
                            )
                        End If
                    End If
                End If

                ' set entity position to draggable initial position
                position.pos = draggable.initialPosition
            End If
        Next
    End Sub
End Class
