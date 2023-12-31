﻿using System.Collections.Concurrent;
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

    /// <summary>
    /// Lets you iterate a collection with an index
    /// </summary>
    /// <param name="source">The collection</param>
    /// <typeparam name="T">Type of the item</typeparam>
    /// <returns>Returns indexed collection</returns>
    public static IEnumerable<(T item, int index)> WithIndex<T>( this IEnumerable<T> source )
    {
        return source.Select( ( item, index ) => ( item, index ) );
    }

    /// <summary>
    /// Checks if the collection is null or empty
    /// </summary>
    /// <param name="source">The collection to check</param>
    /// <typeparam name="T">The type of the collection</typeparam>
    /// <returns>If the collection is null or empty</returns>
    public static bool IsNullOrEmpty<T>( this IEnumerable<T>? source )
    {
        return source is null || !source.Any( );
    }
}