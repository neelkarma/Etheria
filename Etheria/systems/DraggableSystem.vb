Imports SFML.Window

Public Class DraggableSystem
    Inherits System

    Public Overrides Function Match(entity As Entity) As Boolean
        Return entity.HasComponents("Position", "Interactable", "Collider", "Draggable")
    End Function

    Public Overrides Sub Update(entities As IEnumerable(Of Entity))
        For Each entity In entities
            Dim interactable = entity.GetComponent(Of InteractableComponent)("Interactable")
            Dim position = entity.GetComponent(Of PositionComponent)("Position")
            Dim collider = entity.GetComponent(Of ColliderComponent)("Collider")
            Dim draggable = entity.GetComponent(Of DraggableComponent)("Draggable")
            Dim mousePos = Mouse.GetPosition(Window)

            If interactable.isHeld Then
                ' make the entity move with the cursor
                If Not mouseWasHeldLastFrame Then
                    draggable.positionOffset = mousePos - position.pos
                End If
                position.pos = mousePos + draggable.positionOffset
            End If

            If Not mouseWasHeldLastFrame Then
                Return
            End If

            ' check if mouse cursor is over a valid drop target
            Dim predicate = Function(ent As Entity) ent.HasComponent("DropTarget") And draggable.validDropTargets.Contains(ent.id)
            If collider.collisions.Any(predicate) Then
                Dim other = collider.collisions.Find(predicate)
                Dim dropTarget = other.GetComponent(Of DropTargetComponent)("DropTarget")
                dropTarget.activeSprite = draggable.sprite
            End If
            ' if so, set the drop sprite to the thing
            ' set entity position to draggable initial position

        Next
    End Sub
End Class
