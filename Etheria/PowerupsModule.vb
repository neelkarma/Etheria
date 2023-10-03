Imports System.Collections.Immutable
Imports SFML.Graphics

Public Module PowerupsModule
    Public Class PowerupInfo
        Public ReadOnly price As Integer
        Public ReadOnly spriteName As String
        Public ReadOnly title As String
        Public ReadOnly description As String

        Public ReadOnly Property Sprite As Sprite
            Get
                Return sprites.GetSprites(spriteName)(0)
            End Get
        End Property

        Public Sub New(title As String, spriteName As String, price As Integer, description As String)
            Me.title = title
            Me.spriteName = spriteName
            Me.price = price
            Me.description = description
        End Sub
    End Class

    Public Enum Powerup
        PermanentSpeedUp
        AutoShoot
        DoubleShot
        ExtraLife
    End Enum

    Public ReadOnly powerups As ImmutableArray(Of PowerupInfo) = ImmutableArray.Create(
        New PowerupInfo(
            "Perm. Speed Up",
            "speed-up",
            800,
            "Always enable speed up."
        ),
        New PowerupInfo(
            "Auto Shoot",
            "helpers",
            1000,
            "Automatically shoots for you."
        ),
        New PowerupInfo(
            "Double Shot",
            "double-shot",
            1200,
            "Doubles your fire rate."
        ),
        New PowerupInfo(
            "Extra Life",
            "extra-life",
            500,
            "(Immediate) Obtain an extra life."
        )
    )

End Module
