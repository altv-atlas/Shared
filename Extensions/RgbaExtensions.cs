using System.Drawing;
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
    
    /// <summary>
    /// Tries to parse a string to a rgb color
    /// </summary>
    /// <param name="rgb">The rgb value</param>
    /// <param name="color">The color value</param>
    /// <returns>Returns if the parsing was successful</returns>
    public static bool TryParseRgb( this string rgb, out Color color )
    {
        color = Color.Empty;

        try
        {
            color = ColorTranslator.FromHtml( rgb );
            return true;
        }
        catch( Exception ex )
        {
            Console.WriteLine( $"Error parsing color string: {ex.Message}" );
            return false;
        }
    }
}