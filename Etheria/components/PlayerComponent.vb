Public Class PlayerComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "Player"
    Public lives As Integer
    Public score As Integer
    Public inIFrame As Boolean ' Stores if this player is in I-Frames
    Public IFrameLength As Integer
    Public remainingIFrames As Integer
    Public IFrameFlashCycle As Integer
    Public flashing As Boolean ' Stores state of flashing effect for powerups
    Public flashCycle As Integer = 0
    Public flashSubCycle As Integer = 0
    Public colour As String
    Public spriteColour As SFML.Graphics.Color
    Public heldAbility As String
    Public invulnerable As Boolean
    Public dead As Boolean

    Public Sub New(Optional ByVal c As String = "Pink")

        lives = 3
        score = 0
        colour = c
        spriteColour = New SFML.Graphics.Color(255, 255, 255)
        flashing = False
        flashCycle = 0
        flashSubCycle = 0
        inIFrame = False
        remainingIFrames = 0
        IFrameFlashCycle = 0
        IFrameLength = 64
        heldAbility = ""
        invulnerable = False
        dead = False
    End Sub
End Class
