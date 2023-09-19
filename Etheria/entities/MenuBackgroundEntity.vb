Imports SFML.System

Public Class MenuBackgroundEntity
    Inherits Entity

    Public Sub New()
        AddComponents(
            New PositionComponent(),
            New SpriteComponent("menu-bg", , 1.2)
        )
    End Sub

End Class
