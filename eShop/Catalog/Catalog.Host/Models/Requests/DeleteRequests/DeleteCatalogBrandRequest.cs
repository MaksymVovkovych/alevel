using Catalog.Host.Services.Interfaces.AddResponses;

namespace Catalog.Host.Services.Interfaces.DeleteRequests;

public class DeleteCatalogBrandRequest : AddCatalogBrandRequest
{
    public Guid Id { get; set; }
}