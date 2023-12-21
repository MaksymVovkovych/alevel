using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogBrandRepository : BaseRepository<CatalogBrand>, ICatalogBrandRepository
{
    public CatalogBrandRepository(AppDbContext appContext) : base(appContext)
    {
    }

    public async Task<int> CreateCatalogBrand(CatalogBrand brand)
    {
        return await Create(brand);
    }

    public async Task<int> DeleteCatalogBrand(CatalogBrand brand)
    {
        return await Delete(brand);
    }

    public async Task<int> UpdateCatalogBrand(CatalogBrand brand)
    {
        return await Update(brand);
    }
    
    public async Task<IEnumerable<CatalogBrand>> GetBrands()
    {
        return await FindAll().ToListAsync();
    }

    public async Task<CatalogBrand?> GetBrandById(Guid id)
    {
        return await FindByCondition(x => x.Id == id)
            .FirstOrDefaultAsync();
    }
}