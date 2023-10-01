namespace EventHomeTask
{
    public class Post<T> where T : IItem
    {
        public event EventHandler<T>? DocumentNotify;
        public event EventHandler<T>? BoxNotify;
        public event EventHandler<T>? BookNotify;

        public void Invoke(T item)
        {
            if (item is Book) BookNotify?.Invoke(this, item);
            else if (item is Document) DocumentNotify?.Invoke(this, item);
            else if (item is Box) BoxNotify?.Invoke(this, item);
            else
                throw new InvalidOperationException();
        }
    }
}
