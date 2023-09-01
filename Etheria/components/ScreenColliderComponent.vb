Imports SFML.System

Public Class ScreenColliderComponent
    Inherits Component
    ' Makes an entity stay on-screen or remove itself when offscreen.
    ' Defines its own rectangle because hitboxes might not always line up with the sprites
    Public Overrides ReadOnly Property Type As String = "ScreenCollider"
    Public action As String ' Either "collide" or "remove"
    Public pos1 As Vector2i
    Public pos2 As Vector2i

    Public Sub New() ' Blank constructor, probably don't use this
        action = "collide"
    End Sub

    Public Sub New(action As String)
        ' t must be "collide" or "remove"
        Me.action = action
        pos1 = New Vector2i()
        pos2 = New Vector2i()
    End Sub

    Public Sub New(action As String, x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer)
        ' t must be "collide", "remove" or "removeLeft"
        Me.action = action
        pos1 = New Vector2i(x1, y1)
        pos2 = New Vector2i(x2, y2)
    End Sub
End Class