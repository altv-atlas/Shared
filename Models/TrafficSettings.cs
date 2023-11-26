namespace AltV.Atlas.Shared.Models;

public class TrafficSettings
{
    public const string Key = "TrafficSettings";
    
    public uint MaxTrafficVehiclesInStreamDistance { get; set; } = 30;
    public uint MinimumTrafficNodesToGenerate { get; set; } = 10;
    public uint MaxSpeedForAngle { get; set; } = 40;
    public uint MaxAngleDeg { get; set; }= 360;
    public uint MinAngleDeg { get; set; } = 50;
    public uint SpawnRadius { get; set; } = 160;
    public uint MinimumSpawnDistanceFromPlayer { get; set; } = 160;
    public uint Density { get; set; } = 25;
    public int CleanupIntervalMs { get; set; } = 60_000;
    public uint TrafficSpawnIntervalMs { get; set; } = 1000;
}