namespace EventHomeTask.Receivers
{
    public class BoxReceiver : ReceiverBase
    {
        public BoxReceiver(Post<IItem> post, string name) : base(post, name) { }

        public override void ReceiveProduct(IItem item)
        {
            _post.BoxNotify += ReceiveBox!;
        }

        private void ReceiveBox(object obj, IItem item)
        {
            Console.WriteLine($"You received book : {item.Name}");
        }
    }
}
