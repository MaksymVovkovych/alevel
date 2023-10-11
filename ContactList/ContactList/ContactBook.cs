using System.Collections;

namespace ContactList
{
    public class ContactBook : IEnumerable
    {
        private Contact?[] book;
        object locker = new object();

        public ContactBook(int capacity)
        {
            book = new Contact?[capacity];
        }
        public Contact? this[int index]
        {
            get => book[index];
            set => book[index] = value;
        }
        public void Add(Contact person)
        {
            lock (locker)
            {
                for (int i = 0; i < book.Length; i++)
                {
                    //if (book[i] == person)
                    //ex
                    if (book[i] == null)
                    {
                        book[i] = person;
                        return;
                    }

                }
            }

        }
        public Contact? Delete(Contact person)
        {
            if (book == null)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < book.Length; i++)
                {
                    if (book[i] == person)
                    { 
                        book[i] = null;
                        return book[i];
                    }
                }
                return null;
            }
        }
        public async Task<IEnumerable<Contact?>> FindByNumberAsync(uint number)
        {
            return await Task.Run(() => book.Where(contact => contact?.Number == number).ToList());
        }

        public async Task<IEnumerable<Contact?>> FindByNameAsync(string name)
        {
            return await Task.Run(() => book.Where(contact => contact?.Name == name).ToList());
        }

        public async Task<IEnumerable<Contact?>> FindBySurnameAsync(string surname)
        {
            return await Task.Run(() => book.Where(contact => contact?.Surname == surname).ToList());
        }
        public IEnumerable<Contact?> GetAllContatcts()
        {
            return book;
        }
        public IEnumerator GetEnumerator()
        {
            var temp = book.OrderBy(conatact => conatact.Name);
            return temp.GetEnumerator();
        }
    }
}
