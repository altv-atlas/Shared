using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Text.Json;

namespace AltV.Atlas.Shared;

public static class EnumUtils
{
    public static T? ToObject<T>( this JsonElement element )
    {
        var json = element.GetRawText( );
        return JsonSerializer.Deserialize<T>( json );
    }

    public static T? ToObject<T>( this JsonDocument document )
    {
        var json = document.RootElement.GetRawText( );
        return JsonSerializer.Deserialize<T>( json );
    }

    public static T? RandomEnumValue<T>( )
    {
        var v = Enum.GetValues( typeof( T ) );
        return ( T ) v.GetValue( new Random( ).Next( v.Length ) );
    }

    public static T PickRandom<T>( this IEnumerable<T> source )
    {
        return source.PickRandom( 1 ).Single( );
    }

    public static IEnumerable<T> PickRandom<T>( this IEnumerable<T> source, int count )
    {
        return source.Shuffle( ).Take( count );
    }

    public static IEnumerable<T> Shuffle<T>( this IEnumerable<T> source )
    {
        return source.OrderBy( x => Guid.NewGuid( ) );
    }

    public static T PickRandomCumulativeInt<T>( this IEnumerable<T> source )
    {
        T res = default;

        var r = new Random( );
        var diceRoll = r.NextDouble( ) * 100;

        int cumulative = 0;

        foreach( dynamic type in source )
        {
            if( type == null )
            {
                continue;
            }

            cumulative += type.SpawnChance;

            if( diceRoll < cumulative )
            {
                res = type;
                break;
            }
        }

        return res;
    }

    public static T PickRandomCumulativeDouble<T>( this IEnumerable<T> source )
    {
        T res = default;

        var r = new Random( );
        var diceRoll = r.NextDouble( );

        double cumulative = 0;

        foreach( dynamic type in source )
        {
            if( type == null )
            {
                continue;
            }

            cumulative += type.SpawnChance / 100;

            if( diceRoll < cumulative )
            {
                res = type;
                break;
            }
        }

        return res;
    }

    public static IEnumerable<IEnumerable<T>> Batch<T>( this IEnumerable<T> items, int maxItems )
    {
        return items.Select( ( item, inx ) => new { item, inx } )
            .GroupBy( x => x.inx / maxItems )
            .Select( g => g.Select( x => x.item ) );
    }

    public static void AddRange<T>( this ConcurrentQueue<T> queue, IEnumerable<T> list )
    {
        foreach( var item in list )
        {
            queue.Enqueue( item );
        }
    }

    public static bool TryGetTypedValue<TKey, TValue, TActual>( this IDictionary<TKey, TValue> data, TKey key,
        out TActual value ) where TActual : TValue
    {
        TValue tmp;
        if( data.TryGetValue( key, out tmp ) )
        {
            value = ( TActual ) tmp;
            return true;
        }

        value = default;
        return false;
    }

    public static IEnumerable<(T item, int index)> WithIndex<T>( this IEnumerable<T> self )
    {
        return self.Select( ( item, index ) => ( item, index ) );
    }

    public static IQueryable<TSource> OrderBy<TSource>( this IQueryable<TSource> query, string key, bool ascending = true )
    {
        if( string.IsNullOrWhiteSpace( key ) )
        {
            return query;
        }

        var lambda = ( dynamic ) CreateExpression( typeof( TSource ), key );

        return ascending
            ? Queryable.OrderBy( query, lambda )
            : Queryable.OrderByDescending( query, lambda );
    }

    private static LambdaExpression CreateExpression( Type type, string propertyName )
    {
        var param = Expression.Parameter( type, "x" );

        var body = propertyName.Split( '.' ).Aggregate<string, Expression>( param, Expression.PropertyOrField );

        return Expression.Lambda( body, param );
    }

    public static IEnumerable<T> GetValues<T>( )
    {
        return Enum.GetValues( typeof( T ) ).Cast<T>( );
    }
}