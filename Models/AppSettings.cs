namespace AltV.Atlas.Shared.Models;

/// <summary>
/// Contains data which can be loaded from an appsettings.json file
/// </summary>
public class AppSettings
{
    /// <summary>
    /// Traffic settings which are used in the Peds.Traffic module
    /// </summary>
    public TrafficSettings TrafficSettings { get; set; }
}