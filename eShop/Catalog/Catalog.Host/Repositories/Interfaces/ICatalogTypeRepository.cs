using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Services.Interfaces.AddResponses;
using Catalog.Host.Services.Interfaces.DeleteRequests;
using Catalog.Host.Services.Interfaces.UpdateRequests;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogTypeRepository
{
    Task<PaginatedItems<CatalogType>> GetTypesByPageAsync(int pageIndex, int pageSize);
    Task<CatalogType> GetTypeByIdAsync(Guid id);

    Task<PaginatedItems<CatalogType>> GetByPageAsyncHttpGet(int pageIndex, int pageSize);
    Task<Guid?> AddAsync(AddCatalogTypeRequest typeToAdd);
    Task<CatalogType> UpdateAsync(UpdateCatalogTypeRequest typeToUpdate);
    Task DeleteAsync(DeleteCatalogTypeRequest typeToDelete);
}