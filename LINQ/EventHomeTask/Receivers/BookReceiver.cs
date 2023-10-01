namespace EventHomeTask.Receivers
{
    public class BookReceiver : ReceiverBase
    {
        public BookReceiver(Post<IItem> post, string name) : base(post, name) { }

        public override void ReceiveProduct(IItem item)
        {
            _post.BookNotify += (sender, e) => Console.WriteLine($"{Name} received book: {item.Name} // {item.Description}");
        }
        
    }
}
