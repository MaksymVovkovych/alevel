using System.Reflection;

namespace EventHomeTask.Receivers
{
    public class DocumentReceiver : ReceiverBase
    {
        public DocumentReceiver(Post<IItem> post, string name) : base(post, name) { }

        public override void ReceiveProduct(IItem item)
        {
            _post.DocumentNotify += 
                (sender, e) => Console.WriteLine($"{Name} received document: {item.Name}");
        }
    }
}
