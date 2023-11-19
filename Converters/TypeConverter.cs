using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using AltV.Atlas.Shared.Attributes;

namespace AltV.Atlas.Shared.Converters;

public static class TypeConverter
{
    public static JsonSerializerOptions JsonSerializerOptions = new( )
    {
        PropertyNameCaseInsensitive = true,
        IncludeFields = true,
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };
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

    public static string ToJson<T>( T type ) where T : class
    {
        return JsonSerializer.Serialize( type, type.GetType( ), JsonSerializerOptions );
    }
}