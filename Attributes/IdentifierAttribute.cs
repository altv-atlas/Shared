namespace AltV.Atlas.Shared.Attributes;

public class IdentifierAttribute : Attribute
{
    public string Identifier { get; private set; }

    public IdentifierAttribute( string identifier )
    {
        Identifier = identifier;
    }
}