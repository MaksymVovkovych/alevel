using Catalog.Host.Services.Interfaces.AddResponses;

namespace Catalog.Host.Services.Interfaces.DeleteRequests;

public class DeleteCatalogItemRequest : AddCatalogItemRequest
{
    public Guid Id { get; set; }
}