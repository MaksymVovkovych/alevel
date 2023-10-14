using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Part_2
{
    public static class FirstTask
    {
        public static async Task RunAsync()
        {

            int.TryParse(Console.ReadLine(), out int numOne);
            int.TryParse(Console.ReadLine(), out int numTwo);

            Task<int> factorial = Task.Run(() => FactorialFunc(numOne));
            Task<int> fibonachi = Task.Run(() => FibonachiFunc(numTwo));

            Task.WaitAll (factorial, fibonachi);
            Console.WriteLine("first");
            var results = new List<(int Number, int Result)>
            {
                (numOne, factorial.Result),
                (numTwo, fibonachi.Result)
            };
            Console.WriteLine("second");
            foreach (var result in results)
            {
                Console.WriteLine($"Number: {result.Number}, Result: {result.Result}");
            }

        }
        public static int FactorialFunc(this int value)
        {
            return value == 0 ? 0 :
                   value == 1 ? 1 :
                   value * FactorialFunc(value - 1);
        }
        public static int FibonachiFunc(this int n)
        {
            return n <= 1 ? n : FibonachiFunc(n - 1) + FibonachiFunc(n - 2);
        }
    }
}
