using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace AltV.Atlas.Shared.Converters;

/// <summary>
/// Helper class for JsonSerializer options
/// </summary>
public static class JsonOptions
{
    private static readonly List<JsonConverter> DefaultConverters = new();

    /// <summary>
    /// Default serializer options
    /// </summary>
    public static readonly JsonSerializerOptions Default;

    /// <summary>
    /// Add a set of serializers to the current json options
    /// </summary>
    /// <param name="converters">The converters to add</param>
    /// <returns>JsonSerializerOptions with default settings and included converters</returns>
    public static JsonSerializerOptions WithConverters(params JsonConverter[] converters)
    {
        var options = new JsonSerializerOptions
        {
            IncludeFields = true,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip
        };

        foreach (var converter in DefaultConverters)
            options.Converters.Add(converter);
        foreach (var converter in converters)
            options.Converters.Add(converter);

        return options;
    }
    /// <summary>
    /// Add a type resolver to the current json options
    /// </summary>
    /// <param name="resolver">The resolver to add</param>
    /// <returns>JsonSerializerOptions with default settings and included resolver</returns>
    public static JsonSerializerOptions WithTypeResolver(IJsonTypeInfoResolver resolver)
    {
        var options = new JsonSerializerOptions
        {
            IncludeFields = true,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };

        foreach (var converter in DefaultConverters)
            options.Converters.Add(converter);
        
        options.TypeInfoResolver = resolver;

        return options;
    }

    static JsonOptions()
    {
        Default = WithConverters();
    }
}