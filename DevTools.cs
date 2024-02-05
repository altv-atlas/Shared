using System.Collections;
using AltV.Net.Client;
namespace AltV.Atlas.Shared;

/// <summary>
/// Some useful methods for developers
/// </summary>
public static class DevTools
{
    /// <summary>
    /// Logs every property with name and value for the given object
    /// </summary>
    /// <param name="obj">The object to logg</param>
    /// <typeparam name="T">The type of the object</typeparam>
    public static void LogProps<T>( T obj )
    {
#if DEBUG
        if( obj is null || obj is IEnumerable || obj is Array )
            return;

        foreach( var property in obj.GetType( ).GetProperties( ) )
        {
            Alt.Log( Convert.ToString( property.Name + " : " + property.GetValue( obj ) ) );
        }
#endif
    }
    
    /// <summary>
    /// Logs every field with name and value for the given object
    /// </summary>
    /// <param name="obj">The object to logg</param>
    /// <typeparam name="T">The type of the object</typeparam>
    public static void LogFields<T>( T obj )
    {
#if DEBUG
        if( obj is null || obj is IEnumerable || obj is Array )
            return;

        foreach( var property in obj.GetType( ).GetFields( ) )
        {
            Alt.Log( Convert.ToString( property.Name + " : " + property.GetValue( obj ) ) );
        }
#endif
    }
}