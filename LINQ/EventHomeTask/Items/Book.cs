using EventHomeTask.Items;

namespace EventHomeTask
{
    public class Book : IItem
    {
        public required string Name { get; set; }

        public required string Description { get; set; }
        public ProductType ProductType => ProductType.Book;
    }
}
