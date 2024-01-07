using Catalog.Host.Services.Interfaces.AddResponses;

namespace Catalog.Host.Services.Interfaces.UpdateRequests;

public class UpdateCatalogItemRequest : AddCatalogItemRequest
{
    public Guid Id { get; set; }
}