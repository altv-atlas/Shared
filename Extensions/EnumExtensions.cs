using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Text.Json;

namespace AltV.Atlas.Shared.Extensions;

/// <summary>
/// A class that contains some useful methods for enums
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Returns a random value from an enum
    /// </summary>
    /// <param name="source">The enum to take it from</param>
    /// <typeparam name="T">Type of enum</typeparam>
    /// <returns>A random value from the enum</returns>
    public static T PickRandom<T>( this IEnumerable<T> source )
    {
        return source.PickRandom( 1 ).Single( );
    }

    /// <summary>
    /// Returns a random amount of values from an enum
    /// </summary>
    /// <param name="source">The enum to take it from</param>
    /// <param name="count">The amount to return</param>
    /// <typeparam name="T">Type of enum</typeparam>
    /// <returns>A collection of enum values</returns>
    public static IEnumerable<T> PickRandom<T>( this IEnumerable<T> source, int count )
    {
        return source.Shuffle( ).Take( count );
    }

    /// <summary>
    /// Shuffle a collection
    /// </summary>
    /// <param name="source">The collection to shuffle</param>
    /// <typeparam name="T">Type of collection</typeparam>
    /// <returns>Shuffled collection</returns>
    public static IEnumerable<T> Shuffle<T>( this IEnumerable<T> source )
    {
        return source.OrderBy( x => Guid.NewGuid( ) );
    }
}