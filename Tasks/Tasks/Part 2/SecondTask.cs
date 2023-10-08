using System.Security.Cryptography.X509Certificates;

namespace Tasks.Part_2
{
    public static class SecondTask
    {

        public static async Task RunAsync()
        {
            const string firstPath = @"D:\async1.txt";
            const string secondPath = @"D:\async2.txt";

            char[] symbols = new char[] {' ', '\t', '\n', '\r', '.', ',', ';', '!', '?',
                '<', '>', '$', '@', '-', '/', '{', '}', '=', '"', '[', ']', '(', ')' };

            var httpClient = new HttpClient();

            string firstSiteUrl = "https://dateo-software.de/blog/best-practices-async-await";
            string secondSiteUrl = "https://www.albahari.com/threading/part5.aspx";

            var downloads = new[]
            {
                 httpClient.GetStringAsync(firstSiteUrl),
                 httpClient.GetStringAsync(secondSiteUrl)
            };
            await Task.WhenAll(downloads);


            var fileInfo = new[]
            {
                File.WriteAllTextAsync(firstPath, downloads[0].Result),
                File.WriteAllTextAsync(secondPath, downloads[1].Result)
            };
            await Task.WhenAll(fileInfo);


            var readFileFirst = Task.Run(async () =>
            {
                string text = await File.ReadAllTextAsync(firstPath);
                return text;
            });
            var readFileSecond = Task.Run(async () =>
            {
                string text = await File.ReadAllTextAsync(secondPath);
                return text;
            });

            await Task.WhenAll(readFileFirst, readFileSecond);


            string result = readFileFirst.Result + readFileSecond.Result;

   
            var uniqueWords = MapReduce(result, in symbols);

            foreach (var wordCountPair in uniqueWords)
            {
                Console.WriteLine($"{wordCountPair.Key}, {wordCountPair.Value}");
            }

            httpClient.Dispose();
        }
        static IEnumerable<KeyValuePair<string, int>> MapReduce(string text, in char[] separator)
        {
            string[] words = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            var wordCountPairs = words.Select(word => new KeyValuePair<string, int>(word, 1));

            var groupedWords = wordCountPairs.GroupBy(pair => pair.Key);

            var uniqueWords = groupedWords.Select(group =>
                new KeyValuePair<string, int>(group.Key, group.Sum(pair => pair.Value))
            );
            return uniqueWords;
        }

    }
}
