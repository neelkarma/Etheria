Public MustInherit Class Scene
    Public MustOverride ReadOnly Property Type As String
    Private ReadOnly entities As New Dictionary(Of Long, Entity)
    Private ReadOnly systems As New List(Of System)

    Public Overridable Sub Open(Optional init As Boolean = True)
        If init Then
            entities.Clear()
            systems.Clear()
            InitEntities()
            InitSystems()
        End If
    End Sub

    ''' <summary>
    ''' Updates the scene, calling the update functions of all the systems contained within.
    ''' 
    ''' This sub is called once every frame.
    ''' </summary>
    Public Sub Update()
        For Each system In systems
            ' Calling GetSystemEntityMatches every frame for every system is very inefficient. Too bad!
            Dim matches = GetSystemEntityMatches(system)
            system.Update(matches)
        Next
    End Sub

    ''' <summary>
    ''' Adds an entity to the scene
    ''' </summary>
    ''' <param name="entity">The entity to add</param>
    Public Sub AddEntity(entity As Entity)
        entities(entity.id) = entity
    End Sub

    ''' <summary>
    ''' Adds an entity to the scene
    ''' </summary>
    ''' <param name="components">The components to add to the new entity</param>
    Public Sub AddEntity(ParamArray components() As Component)
        AddEntity(New Entity(components))
    End Sub

    ''' <summary>
    ''' Adds a system to the scene
    ''' </summary>
    ''' <param name="system">The system to add</param>
    Public Sub AddSystem(system As System)
        Dim matched = GetSystemEntityMatches(system)
        system.Init(matched)
        systems.Add(system)
    End Sub

    ''' <summary>
    ''' Gets the scene's matched entities for a given system
    ''' </summary>
    ''' <param name="system">The system to use</param>
    ''' <returns>A list of matched entities</returns>
    Private Function GetSystemEntityMatches(system As System) As IEnumerable(Of Entity)
        Return entities.Values.Where(Function(entity) system.Match(entity))
    End Function

    ''' <summary>
    ''' Initializes the systems in the scene.
    ''' </summary>
    Public Sub InitSystems()
        AddSystem(New PaddleControlSystem)

        AddSystem(New CollisionSystem)

        AddSystem(New VelocitySystem)
        AddSystem(New PaddleBounceSystem)
        AddSystem(New WallBounceSystem)

        AddSystem(New RectRenderSystem)
        AddSystem(New TextRenderSystem)
        AddSystem(New InteractableSystem)
        AddSystem(New ButtonActionSystem)
        AddSystem(New TextButtonSystem)
        AddSystem(New TextSizeSystem)
        AddSystem(New SpriteRenderSystem)
        AddSystem(New AnimationSystem)
        ' TODO: Add systems as they get developed
    End Sub

    ''' <summary>
    ''' Initializes the entities in the scene. In most cases, this should be overridden.
    ''' </summary>
    Public Overridable Sub InitEntities()

    End Sub
End Class
