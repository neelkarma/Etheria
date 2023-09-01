Imports SFML.System

Public Class DraggableComponent
    Inherits Component
    Public Overrides ReadOnly Property Type As String = "Draggable"

    Public isDragging As Boolean = False
    Public sprite As String
    Public validDropTargets As Integer()
    Public positionOffset As New Vector2i
    Public initialPosition As New Vector2i

    Public Sub New(validDropTargets As Integer(), sprite As String)
        Me.validDropTargets = validDropTargets
        Me.sprite = sprite
    End Sub
End Class
