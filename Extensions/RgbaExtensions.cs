using AltV.Net.Data;

namespace AltV.Atlas.Shared.Extensions;

/// <summary>
/// A class that contains some useful methods for Rgba
/// </summary>
public static class RgbaExtensions
{
    /// <summary>
    /// Return a instance of Rgba with random values
    /// </summary>
    /// <returns>Instance of rgba with random values</returns>
    public static Rgba Random( )
    {
        var rnd = new Random( );
        return new Rgba( ( byte ) rnd.Next( 0, 255 ), ( byte ) rnd.Next( 0, 255 ), ( byte ) rnd.Next( 0, 255 ), 255 );
    }
}