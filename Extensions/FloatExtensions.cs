namespace AltV.Atlas.Shared.Extensions;

/// <summary>
/// A class that contains some useful methods for floats
/// </summary>
public static class FloatExtensions
{
    /// <summary>
    /// Converts degrees to radians
    /// </summary>
    /// <param name="degrees">the float value in degrees</param>
    /// <returns></returns>
    public static float ToRadian( this float degrees )
    {
        return ( degrees / 360 ) * MathF.PI;
    }
}