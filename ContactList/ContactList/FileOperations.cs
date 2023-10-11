using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        await writer.WriteLineAsync($"{contact.Name},{contact.Surname},{contact.Number}");
                    }
                }
            }
            finally
            {
                fileMutex.ReleaseMutex();
            }

        }

        public async Task<IEnumerable<Contact>> ReadFromFileAsync(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        _contactBook.Add(new Contact
                        {
                            Name = parts[0],
                            Surname = parts[1],
                            Number = uint.Parse(parts[2])
                        });
                    }// exeption
                }
            }
            var temp = _contactBook.GetAllContatcts();
            return temp;
        }
    }
}
