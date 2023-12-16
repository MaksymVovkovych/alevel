using Catalog.Host.Data.Entity;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogBrandRepository
{
    Task CreateCatalogBrand(CatalogBrand brand);
    Task DeleteCatalogBrand(CatalogBrand brand);
    Task UpdateCatalogBrand(CatalogBrand brand);
    Task<IEnumerable<CatalogBrand>>  GetBrands();

    Task<CatalogBrand> GetBrandById(Guid id);
}