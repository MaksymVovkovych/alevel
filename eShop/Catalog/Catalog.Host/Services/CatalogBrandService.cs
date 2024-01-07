using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.DTOs;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Catalog.Host.Services.Interfaces.AddResponses;
using Catalog.Host.Services.Interfaces.DeleteRequests;
using Catalog.Host.Services.Interfaces.UpdateRequests;
using Catalog.Host.Services.Interfaces.UpdateResponses;

namespace Catalog.Host.Services;

public class CatalogBrandService : BaseDataService<AppDbContext>, ICatalogBrandService
{
    private readonly ICatalogBrandRepository _catalogBrandRepository;
    private readonly IMapper _mapper;

    public CatalogBrandService(
        IDbContextWrapper<AppDbContext> dbContextWrapper,
        ILogger<BaseDataService<AppDbContext>> logger,
        ICatalogBrandRepository catalogBrandRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogBrandRepository = catalogBrandRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedItems<CatalogBrandDto>> GetByPageAsyncHttpGet(int pageIndex, int pageSize)
    {
        var result = await _catalogBrandRepository.GetByPageAsyncHttpGet(pageIndex, pageSize);

        var data = result.Data.Select(item => new CatalogBrandDto
        {
            Id = item.Id,
            Brand = item.Brand
        });

        return new PaginatedItems<CatalogBrandDto>
        {
            TotalCount = result.TotalCount,
            Data = data
        };
    }

    public Task<Guid?> AddAsync(AddCatalogBrandRequest addCatalogBrand)
    {
        return ExecuteSafeAsync(() => _catalogBrandRepository.AddAsync(addCatalogBrand));
    }

    public async Task<UpdateCatalogBrandResponse<int>> UpdateAsync(UpdateCatalogBrandRequest updateCatalogBrand)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var brand = await _catalogBrandRepository.UpdateAsync(updateCatalogBrand);
            return new UpdateCatalogBrandResponse<int>
            {
                Brand = _mapper.Map<CatalogBrandDto>(brand)
            };
        });
    }

    public Task DeleteAsync(DeleteCatalogBrandRequest deleteCatalogBrand)
    {
        return ExecuteSafeAsync(() => _catalogBrandRepository.DeleteAsync(deleteCatalogBrand));
    }
}