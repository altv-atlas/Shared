using System.Text.Json;
using System.Text.Json.Serialization;

namespace AltV.Atlas.Shared.Converters;

public static class JsonOptions
{
    private static readonly List<JsonConverter> DefaultConverters = new();

    public static readonly JsonSerializerOptions Default;

    public static JsonSerializerOptions WithConverters(params JsonConverter[] converters)
    {
        var options = new JsonSerializerOptions
        {
            IncludeFields = true,
            IgnoreNullValues = true,
            PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };

        foreach (var converter in DefaultConverters)
            options.Converters.Add(converter);
        foreach (var converter in converters)
            options.Converters.Add(converter);

        return options;
    }

    static JsonOptions()
    {
        Default = WithConverters();
    }
}