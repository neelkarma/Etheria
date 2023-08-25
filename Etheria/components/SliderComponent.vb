
Imports SFML.System

Public Class SliderComponent
    Inherits Component
    Public Overrides ReadOnly Property Type As String = "Slider"
    Public leftX As Integer
    Public rightX As Integer
    Public y As Integer
    Public soundType As String
    Public dragging As Boolean
    Public offset As Vector2i
    Public hoverLast As Boolean
    Public lastX As Integer
    Public wasMoved As Boolean
    Public moveSpeed As Integer
    Public labelId As Integer

    Public Sub New(_soundType As String, _x As Integer, _y As Integer, _leftX As Integer, _rightX As Integer)


        soundType = _soundType
        leftX = _leftX
        rightX = _rightX
        y = _y

        offset = New Vector2i(0, 0)
        dragging = False
        hoverLast = False
        wasMoved = False
        moveSpeed = 2
        lastX = _x
    End Sub




    '
    'Public value As Decimal
    'Public action As Action(Of Decimal)



    ' Public Sub New(action As Action(Of Decimal), Optional defaultValue As Decimal = 0.5)
    'Me.action = action
    'Me.value = defaultValue
    'End Sub
End Class
