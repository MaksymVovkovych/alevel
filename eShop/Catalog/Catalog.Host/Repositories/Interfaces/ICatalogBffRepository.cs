using Catalog.Host.Data.Entity;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogBffRepository
{
    Task<CatalogItem?> GetCatalogItemById(Guid id);
    Task<CatalogItem?> GetCatalogItemByCatalogBrand(Guid id);
    Task<CatalogItem?> GetCatalogTypeByCatalogType(Guid id);

}