using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class FromFirstToTwelfth
    {
        public static void App()
        {

            var numbers = new List<int>() { 1, 2, 3, 100, 6, 22, 36, 893, 13, 104, 33, 1, 3, -10, 22, 22, 36, 13, 1, 2 };
            var str = "Abilities forfeited situation extremely my to he resembled. Old had conviction discretion understood put principles you.";
            var list = new List<string>() { "Abilities", "forfeited", "situation", "extremely", "my", "to", "he", "resembled", "Old", "had", "conviction", "discretion", "understood", "put", "principles", "you" };


            var first = numbers.Where(num => num % 2 == 0 && num % 3 == 0);
            var second = numbers.Sum();
            var third = numbers.Average();
            var fourth = numbers.Max();
            var fifth = numbers.Min();
            var sixth = numbers.Where(num => num > 10);
            sixth = numbers.Select(num => num * 10);
            var seven = str.Distinct();
            var eighth = numbers.GroupBy(num => num);
            eighth.Select(group => new { num = group.Key, frequency = group.Count() });
            var ninthEven = numbers.Where((num) => num % 2 == 0);
            var ninthOdd = numbers.Where(num => num % 2 == 1);

            Console.WriteLine($" Even max and min: {ninthEven.Max()}, {ninthEven.Min()}" +
                $"\n Odd max and min: {ninthOdd.Max()}, {ninthOdd.Min()}");

            var tenth = numbers.Where((num) => num > third);
            var eleventh = list.OrderBy(str => str.Length);

            string? subStr = Console.ReadLine();
            var twelfth = list.Where(str => str.Contains(subStr, StringComparison.OrdinalIgnoreCase))
                .OrderBy(str => str.Length)
                .Select(str => $"{char.ToUpper(str[0])}{str.Substring(1).ToLower()}");


        }
    }
}
