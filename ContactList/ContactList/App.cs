namespace ContactList
{
    internal class App
    {
        private readonly ContactBookServices _contactBookServices;
        private readonly FileOperations _fileOperations;
        private readonly Watcher _watcher;
        private readonly string _path;
        public App(ContactBookServices contactBookServices, FileOperations fileOperations, Watcher watcher, string filePath)
        {
            _contactBookServices = contactBookServices;
            _fileOperations = fileOperations;
            _watcher = watcher;
            _path = filePath;
        }
        public async void AppContactBook()
        {
            _watcher.StartWatching();
            while (true)
            {
                try
                {
                    Console.WriteLine("ContactBook:");
                    Console.WriteLine("1.Input contact to contact book");
                    Console.WriteLine("2.Delete contact from contact book");
                    Console.WriteLine("3.Search contact from contact book");
                    Console.WriteLine("4.Write contact book into file");
                    Console.WriteLine("5.Read contact book from file");
                    Console.WriteLine("6.Exit");

                    int.TryParse(Console.ReadLine(), out int value);
                    if (value < 1 || value > 6)
                    {
                        throw new InvalidInputDataException("Invalid input: Value should be between 1 and 7.");
                    }

                    switch (value)
                    {
                        case 1:
                            Console.WriteLine("Create contact in your CB");
                            string addName = Console.ReadLine();
                            string addSurname = Console.ReadLine();
                            var parseResult = uint.TryParse(Console.ReadLine(), out uint addNumber);

                            if (string.IsNullOrEmpty(addName) || string.IsNullOrEmpty(addSurname) || !parseResult)
                            {
                                throw new InvalidInputDataException("Invalid input data, try again.");
                            }

                            _contactBookServices.AddContact(
                                new Contact()
                                {
                                    Name = addName,
                                    Surname = addSurname,
                                    Number = addNumber,
                                });
                            break;

                        case 2:
                            Console.WriteLine("Delete contact for Name and Surname:");
                            string deleteName = Console.ReadLine();
                            string deleteSurname = Console.ReadLine();

                            if (string.IsNullOrEmpty(deleteName) || string.IsNullOrEmpty(deleteSurname))
                            {
                                throw new InvalidInputDataException("Invalid input data, try again.");
                            }

                            _contactBookServices.DeleteContact(deleteName, deleteSurname);
                            Console.WriteLine($"Contact {deleteName},{deleteSurname} was deleted");
                            break;

                        case 3:
                            try
                            {
                                Console.WriteLine("Input the paramiter for search contact:");

                                switch (Console.ReadLine())
                                {
                                    case "Name":
                                        Console.WriteLine("Input name:");
                                        string searchName = Console.ReadLine();

                                        if (string.IsNullOrEmpty(searchName))
                                        {
                                            throw new InvalidInputDataException("Inputed name is not possible to be null.");
                                        }
                                        var searchNameContacts = _contactBookServices.SearchContactAsync("Name", searchName);

                                        foreach (Contact contact in searchNameContacts)
                                        {
                                            Console.WriteLine(contact.Name + ' ' + contact.Surname + ' ' + contact.Number);
                                        }
                                        break;

                                    case "Surname":
                                        Console.WriteLine("Input surname:");
                                        string searchSurname = Console.ReadLine();

                                        if (string.IsNullOrEmpty(searchSurname))
                                        {
                                            throw new InvalidInputDataException("Inputed surname is not possible to be null.");
                                        }
                                        var searchSurnameContacts = _contactBookServices.SearchContactAsync("Surname", searchSurname);

                                        foreach (Contact contact in searchSurnameContacts)
                                        {
                                            Console.WriteLine(contact.Name + ' ' + contact.Surname + ' ' + contact.Number);
                                        }
                                        break;

                                    case "Number":
                                        Console.WriteLine("Input number:");
                                        string searchNumber = Console.ReadLine();

                                        if (string.IsNullOrEmpty(searchNumber))
                                        {
                                            throw new InvalidInputDataException("Inputed number is not possible to be null.");
                                        }
                                        var searchNumberContacts = _contactBookServices.SearchContactAsync("Number", searchNumber);

                                        foreach (Contact contact in searchNumberContacts)
                                        {
                                            Console.WriteLine(contact.Name + ' ' + contact.Surname + ' ' + contact.Number);
                                        }
                                        break;

                                    default:
                                        throw new InvalidInputDataException("Invalid parameter, try again.");

                                }
                            }
                            catch (InvalidInputDataException ex)
                            {
                                Console.WriteLine($"{ex.Message}");
                            }
                            break;

                        case 4:
                            Console.WriteLine("Are you sure you want to write contacts from ContactBook into your file (Yes/No)?");
                            string writeAnswer = Console.ReadLine();
                            if (string.IsNullOrEmpty(writeAnswer))
                            {
                                throw new InvalidInputDataException("Answer is not possible to be null");
                            }
                            if (writeAnswer == "Yes" || writeAnswer == "yes")
                            {
                                await _fileOperations.WriteToFileAsync(_path);
                                Console.WriteLine("Contacts written to file.");
                            }
                            else if (writeAnswer == "No" || writeAnswer == "no")
                            {
                                break;
                            }
                            else
                            {
                                throw new InvalidInputDataException("Invalid input answer");
                            }
                            break;

                        case 5:
                            Console.WriteLine("Are you sure you want to read contacts from a file into your ContactBook (Yes/No)?");
                            string readAnswer = Console.ReadLine();
                            if (string.IsNullOrEmpty(readAnswer))
                            {
                                throw new InvalidInputDataException("Answer is not possible to be null");
                            }
                            if (readAnswer == "Yes" || readAnswer == "yes")
                            {
                                await _fileOperations.ReadFromFileAsync(_path);
                                Console.WriteLine("Contacts read from file.");
                            }
                            else if (readAnswer == "No" || readAnswer == "no")
                            {
                                break;
                            }
                            else
                            {
                                throw new InvalidInputDataException("Invalid input answer");
                            }
                            break;

                        case 6:
                            _watcher.StopWatching();
                            return;
                        default:
                            throw new InvalidInputDataException("Invalid input. Please enter a valid option.");

                    }
                }
                catch (InvalidInputDataException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
        }
    }
}
