Public MustInherit Class Scene
    Public MustOverride ReadOnly Property Type As String
    Private ReadOnly entities As New Dictionary(Of Long, Entity)
    Private ReadOnly systems As New List(Of System)
    Public cursorEnabled As Boolean = True

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
        If scenes.CurrentScene IsNot Me Then Return

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
    ''' <returns>The entity</returns>
    Public Function AddEntity(entity As Entity) As Entity
        entities(entity.id) = entity
        Return entity
    End Function

    ''' <summary>
    ''' Adds an entity to the scene
    ''' </summary>
    ''' <param name="components">The components to add to the new entity</param>
    ''' <returns>The entity created.</returns>
    Public Function AddEntity(ParamArray components() As Component) As Entity
        Return AddEntity(New Entity(components))
    End Function

    ''' <summary>
    ''' Removes the entity with the given id from the scene.
    ''' </summary>
    ''' <param name="id">The id of the entity to remove.</param>
    Public Sub RemoveEntity(id As Long)
        entities.Remove(id)
    End Sub

    ''' <summary>
    ''' Removes an entity from the scene.
    ''' </summary>
    ''' <param name="entity">The entity to remove.</param>
    Public Sub RemoveEntity(entity As Entity)
        RemoveEntity(entity.id)
    End Sub

    ''' <summary>
    ''' Gets an <see cref="Entity"/> from the scene, given it's id.
    ''' 
    ''' Note: This just directly indexes the dictionary, meaning the game will crash if the ID doesn't exist! Use <see cref= "HasEntityWithId(Long)"/> first.
    ''' </summary>
    ''' <param name="id">The id of the entity to get.</param>
    ''' <returns>The entity with the matching ID.</returns>
    Public Function GetEntityById(id As Integer) As Entity
        Return entities(id)
    End Function

    ''' <summary>
    ''' Checks if an entity with the given id exists in the scene.
    ''' </summary>
    ''' <param name="id">The id of the entity to be checked.</param>
    ''' <returns>If the entity exists in the scene or not.</returns>
    Public Function HasEntityWithId(id As Long) As Boolean
        Return entities.ContainsKey(id)
    End Function

    ''' <summary>
    ''' Checks if an entity exists in the scene, given a predicate function.
    ''' </summary>
    ''' <param name="predicate">The predicate function - an entity is passed to it, and it returns true if it's a match or false if not.</param>
    ''' <returns>If any of the entities in the system passed the predicate.</returns>
    Public Function HasEntity(predicate As Func(Of Entity, Boolean)) As Boolean
        Return entities.Any(Function(pair) predicate(pair.Value))
    End Function

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
        AddSystem(New CollisionSystem)
        AddSystem(New VelocitySystem)
        AddSystem(New SpriteColliderSystem)
        AddSystem(New TextColliderSystem)

        AddSystem(New InteractableSystem)
        AddSystem(New DraggableSystem)
        AddSystem(New TextButtonSystem)
        AddSystem(New ButtonActionSystem)

        AddSystem(New SpriteRenderSystem)
        AddSystem(New RectRenderSystem)
        AddSystem(New SliderSystem)
        AddSystem(New TextRenderSystem)
        AddSystem(New InitialInputSystem)

        AddSystem(New AnimationSystem)

        AddSystem(New MouseCoordsSystem)
        AddSystem(New DebugSystem)
        AddSystem(New ColliderDebugSystem)
        AddSystem(New InteractableDebugSystem)
        ' TODO: Add systems as they get developed
    End Sub

    ''' <summary>
    ''' Initializes the entities in the scene. In most cases, this should be overridden.
    ''' </summary>
    Public Overridable Sub InitEntities()

    End Sub
End Class
