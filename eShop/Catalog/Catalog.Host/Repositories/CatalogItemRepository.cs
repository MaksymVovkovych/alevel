using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogItemRepository : BaseRepository<CatalogItem>, ICatalogItemRepository
{
    public CatalogItemRepository(AppDbContext appContext) : base(appContext)
    {
    }

    public async Task CreateCatalogItem(CatalogItem item)
    {
        await Create(item);
    }

    public async Task DeleteCatalogItem(CatalogItem item)
    {
        await Delete(item);
    }

    public async Task UpdateCatalogItem(CatalogItem item)
    {
        await Update(item);
    }
    public async Task<IEnumerable<CatalogItem>> GetItems()
    {
        return await FindAll().ToListAsync();
    }
    
    public async Task<CatalogItem?> GetItemById(Guid id)
    {
        return await FindByCondition(x => x.Id == id)
            .FirstOrDefaultAsync();
    }
}