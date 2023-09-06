using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkThree
{
    public static class SearchName
    {
        public static void Search(Dictionary<string,Vehicle> dict)
        {
            var input = Console.ReadLine();
            if (dict.TryGetValue(input, out Vehicle vehicle1))
            {
                Console.WriteLine($"Found vehicle: {vehicle1.Name} ({vehicle1.GetType().Name})");
            }
            else
            {
                Console.WriteLine("User not Found");
            }
        }
       
    }
}
