using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Services.Interfaces;
using Catalog.Host.Services.Interfaces.AddResponses;
using Catalog.Host.Services.Interfaces.DeleteRequests;
using Catalog.Host.Services.Interfaces.UpdateRequests;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<PaginatedItems<CatalogItem>> GetItemsByPageAsync(PaginatedItemsRequest request);
    Task<CatalogItem> GetItemByIdAsync(Guid id);
    Task<IEnumerable<CatalogItem>> GetItemsByBrandAsync(Guid brandId);
    Task<IEnumerable<CatalogItem>> GetItemsByTypeAsync(Guid typeId);

    Task<PaginatedItems<CatalogItem>> GetByPageAsyncHttpGet(int pageIndex, int pageSize);
    Task<Guid?> AddAsync(AddCatalogItemRequest itemToAdd);
    Task<CatalogItem> UpdateAsync(UpdateCatalogItemRequest itemToUpdate);
    Task DeleteAsync(DeleteCatalogItemRequest itemToDelete);
}