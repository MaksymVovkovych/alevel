using EventHomeTask.Items;

namespace EventHomeTask
{
    public interface IItem
    {
        string Name { get; }
        string Description { get; }
        ProductType ProductType { get; }
    }
}
