namespace Catalog.Host.Models.DTOs;

public class CatalogItemDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public string PictureFileName { get; set; } = null!;

    public CatalogTypeDto? CatalogType { get; set; }

    public CatalogBrandDto? CatalogBrand { get; set; }

    public int AvailableStock { get; set; }
}