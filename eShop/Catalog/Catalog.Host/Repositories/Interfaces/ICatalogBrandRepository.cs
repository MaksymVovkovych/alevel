using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Services.Interfaces.AddResponses;
using Catalog.Host.Services.Interfaces.DeleteRequests;
using Catalog.Host.Services.Interfaces.UpdateRequests;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogBrandRepository
{
    Task<PaginatedItems<CatalogBrand>> GetBrandsByPageAsync(int pageIndex, int pageSize);
    Task<CatalogBrand> GetBrandByIdAsync(Guid id);

    Task<PaginatedItems<CatalogBrand>> GetByPageAsyncHttpGet(int pageIndex, int pageSize);
    Task<Guid?> AddAsync(AddCatalogBrandRequest brandToAdd);
    Task<CatalogBrand> UpdateAsync(UpdateCatalogBrandRequest brandToUpdate);
    Task DeleteAsync(DeleteCatalogBrandRequest brandToDelete);
}