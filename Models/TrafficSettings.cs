namespace AltV.Atlas.Shared.Models;

/// <summary>
/// Contains mutable data for Peds.Traffic module
/// </summary>
public class TrafficSettings
{
    /// <summary>
    /// The key by which the data can be found in appsettings.json
    /// </summary>
    public const string Key = "TrafficSettings";
    
    /// <summary>
    /// Maximum amount of PED vehicles that can be within stream distance of a player
    /// </summary>
    public uint MaxTrafficVehiclesInStreamDistance { get; set; } = 30;
    
    /// <summary>
    /// Minimum amount of nodes it should generate near the player to spawn a vehicle at
    /// </summary>
    public uint MinimumTrafficNodesToGenerate { get; set; } = 10;
    
    /// <summary>
    /// Radius around the player at which a vehicle can spawn
    /// </summary>
    public uint SpawnRadius { get; set; } = 160;
    
    /// <summary>
    /// Minimum distance from the player before a position is considered valid for a ped to spawn at
    /// </summary>
    public uint MinimumSpawnDistanceFromPlayer { get; set; } = 80;
    
    /// <summary>
    /// The server does a cleanup of invalid peds/vehicles every X milliseconds. This can be adjusted with this value
    /// </summary>
    public int CleanupIntervalMs { get; set; } = 60_000;
    
    /// <summary>
    /// The interval at which valid locations for traffic peds are calculated. If you see vehicles spawning on top of eachother, try increasing this value
    /// </summary>
    public uint TrafficSpawnIntervalMs { get; set; } = 1000;
}