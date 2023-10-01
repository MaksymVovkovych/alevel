namespace EventHomeTask
{
    public class Post<T> where T : IItem
    {
        public event EventHandler<Document>? DocumentNotify;
        public event EventHandler<Box>? BoxNotify;
        public event EventHandler<Book>? BookNotify;

        public void Invoke(T item)
        {
            if (item is Book book) BookNotify?.Invoke(this, book);
            else if (item is Document document) DocumentNotify?.Invoke(this, document);
            else if (item is Box box) BoxNotify?.Invoke(this, box);
            else
                throw new InvalidOperationException();
        }
    }
}
