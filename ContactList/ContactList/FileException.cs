namespace ContactList
{
    public class FileException : Exception
    {
        public FileException() { }
        public FileException(string message) : base(message) { }
    }
}
