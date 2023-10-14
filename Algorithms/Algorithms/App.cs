namespace Algorithms
{
    public class App
    {

        public static void AppAlgorithms()
        {
            //Factorial
            Console.WriteLine(Factorial.FactorialFunc(10));



            //Fibonachi
            Console.Write("Enter the number of Fibonacci terms you want to generate: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {

                Console.WriteLine("Fibonacci Sequence:");
                for (int i = 0; i < n; i++)
                    Console.Write(Fibonachi.FibonachiFunc(i) + " ");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Please enter a positive integer.");
            }

            //QuickSort
            int[] array = new int[] { 75, 554, 6853, 56, -15, 65, 8754, 863 };
            QuickSort.Sort(array, 0, array.Length - 1);
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }

            //BinarySearch
            int.TryParse(Console.ReadLine(), out int target);
            Console.WriteLine($"Index of {target} is {BinarySearch.BinarySearchFunc(array, target)}");

        }
    }
}
