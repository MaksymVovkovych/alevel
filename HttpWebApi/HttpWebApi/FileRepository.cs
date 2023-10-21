
namespace HttpWebApi
{
    public class FileRepository
    {

        private Mutex fileMutex = new Mutex(false, "appMutex");
        public Dictionary<Guid, Product> productsDictionary = new Dictionary<Guid, Product>
        {
            
        };

        public async Task WriteToFileAsync(string fileName)
        {
            try
            {
                if (!fileMutex.WaitOne(TimeSpan.FromSeconds(5)))
                {
                    throw new Exception("Unable to acquire mutex for file writing.");
                }

                try
                {
                    using (FileStream fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write))
                    using (var writer = new StreamWriter(fileStream))
                    {
                        foreach (var kvp in productsDictionary)
                        {
                            var product = kvp.Value;
                            await writer.WriteLineAsync($"{kvp.Key},{product.Name},{product.Category},{product.Count}");
                        }
                    }
                }
                finally
                {
                    fileMutex.ReleaseMutex();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task ReadFromFileAsync(string fileName)
        {
            try
            {
                string fileContent;
                using (var reader = new StreamReader(fileName))
                {
                    fileContent = await reader.ReadToEndAsync();
                }

                string[] productLines = fileContent.Split('\n');

                foreach (var productLine in productLines)
                {
                    string[] parts = productLine.Split(',');

                    if (parts.Length == 4)
                    {
                        if (Guid.TryParse(parts[0], out Guid productId))
                        {
                            productsDictionary[productId] = new Product//key
                            {
                                Name = parts[1],
                                Category = parts[2],
                                Count = int.Parse(parts[3])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
