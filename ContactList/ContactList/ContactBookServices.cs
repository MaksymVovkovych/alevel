namespace ContactList
{
    internal class ContactBookServices
    {
        private readonly ContactBook _contactBook;
        public ContactBookServices(ContactBook contactBook)
        {
            _contactBook = contactBook;
        }

        public void AddContact(Contact contact) => _contactBook.Add(contact);
        public void DeleteContact(string name, string surname) => _contactBook.Delete(name, surname);
        public IEnumerable<Contact?> SearchContactAsync(string type, string target)
        {
            try
            {
                switch (type)
                {
                    case "Name":
                        return _contactBook.FindByNameAsync(target);
                    case "Surname":
                        return _contactBook.FindBySurnameAsync(target);
                    case "Number":
                        if (uint.TryParse(target, out uint num))
                        {
                            return _contactBook.FindByNumberAsync(num);
                        }
                        else
                        {
                            throw new InvalidCastException("Invalid cast exception from string to uint.");
                        }
                    default:
                        return Enumerable.Empty<Contact?>();
                }
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return Enumerable.Empty<Contact?>();
            }
        }

    }
}
