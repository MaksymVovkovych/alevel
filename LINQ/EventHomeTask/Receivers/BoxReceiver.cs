namespace EventHomeTask.Receivers
{
    public class BoxReceiver : ReceiverBase
    {
        public BoxReceiver(Post<IItem> post, string name) : base(post, name) { }

        public override void ReceiveProduct(IItem item)
        {
            _post.BoxNotify += (sender, e) => Console.WriteLine($"{Name} received book: {item.Name}");
        }
    }
}
