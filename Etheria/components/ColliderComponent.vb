Imports SFML.Graphics

Public Class ColliderComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Collider"

    ''' <summary>
    ''' Collider rectangle in local coordinates
    ''' </summary>
    Public rect As New FloatRect

    Public ReadOnly collisions As New List(Of Entity)

    Public Sub New()
    End Sub
    Public Sub New(rect As FloatRect)
        Me.rect = rect
    End Sub
End Class
