namespace ContactList
{
    public class FileOperations
    {
        private readonly ContactBook _contactBook;
        private Mutex fileMutex = new Mutex(false, "appMutex");

        public FileOperations(ContactBook contactBook)
        {
            _contactBook = contactBook;
        }

        public async Task WriteToFileAsync(string fileName)
        {
            try
            {
                if (!fileMutex.WaitOne(TimeSpan.FromSeconds(5)))
                {
                    throw new MutexException("Unable to acquire mutex for file writing.");
                }

                try
                {
                    var contacts = _contactBook.GetAllContatcts();
                    using (var writer = new StreamWriter(fileName))
                    {
                        foreach (var contact in contacts)
                        {
                            if (contact == null)
                                break;
                            if (contact != null)
                                await writer.WriteLineAsync($"{contact.Name},{contact.Surname},{contact.Number}");
                        }
                    }
                    Thread.Sleep(10000);
                }
                finally
                {
                    fileMutex.ReleaseMutex();
                }
            }
            catch (MutexException mutexEx)
            {
                Console.WriteLine($"Mutex exception: {mutexEx.Message}");
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

                string[] contactLines = fileContent.Split('\n');

                foreach (var contactLine in contactLines)
                {
                    string[] parts = contactLine.Split(',');

                    if (parts.Length == 3)
                    {
                        _contactBook.Add(new Contact
                        {
                            Name = parts[0],
                            Surname = parts[1],
                            Number = uint.Parse(parts[2])
                        });
                    }
                }
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"IO exception: {ioEx.Message}");
            }
            catch (FormatException formatEx)
            {
                Console.WriteLine($"Format exception: {formatEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}
