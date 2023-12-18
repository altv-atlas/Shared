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
    /// <param name="position"></param>
    /// <param name="position2"></param>
    /// <param name="speed"></param>
    /// <param name="lr"></param>
    /// <returns></returns>
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
    /// 
    /// </summary>
    /// <param name="camRot"></param>
    /// <returns></returns>
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
    /// <param name="camRot"></param>
    /// <returns></returns>
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