using Catalog.Host.Models.DTOs;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogBffService
{
    Task<PaginatedItemsResponse<CatalogGetItemDto>> GetCatalogItemsAsync(PaginatedItemsRequest request);
    Task<CatalogGetItemDto> GetItemByIdAsync(Guid id);
    Task<PaginatedItemsResponse<CatalogGetItemDto>> GetItemsByBrandAsync(Guid brandId);
    Task<PaginatedItemsResponse<CatalogGetItemDto>> GetItemsByTypeAsync(Guid typeId);

    //Brands
    Task<PaginatedItemsResponse<CatalogBrandDto>> GetBrandsByPageAsync(int pageIndex, int pageSize);
    Task<CatalogBrandDto> GetBrandByIdAsync(Guid id);

    //Types
    Task<PaginatedItemsResponse<CatalogTypeDto>> GetTypesByPageAsync(int pageIndex, int pageSize);
    Task<CatalogTypeDto> GetTypeByIdAsync(Guid id);
}