Public MustInherit Class System
    ''' <summary>
    ''' Determines which entities are handled by this system.
    ''' </summary>
    ''' <param name="entity">The entity to test</param>
    ''' <returns>A boolean indicating whether this system handles the entity or not</returns>
    Public MustOverride Function Match(entity As Entity) As Boolean

    ''' <summary>
    ''' This function is run when the system is first loaded.
    ''' </summary>
    ''' <param name="entities">The entities handled by this system</param>
    Public Overridable Sub Init(entities As IEnumerable(Of Entity))
    End Sub

    ''' <summary>
    ''' This function is run every frame.
    ''' </summary>
    ''' <param name="entities">The entities handled by this system</param>
    Public Overridable Sub Update(entities As IEnumerable(Of Entity))
    End Sub
End Class
