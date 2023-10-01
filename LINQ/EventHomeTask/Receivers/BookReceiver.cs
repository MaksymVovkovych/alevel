namespace EventHomeTask.Receivers
{
    public class BookReceiver : ReceiverBase
    {
        public BookReceiver(Post<IItem> post, string name) : base(post, name) { }

        public override void ReceiveProduct(IItem item)
        {
            _post.BookNotify += ReceiveBook!;
        }
        private void ReceiveBook(object obj, IItem item)
        {
            Console.WriteLine($"You received book : {item.Name}// {item.Description} for ");
        }
    }
}
