using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace AltV.Atlas.Shared.Converters;

public class JsonTypeResolver<T> : DefaultJsonTypeInfoResolver
{
    public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
    {
        JsonTypeInfo jsonTypeInfo = base.GetTypeInfo(type, options);

        Type baseType = typeof(T);
        if (jsonTypeInfo.Type == baseType)
        {
            jsonTypeInfo.PolymorphismOptions = new JsonPolymorphismOptions
            {
                TypeDiscriminatorPropertyName = "$type"
            };

            foreach (var derivedType in GetTypes())
            {
                jsonTypeInfo.PolymorphismOptions.DerivedTypes.Add(derivedType);
            }
        }
        
        return jsonTypeInfo;
    }

    private IEnumerable<JsonDerivedType> GetTypes()
    {
        var type = typeof(T);
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        IEnumerable<Type> types;
        
        try
        {
            types = assemblies.SelectMany(assembly => assembly.GetTypes());
        }
        catch (ReflectionTypeLoadException e)
        {
            types = assemblies.SelectMany(assembly => 
                assembly.DefinedTypes
                    .Where( x => x != null )
            );
        }
        
        types = types.Where(p => type.IsAssignableFrom(p) && p is { IsClass: true, IsAbstract: false })
            .ToList();

        return types.Select( x => new JsonDerivedType(x, x.Name));
    }
}