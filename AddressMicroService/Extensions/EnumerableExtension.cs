using AddressMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressMicroService.Extensions
{
    public static class EnumerableExtension
    {
        //This is pretty over engineered and not really necisarry but I thought it was a neat way of doing the grouping
        public static Dictionary<string, IEnumerable<TSource>> GroupByFuzzyString<TSource, TKey>(this ICollection<TSource> collection, Func<TSource, TKey> expression , int score)
        {
            var result = new Dictionary<string, IEnumerable<TSource>>();


            while (collection.Any())
            {
                var item = collection.First();
                var entries = new List<TSource>();
                collection.Remove(item);
                foreach(var x in collection)
                {
                    if (expression.Invoke(x).ToString().FuzzyCompare(expression.Invoke(item).ToString(), score))
                    {
                        entries.Add(x);
                    }
                }
                result.Add(expression.Invoke(item).ToString(), entries);
            }

            return result;
        }
    }
}
