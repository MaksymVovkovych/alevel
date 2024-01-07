using Catalog.Host.Services.Interfaces.AddResponses;

namespace Catalog.Host.Services.Interfaces.DeleteRequests;

public class DeleteCatalogTypeRequest : AddCatalogTypeRequest
{
    public Guid Id { get; set; }
}