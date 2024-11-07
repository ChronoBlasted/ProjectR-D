using System;
using System.Collections.Generic;
using System.Linq;

static class RandomExtension
{
    static readonly Random rnd = new();

    public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
    {
        source = source.OrderBy((item) => rnd.Next());
        return source;
    }
}