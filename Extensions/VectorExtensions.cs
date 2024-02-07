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
  
    /// <summary>
    /// Adds a speed value to the given vector3
    /// </summary>
    /// <param name="vector3">The given vector3</param>
    /// <param name="secondVector3">The vector3 to add with speed</param>
    /// <param name="speed">The speed value to add</param>
    /// <param name="lr">Is it left/right</param>
    /// <returns>The new vector3 with the added speed</returns>
    public static Vector3 AddSpeedToVector( this Vector3 vector3, Vector3 secondVector3, float speed, bool lr = false )
    {
        return new Vector3
        {
            X = vector3.X + secondVector3.X * speed,
            Y = vector3.Y + secondVector3.Y * speed,
            Z = lr ? vector3.Z : vector3.Z + secondVector3.Z * speed
        };
    }

    /// <summary>
    /// Gets the cameras right vector3
    /// </summary>
    /// <param name="camVector3">The cams vector3 value</param>
    /// <returns>Cameras right vector3</returns>
    public static Vector3 CamVectorRight( this Vector3 camVector3 )
    {
        return new Vector3
        {
            X = MathF.Cos( camVector3.Z * ( MathF.PI / 180 ) ),
            Y = MathF.Sin( camVector3.Z * ( MathF.PI / 180 ) ),
            Z = MathF.Sin( camVector3.X * ( MathF.PI / 180 ) )
        };
    }


    /// <summary>
    /// Gets the cameras forward vector3
    /// </summary>
    /// <param name="camVector3">The cams vector3 value</param>
    /// <returns>Cameras forward vector3</returns>
    public static Vector3 CamVectorForward( this Vector3 camVector3 )
    {
        return new Vector3
        {
            X = MathF.Cos( camVector3.Z * ( MathF.PI / 180 ) + MathF.PI / 2 ),
            Y = MathF.Sin( camVector3.Z * ( MathF.PI / 180 ) + MathF.PI / 2 ),
            Z = MathF.Sin( camVector3.X * ( MathF.PI / 180 ) )
        };
    }

    /// <summary>
    /// Converts the rotation angles into a vector
    /// </summary>
    /// <param name="rotation">The rotation in angles to convert</param>
    /// <returns>The vector</returns>
    public static Vector3 RotAnglesToVector( this Vector3 rotation )
    {
        var z = rotation.Z.DegreesToRadians( );
        var x = rotation.X.DegreesToRadians( );
        var num = MathF.Abs( MathF.Cos( x ) );

        return new Vector3( -( MathF.Sin( z ) * num ), MathF.Cos( z ) * num, MathF.Sin( x ) );
    }
}