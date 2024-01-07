using Catalog.Host.Services.Interfaces.AddResponses;

namespace Catalog.Host.Services.Interfaces.UpdateRequests;

public class UpdateCatalogTypeRequest : AddCatalogTypeRequest
{
    public Guid Id { get; set; }
}