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

    public async Task<int> CreateCatalogItem(CatalogItem item)
    {
        return await Create(item);
    }

    public async Task<int> DeleteCatalogItem(CatalogItem item)
    {
        return  await Delete(item);
    }

    public async Task<int> UpdateCatalogItem(CatalogItem item)
    {
        return await Update(item);
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