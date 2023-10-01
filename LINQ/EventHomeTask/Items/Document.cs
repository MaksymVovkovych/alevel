using EventHomeTask.Items;

namespace EventHomeTask
{
    public class Document : IItem
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
        public ProductType ProductType => ProductType.Document;
    }
}
