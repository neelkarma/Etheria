Public Class InteractableComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Interactable"

    Public Shared holdIsLocked As Integer = -1
    Public wasClicked = False
    Public wasReleased = False
    Public isHeld = False
    Public isHovered = False
End Class
