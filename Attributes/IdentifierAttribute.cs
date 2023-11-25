namespace AltV.Atlas.Shared.Attributes;

/// <summary>
/// Identifier attribute used in combination with the TypeConverter class
/// </summary>
public class IdentifierAttribute : Attribute
{
    /// <summary>
    /// The identifier value
    /// </summary>
    public string Identifier { get; private set; }

    /// <summary>
    /// Stores the identifier as string value to be used in TypeConverter when deserializing from JSON object
    /// Using a GUID is advised (pass Guid.ToString() to identifier)
    /// </summary>
    /// <param name="identifier">The identifier</param>
    public IdentifierAttribute( string identifier )
    {
        Identifier = identifier;
    }
}