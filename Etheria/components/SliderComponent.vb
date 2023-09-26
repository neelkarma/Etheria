
Imports SFML.System

Public Class SliderComponent
    Inherits Component
    Public Overrides ReadOnly Property Type As String = "Slider"

    Public leftX As Integer
    Public rightX As Integer
    Public action As Action(Of Decimal)
    Public dragging As Boolean = False
    Public offset As Integer = 0

    Public Sub New(leftX As Integer, rightX As Integer, action As Action(Of Decimal))
        Me.leftX = leftX
        Me.rightX = rightX
        Me.action = action
    End Sub
End Class
