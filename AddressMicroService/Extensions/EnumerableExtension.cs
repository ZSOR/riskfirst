using AddressMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressMicroService.Extensions
{
    public static class EnumerableExtension
    {
        //This is pretty over engineered and not really necisarry but I thought it was a neat way of doing the grouping
        public static Dictionary<string, IEnumerable<TSource>> GroupByFuzzyString<TSource, TKey>(this IEnumerable<TSource> enumerable, Func<TSource, TKey> expression , int score)
        {
            var result = new Dictionary<string, IEnumerable<TSource>>();

            var collection = enumerable.ToList();
            while (collection.Any())
            {
                var item = collection.First();
                var entries = new List<TSource>() { item };
                collection.Remove(item);

                for (int i = collection.Count-1; i >= 0; i--)
                {
                    var entry = collection.ElementAt(i);
                    if (expression.Invoke(entry).ToString().FuzzyCompare(expression.Invoke(item).ToString(), score))
                    {
                        entries.Add(entry);
                        collection.Remove(entry);
                        
                    }
                }
                result.Add(expression.Invoke(item).ToString(), entries);
            }

            return result;
        }
    }
}
