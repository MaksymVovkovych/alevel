namespace Catalog.Host.Services.Interfaces.AddResponses;

public class AddCatalogItemRequest
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string PictureFileName { get; set; } = null!;
    public Guid CatalogTypeId { get; set; }
    public Guid CatalogBrandId { get; set; }
    public int AvailableStock { get; set; }
}