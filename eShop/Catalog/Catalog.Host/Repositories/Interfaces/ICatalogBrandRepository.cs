using Catalog.Host.Data.Entity;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogBrandRepository
{
    Task<int> CreateCatalogBrand(CatalogBrand brand);
    Task<int> DeleteCatalogBrand(CatalogBrand brand);
    Task<int> UpdateCatalogBrand(CatalogBrand brand);
    Task<IEnumerable<CatalogBrand>>  GetBrands();

    Task<CatalogBrand> GetBrandById(Guid id);
}