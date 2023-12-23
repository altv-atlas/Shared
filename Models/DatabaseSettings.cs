namespace AltV.Atlas.Shared.Models;

/// <summary>
/// Contains database settings such as connection string
/// </summary>
public class DatabaseSettings
{
    /// <summary>
    /// The key by which the data can be found in appsettings.json
    /// </summary>
    public const string Key = "Database";

    /// <summary>
    /// The connection string of your specific database
    /// </summary>
    public string ConnectionString { get; set; }
}