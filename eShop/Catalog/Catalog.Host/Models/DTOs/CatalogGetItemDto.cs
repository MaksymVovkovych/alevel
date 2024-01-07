namespace Catalog.Host.Services.Interfaces;

public class CatalogGetItemDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? PictureFileName { get; set; }
    public string? BrandName { get; set; }
    public string? TypeName { get; set; }
}