namespace ContactList
{
    public class Contact
    {
        public required string Name { get; set; }
        public string? Surname { get; set; }
        public required uint Number { get; set; }
    }
}
