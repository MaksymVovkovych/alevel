namespace ContactList
{
    internal class App
    {
        private readonly ContactBookServices _contactBookServices;
        private readonly FileOperations _fileOperations;
        private readonly Watcher _watcher;
        public App(ContactBookServices contactBookServices, FileOperations fileOperations, Watcher watcher)
        {
            _contactBookServices = contactBookServices;
            _fileOperations = fileOperations;
            _watcher = watcher;
        }
        public async void AppContactBook()
        {
            _watcher.StartWatching();
            while (true)
            {


                Console.WriteLine("ContactBook:");
                Console.WriteLine("1.Input contact to contact book");
                Console.WriteLine("2.Delete contact from contact book");
                Console.WriteLine("3.Search contact from contact book");
                Console.WriteLine("4.Write contact book into file");
                Console.WriteLine("5.Read contact book from file");
                Console.WriteLine("6.Exit");

                int.TryParse(Console.ReadLine(), out int value);
                //ex
                switch (value)
                {
                    case 1:
                        Console.WriteLine("Create contact in your CB");
                        string name = Console.ReadLine();
                        string surname = Console.ReadLine();
                        uint.TryParse(Console.ReadLine(), out uint number);
                        //ex
                        _contactBookServices.AddContact(
                            new Contact()
                            {
                                Name = name,
                                Number = number,
                                Surname = surname
                            });
                        break;

                    case 2:
                        Console.WriteLine("Delete contact for Name and Surname:");
                        string name1 = Console.ReadLine();
                        string surname1 = Console.ReadLine();
                        //ex
                        _contactBookServices.DeleteContact(name1, surname1);
                        Console.WriteLine($"Contact {name1},{surname1} was deleted");
                        break;

                    case 3:
                        Console.WriteLine("Input the paramiter for search contact:");
                        switch (Console.ReadLine())
                        {
                            case "Name":
                                Console.WriteLine("Input name:");
                                string name2 = Console.ReadLine();
                                IEnumerable<Contact?> contacts = _contactBookServices.SearchContactAsync("Name", name2);
                                foreach (Contact contact in contacts)
                                {
                                    Console.WriteLine(contact.Name, contact.Surname, contact.Number);
                                }
                                break;
                            case "Surname":
                                Console.WriteLine("Input surname:");
                                string surname2 = Console.ReadLine();
                                IEnumerable<Contact?> contacts1 = _contactBookServices.SearchContactAsync("Surname", surname2);
                                foreach (Contact contact in contacts1)
                                {
                                    Console.WriteLine(contact.Name, contact.Surname, contact.Number);
                                }
                                break;
                            case "Number":
                                Console.WriteLine("Input number:");
                                string number2 = Console.ReadLine();
                                IEnumerable<Contact?> contacts2 = _contactBookServices.SearchContactAsync("Number", number2);
                                foreach (Contact contact in contacts2)
                                {
                                    Console.WriteLine(contact.Name, contact.Surname, contact.Number);
                                }
                                break;
                            default:
                                break;
                                //throw ex

                        }
                        //throw ex
                        break;

                    case 4:
                        Console.WriteLine("Are you sure you want to write contacts from ContactBook into your file (Yes/No)?");
                        string answer1 = Console.ReadLine();
                        if (answer1 == "Yes")
                        {
                            await _fileOperations.WriteToFileAsync(@"D:\async.txt");
                            Console.WriteLine("Contacts written to file.");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Are you sure you want to read contacts from a file into your ContactBook (Yes/No)?");
                        string answer = Console.ReadLine();
                        if (answer == "Yes")
                        {
                            await _fileOperations.ReadFromFileAsync(@"D:\async.txt");
                            Console.WriteLine("Contacts read from file.");
                        }
                        break;

                    case 6:
                        _watcher.StopWatching();
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please enter a valid option.");
                        break;

                }
            }
        }
    }
}
