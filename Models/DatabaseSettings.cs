namespace AltV.Atlas.Shared.Models;

/// <summary>
/// Contains database settings such as connection string
/// </summary>
public class DatabaseSettings
{
    public const string Key = "Database";

    public string ConnectionString { get; set; }
}