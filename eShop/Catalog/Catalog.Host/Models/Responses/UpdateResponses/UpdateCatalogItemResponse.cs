namespace Catalog.Host.Services.Interfaces.UpdateResponses;

public class UpdateCatalogItemResponse<T>
{
    public CatalogGetItemDto Item { get; set; } = null!;
}