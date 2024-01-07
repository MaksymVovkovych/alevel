using Catalog.Host.Data;
using Catalog.Host.Models.DTOs;
using Catalog.Host.Services.Interfaces.AddResponses;
using Catalog.Host.Services.Interfaces.DeleteRequests;
using Catalog.Host.Services.Interfaces.UpdateRequests;
using Catalog.Host.Services.Interfaces.UpdateResponses;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogBrandService
{
    Task<PaginatedItems<CatalogBrandDto>> GetByPageAsyncHttpGet(int pageIndex, int pageSize);
    Task<Guid?> AddAsync(AddCatalogBrandRequest addCatalogBrand);
    Task<UpdateCatalogBrandResponse<int>> UpdateAsync(UpdateCatalogBrandRequest updateCatalogBrand);
    Task DeleteAsync(DeleteCatalogBrandRequest deleteCatalogBrand);
}