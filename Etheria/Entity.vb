Public Class Entity
    Public ReadOnly id As Long = UIDGenerator.Generate()
    Private ReadOnly components As New Dictionary(Of String, Component)

    ''' <summary>
    ''' Creates a new entity with the given components.
    ''' </summary>
    ''' <param name="components">The components to add.</param>
    Public Sub New(ParamArray components() As Component)
        For Each component In components
            AddComponent(component)
        Next
    End Sub

    ''' <summary>
    ''' Adds a component to the current entity. If it already exists, it will be replaced.
    ''' </summary>
    ''' <param name="component">The component to add</param>
    Public Sub AddComponent(component As Component)
        components(component.Type) = component
    End Sub

    ''' <summary>
    ''' Adds multiple components to the current entity. If they already exist, they will be replaced.
    ''' </summary>
    ''' <param name="components">The components to add.</param>
    Public Sub AddComponents(ParamArray components As Component())
        For Each component In components
            AddComponent(component)
        Next
    End Sub

    ''' <summary>
    ''' Removes a component from the current entity.
    ''' </summary>
    ''' <param name="type">The type of component to remove.</param>
    ''' <returns>False if the component was not attached to the entity, True otherwise</returns>
    Public Function RemoveComponent(type As String) As Boolean
        Return components.Remove(type)
    End Function

    ''' <summary>
    ''' Gets a component from the current entity.
    ''' The only reason this function exists is for the type safety.
    ''' </summary>
    ''' <typeparam name="T">The component's type.</typeparam>
    ''' <param name="type">The type of component</param>
    ''' <returns>The component</returns>
    Public Function GetComponent(Of T As Component)(type As String) As T
        Return components(type)
    End Function

    ''' <summary>
    ''' Check if the entity has a given component type.
    ''' </summary>
    ''' <param name="type">The type of component to check for.</param>
    ''' <returns>True if the component is found on the entity, False otherwise.</returns>
    Public Function HasComponent(type As String) As Boolean
        Return components.ContainsKey(type)
    End Function

    ''' <summary>
    ''' Checks if the entity has all the given component types.
    ''' </summary>
    ''' <param name="types">The component types to check for</param>
    ''' <returns>True if all the components are found on the entity, False otherwise.</returns>
    Public Function HasComponents(ParamArray types() As String)
        Return types.All(Function(type) HasComponent(type))
    End Function
End Class
