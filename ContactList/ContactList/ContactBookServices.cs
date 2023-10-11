using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ContactList
{
    internal class ContactBookServices
    {
        private readonly ContactBook _contactBook;
        private static readonly Mutex fileMutex = new Mutex(false, "appMutex");
        public ContactBookServices(ContactBook contactBook) 
        {
            _contactBook = contactBook;
        }

        public async Task AddContact(Contact contact) => _contactBook.Add(contact);
        public async Task DeleteContact(Contact contact) => _contactBook.Delete(contact);
        public async Task<IEnumerable<Contact?>> SearchContactAsync(string type, string target)
        {
            switch(type)
            {
                case "Name":
                    return await _contactBook.FindByNameAsync(target);
                case "Surname":
                    return await _contactBook.FindBySurnameAsync(target);
                case "Number":
                    uint.TryParse(target, out uint num);
                    return await _contactBook.FindByNumberAsync(num);
                default:
                    return null;
            }
        }

    }
}
