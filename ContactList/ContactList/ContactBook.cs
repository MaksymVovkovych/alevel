using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            for(int i = 0; i < book.Length; i++)
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
        public void Delete(Contact person)
        {
            if(book == null)
            {
                return;
            }
            else
            {

            }
        }
        public void Update(Contact person)
        {

        }
        public Contact?[] GetAll()
        {

        }
        public Contact Get(int number)
        {

        }


        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
