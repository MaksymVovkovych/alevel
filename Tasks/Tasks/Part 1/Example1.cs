using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public static class Example1
    {
        public static void Run()
        {
            const string pathOne = @"D:\async1.txt";
            const string pathTwo = @"D:\async2.txt";

            static async Task Main()
            {

                var taskCreateOne = WriteToFileAsync(pathOne, "Hello");
                var taskCreateTwo = WriteToFileAsync(pathTwo, "World");

                await Task.WhenAll(taskCreateOne, taskCreateTwo);

                Console.WriteLine("Both tasks completed.");
                var taskReadOne = ReadFromFileAsync(pathOne);
                var taskReadTwo = ReadFromFileAsync(pathTwo);

                var result = await Task.WhenAll(taskReadOne, taskReadTwo);
                Console.WriteLine(result);

            }

            static async Task WriteToFileAsync(string path, string text)
            {
                await File.WriteAllTextAsync(path, text);
                Console.WriteLine($"File '{path}' written asynchronously.");
            }

            static async Task<string> ReadFromFileAsync(string path)
            {
                Console.WriteLine($"File '{path}' written asynchronously.");
                return await File.ReadAllTextAsync(path);
            }
        }
    }
}
