using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using AltV.Atlas.Shared.Attributes;

namespace AltV.Atlas.Shared.Converters;

/// <summary>
/// Class uses to convert a given type on server-side to the same type on client-side.
/// Both sides will require a shared identifier (see eg AltV.Atlas.Peds.Shared.PedTasks)
/// </summary>
public static class TypeConverter
{
    /// <summary>
    /// Set of options to use when serializing/deserializing JSON objects
    /// </summary>
    public static readonly JsonSerializerOptions JsonSerializerOptions = new( )
    {
        PropertyNameCaseInsensitive = true,
        IncludeFields = true,
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };
    /// <summary>
    /// Convert an object from JSON back to an instance of a class
    /// </summary>
    /// <param name="json">The json to convert</param>
    /// <param name="identifierKey">The property that holds the identifier, eg "Id"</param>
    /// <typeparam name="TInterface">The interface that the target class inherits from</typeparam>
    /// <example>PedTaskIdle idleTask = TypeConverter.FromJson(jsonValue, "Id");</example>
    /// <returns>An instance of the target class or null if it failed to do so</returns>
    public static TInterface? FromJson<TInterface>( string? json, string identifierKey )
    {
        if( json is null )
            return default;
        
        var type = typeof( TInterface );
        
        var types = AppDomain.CurrentDomain.GetAssemblies( )
            .SelectMany( s => s.GetTypes( ) )
            .Where( p => type.IsAssignableFrom( p ) && p is { IsClass: true, IsAbstract: false } );

        foreach( var t in types )
        {
            var data = JsonSerializer.Deserialize(json, t, JsonSerializerOptions);

            if( data is null )
                continue;

            var prop = t.GetProperty( identifierKey );
            var attribute = prop?.GetCustomAttribute<IdentifierAttribute>( );
            var jsonIdentifierValue = prop?.GetValue( data );

            if( attribute is null || jsonIdentifierValue is not Guid identifier )
                continue;

            if( Guid.Parse( attribute.Identifier ) == identifier )
                return ( TInterface? ) data;
        }

        return default;
    }

    /// <summary>
    /// Convert an object to JSON
    /// </summary>
    /// <param name="type">The type of object</param>
    /// <typeparam name="T">The object itself</typeparam>
    /// <returns>String containing the object in JSON format</returns>
    public static string ToJson<T>( T type ) where T : class
    {
        return JsonSerializer.Serialize( type, type.GetType( ), JsonSerializerOptions );
    }
}