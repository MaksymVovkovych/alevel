using EventHomeTask.Receivers;

namespace EventHomeTask
{
    public static class App
    {
        public static void Run()
        {
            var items = new List<IItem>()
            {
                new Book() { Name = "A sing of ice and fire", Description = "John Martin" },
                new Book() { Name = "Tom Soyer", Description = "Mark Twen" },

                new Box() { Name = "Small Box", Description = "20*80*10" },
                new Box() { Name = "Large Box", Description = "100*160*20" },

                new Document() { Name = "USO 21415", Description = "USA" },
                new Document() { Name = "USO 5051", Description = "UKR" },
            };

            var post = new Post<IItem>();

            var receivers = new List<ReceiverBase>()
            {
                new BookReceiver(post, "Alex"),
                new BookReceiver(post, "Tom"),

                new BoxReceiver(post, "Steven"),
                new BoxReceiver(post, "Tim"),

                new DocumentReceiver(post, "John"),
                new DocumentReceiver(post, "Sarah")
            };

            receivers[0].ReceiveProduct(items[0]);
            receivers[0].ReceiveProduct(items[1]);
            
            receivers[1].ReceiveProduct(items[1]);

            receivers[2].ReceiveProduct(items[3]);

            receivers[3].ReceiveProduct(items[2]);
            receivers[3].ReceiveProduct(items[3]);

            receivers[4].ReceiveProduct(items[5]);
            receivers[4].ReceiveProduct(items[5]);
            receivers[4].ReceiveProduct(items[5]);

            receivers[5].ReceiveProduct(items[4]);

            post.Invoke(items[4]);
        }
    }
}
