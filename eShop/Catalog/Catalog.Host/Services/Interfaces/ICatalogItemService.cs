using Catalog.Host.Data;
using Catalog.Host.Services.Interfaces.AddResponses;
using Catalog.Host.Services.Interfaces.DeleteRequests;
using Catalog.Host.Services.Interfaces.UpdateRequests;
using Catalog.Host.Services.Interfaces.UpdateResponses;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogItemService
{
    Task<PaginatedItems<CatalogGetItemDto>> GetByPageAsyncHttpGet(int pageIndex, int pageSize);
    Task<Guid?> AddAsync(AddCatalogItemRequest addCatalogItem);
    Task<UpdateCatalogItemResponse<int>> UpdateAsync(UpdateCatalogItemRequest updateCatalogItem);
    Task DeleteAsync(DeleteCatalogItemRequest deleteCatalogItem);
}