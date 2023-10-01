namespace EventHomeTask.Receivers
{
    public class DocumentReceiver : ReceiverBase
    {
        public DocumentReceiver(Post<IItem> post, string name) : base(post, name) { }

        public override void ReceiveProduct(IItem item)
        {
            _post.DocumentNotify += ReceiveDocument!;
        }
        private void ReceiveDocument(object sender, IItem item)
        {
            Console.WriteLine($"You received document : {item.Name} {Name}");
        }
    }
}
