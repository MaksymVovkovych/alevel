using System.Collections;

namespace ContactList
{
    public class ContactBook : IEnumerable
    {
        private Contact?[] book;
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
            for (int i = 0; i < book.Length; i++)
            {
                if (book[i] == null)
                {
                    book[i] = person;
                    return;
                }
                if (book[i].Name == person.Name && book[i].Surname == person.Surname)
                {
                    throw new InvalidOperationException("Duplicate contact: " + person.Name + " " + person.Surname);
                }
            }
        }
        public Contact? Delete(string name, string surname)
        {
            if (book == null)
            {
                return null;
            }

            for (int i = 0; i < book.Length; i++)
            {
                if (book[i] != null && book[i].Name == name && book[i].Surname == surname)
                {
                    Contact contactToDelete = book[i];
                    book[i] = null;
                    return contactToDelete;
                }
            }

            throw new NullReferenceException("The object does not exist");
        }
        public IEnumerable<Contact?> FindByNumberAsync(uint number)
        {
            return book.Where(contact => contact?.Number == number).ToList();
        }
        public IEnumerable<Contact?> FindByNameAsync(string name)
        {
            return book.Where(contact => contact?.Name == name).ToList();
        }
        public IEnumerable<Contact?> FindBySurnameAsync(string surname)
        {
            return book.Where(contact => contact?.Surname == surname).ToList();
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
