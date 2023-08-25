
Imports SFML.System

Public Class SliderComponent
    Inherits Component
    Public Overrides ReadOnly Property Type As String = "Slider"
    Public leftX As Integer
    Public rightX As Integer
    Public soundType As String
    Public dragging As Boolean
    Public offset As Vector2i
    Public hoverLast As Boolean
    Public wasMoved As Boolean
    Public labelId As Integer
    Public action As Action(Of Decimal)

    Public Sub New(_soundType As String, _leftX As Integer, _rightX As Integer, _action As Action(Of Decimal))
        soundType = _soundType
        leftX = _leftX
        rightX = _rightX

        offset = New Vector2i(0, 0)
        dragging = False
        hoverLast = False
        wasMoved = False
        action = _action
    End Sub




    '
    'Public value As Decimal
    'Public action As Action(Of Decimal)



    ' Public Sub New(action As Action(Of Decimal), Optional defaultValue As Decimal = 0.5)
    'Me.action = action
    'Me.value = defaultValue
    'End Sub
End Class
