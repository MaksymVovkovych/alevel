using Catalog.Host.Services.Interfaces.AddResponses;

namespace Catalog.Host.Services.Interfaces.UpdateRequests;

public class UpdateCatalogBrandRequest : AddCatalogBrandRequest
{
    public Guid Id { get; set; }
}