using Catalog.Host.Models.DTOs;

namespace Catalog.Host.Services.Interfaces.UpdateResponses;

public class UpdateCatalogTypeResponse<T>
{
    public CatalogTypeDto Type { get; set; } = null!;
}