using Catalog.Host.Data.Entity;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogTypeRepository
{
    Task CreateCatalogType(CatalogType brand);
    Task DeleteCatalogType(CatalogType brand);
    Task UpdateCatalogType(CatalogType brand);
    Task<IEnumerable<CatalogType>> GetTypes();
    
    Task<CatalogType> GetTypeById(Guid id);
}