﻿Imports SFML.Graphics
Imports SFML.System

Public Class ShopScene
    Inherits Scene

    Public Overrides ReadOnly Property Type As String = "Shop"

    Public Overrides Sub Open(Optional init As Boolean = True)
        MyBase.Open(init)
        audio.PlayBGM("menu")
    End Sub

    Public Overrides Sub InitEntities()
        ' title
        AddEntity(
            New TextComponent("Shop",, 24),
            New PositionComponent(New Vector2f(20, 20))
        )

        ' Balance
        AddEntity(
            New TextComponent("",, 24),
            New ReactiveTextComponent(Function() $"Balance: {session.shinies} SHN"),
            New PositionComponent(New Vector2f(350, 20))
        )

        ' items
        For Each item In Enumerate(powerups)
            Dim i = item.Item1
            Dim pow = item.Item2

            Dim top = 80 + i * 110

            ' powerup sprite
            AddEntity(
                New SpriteComponent(pow.spriteName,, 0.2),
                New PositionComponent(New Vector2f(50, top))
            )

            ' powerup name
            AddEntity(
                New TextComponent(pow.title,, 24),
                New PositionComponent(New Vector2f(150, top))
            )

            ' price
            AddEntity(
                New TextComponent($"",, 20),
                New ShopPriceComponent(i),
                New PositionComponent(New Vector2f(150, top + 30))
            )

            ' description
            AddEntity(
                New TextComponent(pow.description,, 16),
                New PositionComponent(New Vector2f(150, top + 55))
            )

            ' button rect
            Const width = 700
            Const height = 100

            AddEntity(
                New ColliderComponent(New FloatRect(0, 0, width, height)),
                New InteractableComponent(),
                New RectComponent(New FloatRect(0, 0, width, height), Color.Transparent, Color.White, 3),
                New ShopItemButtonComponent(),
                New PositionComponent(New Vector2f(40, top - 10)),
                New ButtonComponent(Sub()
                                        If i = Powerup.ExtraLife Then
                                            If pow.price > session.shinies Or session.lives >= 5 Then
                                                ' todo: play error sfx
                                                Return
                                            End If
                                            session.shinies -= pow.price
                                            session.lives += 1
                                            Return
                                        End If

                                        If session.equippedPowerup = i Then Return

                                        If session.boughtPowerUps.Contains(i) Then
                                            session.equippedPowerup = i
                                            Return
                                        End If

                                        If pow.price > session.shinies Then
                                            ' todo: play error sfx
                                            Return
                                        End If

                                        session.shinies -= pow.price
                                        session.boughtPowerUps.Add(i)
                                        session.equippedPowerup = i
                                    End Sub)
            )

        Next

        ' player stats (ship icon, score, shinies, lives)
        AddEntity(
            New TextComponent($"Score: {session.score}",, 18),
            New PositionComponent(New Vector2f(50, 560))
        )

        AddEntity(
            New TextComponent("",, 18),
            New ReactiveTextComponent(Function() $"Lives: {session.lives}"),
            New PositionComponent(New Vector2f(400, 560))
        )

        ' advance button
        AddEntity(
            New TextButtonEntity("Advance", New Vector2f(580, 550), Sub()
                                                                        session.level += 1
                                                                        scenes.Open("Game")
                                                                    End Sub)
        )
    End Sub
End Class
