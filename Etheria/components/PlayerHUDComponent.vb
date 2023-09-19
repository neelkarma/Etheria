Public Class PlayerHUDComponent
    Inherits Component

    Public Overrides ReadOnly Property Type As String = "PlayerHUDComponent"

    Public Enum HUDComponentValue
        Shinies
        Score
        Lives
    End Enum

    Public value As HUDComponentValue = HUDComponentValue.Lives
End Class
