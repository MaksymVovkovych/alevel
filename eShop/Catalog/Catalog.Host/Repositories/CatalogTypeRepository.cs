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

    public async Task CreateCatalogType(CatalogType type)
    {
        await Create(type);
    }

    public async Task DeleteCatalogType(CatalogType type)
    {
         await Delete(type);
    }

    public async Task UpdateCatalogType(CatalogType type)
    {
        await Update(type);
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