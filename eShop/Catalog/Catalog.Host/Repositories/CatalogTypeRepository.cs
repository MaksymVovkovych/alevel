using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogTypeRepository : BaseRepository<CatalogType>, ICatalogTypeRepository
{
    public CatalogTypeRepository(AppDbContext appContext) : base(appContext)
    {
    }

    public async Task<int> CreateCatalogType(CatalogType type)
    {
        return  await Create(type);
    }

    public async Task<int> DeleteCatalogType(CatalogType type)
    {
        return await Delete(type);
    }

    public async Task<int> UpdateCatalogType(CatalogType type)
    {
        return await Update(type);
    }
    public async Task<IEnumerable<CatalogType>> GetTypes()
    {
        return await FindAll().ToListAsync();
    }
    
    public async Task<CatalogType?> GetTypeById(Guid id)
    {
        return await FindByCondition(x => x.Id == id)
            .FirstOrDefaultAsync();
    }
}