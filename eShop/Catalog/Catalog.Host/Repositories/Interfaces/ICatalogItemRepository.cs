using Catalog.Host.Data.Entity;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<int> CreateCatalogItem(CatalogItem brand);
    Task<int> DeleteCatalogItem(CatalogItem brand);
    Task<int> UpdateCatalogItem(CatalogItem brand);
    Task<IEnumerable<CatalogItem>> GetItems();
    
    Task<CatalogItem> GetItemById(Guid id);
}