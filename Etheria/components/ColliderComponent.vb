Imports System.Runtime.CompilerServices
Imports SFML.Graphics
Imports SFML.System

Public Class ColliderComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Collider"

    ''' <summary>
    ''' Collider rectangle in local coordinates
    ''' </summary>
    Public rect As New IntRect

    Public ReadOnly collisions As New List(Of Entity)

    Public Sub New()
    End Sub

    Public Sub New(rect As IntRect)
        Me.rect = rect
    End Sub
End Class
