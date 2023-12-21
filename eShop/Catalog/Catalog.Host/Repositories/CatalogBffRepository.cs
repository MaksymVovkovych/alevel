using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Repositories.Interfaces;
using System.Collections.Immutable;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogBffRepository : BaseRepository<CatalogItem> , ICatalogBffRepository
{
    public CatalogBffRepository(AppDbContext appContext) : base(appContext)
    {
    }

    public async Task<CatalogItem?> GetCatalogItemById(Guid id)
    {
        return await FindByCondition(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<CatalogItem?> GetCatalogItemByCatalogBrand(Guid id)
    {
        return await FindByCondition(x => x.CatalogBrandId == id)
            .FirstOrDefaultAsync();
    }

    public async Task<CatalogItem?> GetCatalogTypeByCatalogType(Guid id)
    {
        return await FindByCondition(x => x.CatalogTypeId == id)
            .FirstOrDefaultAsync();
    }


}