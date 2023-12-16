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

    public async Task<CatalogItem?> GetCatalogItemByCatalogBrand(string catalogBrandName)
    {
        return await FindByCondition(x => x.CatalogBrand.Brand == catalogBrandName)
            .FirstOrDefaultAsync();
    }

    public async Task<CatalogItem?> GetCatalogTypeByCatalogType(string catalogTypeName)
    {
        return await FindByCondition(x => x.CatalogType.Type == catalogTypeName)
            .FirstOrDefaultAsync();
    }


}