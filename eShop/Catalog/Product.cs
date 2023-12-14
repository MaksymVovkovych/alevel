namespace Catalog
{
    public class Product
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public int Quantity { get; set; }
        public string Avatar { get; set; } = "";
    }


}
