namespace EventHomeTask
{
    public abstract class ReceiverBase
    {
        protected Post<IItem> _post;
        public string Name { get; init; }
        public abstract void ReceiveProduct(IItem item);

        public ReceiverBase(Post<IItem> post, string name)
        {
            _post = post;
            Name = name;
        }
    }
}
