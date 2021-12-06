// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using MyLinqToString;

var days = new[] { "Monday", "Tuesday", "Wednesday" };
var daysWithE = from day in days
    where day.Contains("a")
    select new { day, num = days.Length };

foreach (var d in daysWithE)
{
    Console.WriteLine(d);
}




namespace  MyLinqToString
{
    public static class MyConditions
    {
        public static IEnumerable<TResult> Select<TOriginal, TResult>(this IEnumerable<TOriginal> original, Func<TOriginal, TResult> selector)
        {
            return System.Linq.Enumerable.Empty<TResult>();
        }
        public static IEnumerable<string> Where(this IEnumerable<string> items, Func<string, bool> predicate)
        {
            foreach (var item in items)
            {
                Console.WriteLine($"Testing {item}...");
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}

