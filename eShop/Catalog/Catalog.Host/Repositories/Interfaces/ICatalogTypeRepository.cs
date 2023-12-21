using Catalog.Host.Data.Entity;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogTypeRepository
{
    Task<int> CreateCatalogType(CatalogType brand);
    Task<int> DeleteCatalogType(CatalogType brand);
    Task<int> UpdateCatalogType(CatalogType brand);
    Task<IEnumerable<CatalogType>> GetTypes();
    
    Task<CatalogType> GetTypeById(Guid id);
}