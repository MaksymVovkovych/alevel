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

        public void AddContact(Contact contact) => _contactBook.Add1(contact);
        public void DeleteContact(string name, string surname) => _contactBook.Delete(name, surname);
        public IEnumerable<Contact?> SearchContactAsync(string type, string target)
        {
            switch (type)
            {
                case "Name":
                    return _contactBook.FindByNameAsync(target);
                case "Surname":
                    return _contactBook.FindBySurnameAsync(target);
                case "Number":
                    uint.TryParse(target, out uint num);
                    return _contactBook.FindByNumberAsync(num);
                default:
                    return null;
            }
        }

    }
}
