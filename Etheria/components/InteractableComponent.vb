Public Class InteractableComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Interactable"

    Public wasClicked = False
    Public isHeld = False
    Public isHovered = False
End Class
