// AutoMapperMappingExtensions.cs
using AutoMapper;
using System.Collections.Generic;

namespace Lernkartei.Common.AutoMapper;

public static class AutoMapperMappingExtensions
{
    private static IMapper Mapper => AutoMapperConfig.Mapper;

    // Map object to new instance
    public static TDestination MapTo<TDestination>(this object source)
    {
        if (source == null) return default;
        return Mapper.Map<TDestination>(source);
    }

    // Map to existing destination (in-place)
    public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
    {
        if (source == null || destination == null) return destination;
        return Mapper.Map(source, destination);
    }

    // Map List<TSource> to List<TDestination>
    public static List<TDestination> MapToList<TDestination>(this IEnumerable<object> source)
    {
        if (source == null) return new List<TDestination>();
        return Mapper.Map<List<TDestination>>(source);
    }

    // Map IList<TSource> to IList<TDestination>
    public static IList<TDestination> MapToIList<TDestination>(this IEnumerable<object> source)
    {
        if (source == null) return new List<TDestination>();
        return Mapper.Map<IList<TDestination>>(source);
    }

    // Strongly-typed list mapping (preferred)
    public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
    {
        if (source == null) return new List<TDestination>();
        return Mapper.Map<List<TDestination>>(source);
    }
}