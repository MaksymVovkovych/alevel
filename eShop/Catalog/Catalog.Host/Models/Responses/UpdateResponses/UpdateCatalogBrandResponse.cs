using Catalog.Host.Models.DTOs;

namespace Catalog.Host.Services.Interfaces.UpdateResponses;

public class UpdateCatalogBrandResponse<T>
{
    public CatalogBrandDto Brand { get; set; } = null!;
}