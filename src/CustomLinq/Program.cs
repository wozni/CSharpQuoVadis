// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;


var days = new[] { "Monday", "Tuesday", "Wednesday" };
var daysWithE = from day in days
    where day.Contains("e")
    select day;

foreach (var d in daysWithE)
{
    Console.WriteLine(d);
}


namespace  MyLinqToString
{
    public static class MyConditions
    {
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

