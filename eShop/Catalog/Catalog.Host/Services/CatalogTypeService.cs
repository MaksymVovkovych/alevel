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

public class CatalogTypeService : BaseDataService<AppDbContext>, ICatalogTypeService
{
    private readonly ICatalogTypeRepository _catalogTypeRepository;
    private readonly IMapper _mapper;

    public CatalogTypeService(
        IDbContextWrapper<AppDbContext> dbContextWrapper,
        ILogger<BaseDataService<AppDbContext>> logger,
        ICatalogTypeRepository catalogTypeRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogTypeRepository = catalogTypeRepository;
        _mapper = mapper;
    }

    async Task<PaginatedItems<CatalogTypeDto>> ICatalogTypeService.GetByPageAsyncHttpGet(int pageIndex, int pageSize)
    {
        var result = await _catalogTypeRepository.GetByPageAsyncHttpGet(pageIndex, pageSize);

        var data = result.Data.Select(item => new CatalogTypeDto
        {
            Id = item.Id,
            Type = item.Type
        });

        return new PaginatedItems<CatalogTypeDto>
        {
            TotalCount = result.TotalCount,
            Data = data
        };
    }

    public Task<Guid?> AddAsync(AddCatalogTypeRequest addCatalogType)
    {
        return ExecuteSafeAsync(() => _catalogTypeRepository.AddAsync(addCatalogType));
    }

    public async Task<UpdateCatalogTypeResponse<int>> UpdateAsync(UpdateCatalogTypeRequest updateCatalogType)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var type = await _catalogTypeRepository.UpdateAsync(updateCatalogType);
            return new UpdateCatalogTypeResponse<int>
            {
                Type = _mapper.Map<CatalogTypeDto>(type)
            };
        });
    }

    public Task DeleteAsync(DeleteCatalogTypeRequest deleteCatalogType)
    {
        return ExecuteSafeAsync(() => _catalogTypeRepository.DeleteAsync(deleteCatalogType));
    }
}