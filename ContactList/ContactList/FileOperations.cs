namespace ContactList
{
    public class FileOperations
    {
        private readonly ContactBook _contactBook;
        private Mutex fileMutex = new Mutex(false, "appMutex");
        private string fileName;

        public FileOperations(string fileName, ContactBook contactBook)
        {
            this.fileName = fileName;
            _contactBook = contactBook;
        }

        public async Task WriteToFileAsync(string fileName)
        {
            fileMutex.WaitOne();
            try
            {
                var contacts = _contactBook.GetAllContatcts();
                using (var writer = new StreamWriter(fileName))
                {
                    foreach (var contact in contacts)
                    {
                        if (contact == null)
                            break;
                        //null ex
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

        public async Task ReadFromFileAsync(string fileName)
        {
            // Завантажуємо весь вміст файлу асинхронно
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
                     _contactBook.Add1(new Contact
                    {
                        Name = parts[0],
                        Surname = parts[1],
                        Number = uint.Parse(parts[2])
                    });
                }
            }
        }

    }
}
