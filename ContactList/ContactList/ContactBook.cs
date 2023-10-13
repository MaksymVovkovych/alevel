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
        public void Add1(Contact person)
        {

            for (int i = 0; i < book.Length; i++)
            {
                if (book[i] == person)
                    return;
                //throw ex if exist dublicate
                //ex
                if (book[i] == null)
                {
                    book[i] = person;
                    return;
                }
            }

        }
        public Contact? Delete(string name, string surname)
        {
            if (book == null)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < book.Length; i++)
                {
                    if (book[i].Name == name && book[i].Surname == surname)
                    {
                        book[i] = null;
                        return book[i];
                        //throw ex
                    }
                }
                return null;
            }
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
