using System.Numerics;

namespace AltV.Atlas.Shared.Extensions;

/// <summary>
/// A class that contains some useful methods for vectors
/// </summary>
public static class VectorExtensions
{
    /// <summary>
    /// Convert a vector3 from degrees to radians
    /// </summary>
    /// <param name="degrees">The vector3 with values in degrees</param>
    /// <returns>A new vector3 with values in radians</returns>
    public static Vector3 ToRadian( this Vector3 degrees )
    {
        return new Vector3(
            degrees.X.ToRadian( ),
            degrees.Y.ToRadian( ),
            degrees.Z.ToRadian( )
        );
    }
}