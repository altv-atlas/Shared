using AltV.Net.Data;
namespace AltV.Atlas.Shared.Extensions;

/// <summary>
/// A class that contains some useful methods for positions
/// </summary>
public static class PositionExtensions
{
    /// <summary>
    /// Adds a speed value to the given position
    /// </summary>
    /// <param name="position">The given position</param>
    /// <param name="position2">The position to add with speed</param>
    /// <param name="speed">The speed value to add</param>
    /// <param name="lr">Is it left/right</param>
    /// <returns>The new position with the added speed</returns>
    public static Position AddSpeedToPosition( this Position position, Position position2, float speed, bool lr = false )
    {
        return new Position
        {
            X = position.X + position2.X * speed,
            Y = position.Y + position2.Y * speed,
            Z = lr ? position.Z : position.Z + position2.Z * speed
        };
    }

    /// <summary>
    /// Gets the cameras right position
    /// </summary>
    /// <param name="camRot">The cams rotation value</param>
    /// <returns>Cameras right position</returns>
    public static Position CamPositionRight( this Position camRot )
    {
        return new Position
        {
            X = ( float ) Math.Cos( camRot.Z * ( Math.PI / 180 ) ),
            Y = ( float ) Math.Sin( camRot.Z * ( Math.PI / 180 ) ),
            Z = ( float ) Math.Sin( camRot.X * ( Math.PI / 180 ) )
        };
    }


    /// <summary>
    /// Gets the cameras forward position
    /// </summary>
    /// <param name="camRot">The cams rotation value</param>
    /// <returns>Cameras forward position</returns>
    public static Position CamPositionForward( this Position camRot )
    {
        return new Position
        {
            X = ( float ) Math.Cos( camRot.Z * ( Math.PI / 180 ) + Math.PI / 2 ),
            Y = ( float ) Math.Sin( camRot.Z * ( Math.PI / 180 ) + Math.PI / 2 ),
            Z = ( float ) Math.Sin( camRot.X * ( Math.PI / 180 ) )
        };
    }

}