using Catalog.Host.Data;
using Catalog.Host.Models.DTOs;
using Catalog.Host.Services.Interfaces.AddResponses;
using Catalog.Host.Services.Interfaces.DeleteRequests;
using Catalog.Host.Services.Interfaces.UpdateRequests;
using Catalog.Host.Services.Interfaces.UpdateResponses;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogTypeService
{
    Task<PaginatedItems<CatalogTypeDto>> GetByPageAsyncHttpGet(int pageIndex, int pageSize);
    Task<Guid?> AddAsync(AddCatalogTypeRequest addCatalogType);
    Task<UpdateCatalogTypeResponse<int>> UpdateAsync(UpdateCatalogTypeRequest updateCatalogType);
    Task DeleteAsync(DeleteCatalogTypeRequest deleteCatalogType);
}