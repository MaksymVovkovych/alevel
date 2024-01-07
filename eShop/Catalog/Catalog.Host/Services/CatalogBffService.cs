using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Models.DTOs;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Services;

public class CatalogBffService : BaseDataService<AppDbContext>, ICatalogBffService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly ICatalogBrandRepository _catalogBrandRepository;
    private readonly ICatalogTypeRepository _catalogTypeRepository;

    private readonly IMapper _mapper;
    public CatalogBffService(
        IDbContextWrapper<AppDbContext> dbContextWrapper, 
        ILogger<BaseDataService<AppDbContext>> logger,
        ICatalogItemRepository catalogItemRepository,
        ICatalogBrandRepository catalogBrandRepository,
        ICatalogTypeRepository catalogTypeRepository,
        IMapper mapper) 
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _mapper = mapper;
        _catalogBrandRepository = catalogBrandRepository;
        _catalogTypeRepository = catalogTypeRepository;
    }

    //Items
    public async Task<PaginatedItemsResponse<CatalogGetItemDto>> GetCatalogItemsAsync(PaginatedItemsRequest request)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetItemsByPageAsync(request);
            return new PaginatedItemsResponse<CatalogGetItemDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogGetItemDto>(s)).ToList(),
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
        });
    }

    public async Task<CatalogGetItemDto> GetItemByIdAsync(Guid id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var item = await _catalogItemRepository.GetItemByIdAsync(id);
            return _mapper.Map<CatalogGetItemDto>(item);
        });
    }

    public async Task<PaginatedItemsResponse<CatalogGetItemDto>> GetItemsByBrandAsync(Guid brandId)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var items = await _catalogItemRepository.GetItemsByBrandAsync(brandId);
            var data = items.Select(item => _mapper.Map<CatalogGetItemDto>(item));
            return new PaginatedItemsResponse<CatalogGetItemDto>
            {
                Count = items.Count(),
                Data = data.ToList(),
                PageIndex = 1,
                PageSize = items.Count()
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogGetItemDto>> GetItemsByTypeAsync(Guid typeId)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var items = await _catalogItemRepository.GetItemsByTypeAsync(typeId);
            var data = items.Select(item => _mapper.Map<CatalogGetItemDto>(item));
            return new PaginatedItemsResponse<CatalogGetItemDto>
            {
                Count = items.Count(),
                Data = data.ToList(),
                PageIndex = 1,
                PageSize = items.Count()
            };
        });
    }


    //Brands
    public async Task<PaginatedItemsResponse<CatalogBrandDto>> GetBrandsByPageAsync(int pageIndex, int pageSize)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogBrandRepository.GetBrandsByPageAsync(pageIndex, pageSize);
            var data = result.Data.Select(brand => _mapper.Map<CatalogBrandDto>(brand));
            return new PaginatedItemsResponse<CatalogBrandDto>
            {
                Count = result.TotalCount,
                Data = data.ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<CatalogBrandDto> GetBrandByIdAsync(Guid id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var brand = await _catalogBrandRepository.GetBrandByIdAsync(id);
            return _mapper.Map<CatalogBrandDto>(brand);
        });
    }


    //Types
    public async Task<PaginatedItemsResponse<CatalogTypeDto>> GetTypesByPageAsync(int pageIndex, int pageSize)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogTypeRepository.GetTypesByPageAsync(pageIndex, pageSize);
            var data = result.Data.Select(type => _mapper.Map<CatalogTypeDto>(type));
            return new PaginatedItemsResponse<CatalogTypeDto>
            {
                Count = result.TotalCount,
                Data = data.ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<CatalogTypeDto> GetTypeByIdAsync(Guid id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var type = await _catalogTypeRepository.GetTypeByIdAsync(id);
            return _mapper.Map<CatalogTypeDto>(type);
        });
    }
}