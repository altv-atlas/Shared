using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AltV.Atlas.Shared.Converters;

/// <summary>
/// Converts JSON to a given type and vice versa
/// Thanks zziger <3
/// </summary>
/// <typeparam name="T">The type to convert</typeparam>
public class JsonTypeConverter<T> : JsonConverter<T>
{
    private readonly IEnumerable<Type> _types;

    /// <summary>
    /// Creates a new instance of this class
    /// </summary>
    public JsonTypeConverter()
    {
        var type = typeof(T);
        _types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => type.IsAssignableFrom(p) && p is { IsClass: true, IsAbstract: false })
            .ToList();
    }
    
    /// <summary>
    /// Reads JSON and converts it to the target object
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="typeToConvert"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <exception cref="JsonException"></exception>
    public override T Read( ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options )
    {
        if( reader.TokenType != JsonTokenType.StartObject )
        {
            throw new JsonException( "Invalid discriminator token type" );
        }

        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        if (!jsonDocument.RootElement.TryGetProperty("__t", out var propertyName))
        {
            throw new JsonException("Can't find discriminator value");
        }

        var type = _types.FirstOrDefault(x => x.Name == propertyName.GetString());
        if (type == null)
        {
            throw new JsonException("Unknown discriminator value");
        }
        
        var jsonObject = jsonDocument.RootElement.GetRawText( );
        var result = ( T ) JsonSerializer.Deserialize( jsonObject, type, options )!;

        return result;
    }

    /// <summary>
    /// Writes an object to JSON and appends type discriminator
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    public override void Write( Utf8JsonWriter writer, T value, JsonSerializerOptions options )
    {
        var str = JsonSerializer.Serialize( (object)value, options );
        
        Console.WriteLine( $"str: {str} " );
        
        if( str.Length > 2 )
            writer.WriteRawValue( str[ ..^1 ], true );
        else
            writer.WriteStartObject( );

        writer.WriteString( "__t", value.GetType( ).Name );
        writer.WriteEndObject( );
    }
}