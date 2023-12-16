using Catalog.Host.Data.Entity;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task CreateCatalogItem(CatalogItem brand);
    Task DeleteCatalogItem(CatalogItem brand);
    Task UpdateCatalogItem(CatalogItem brand);
    Task<IEnumerable<CatalogItem>> GetItems();
    
    Task<CatalogItem> GetItemById(Guid id);
}