using Catalog.Host.Data.Entity;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogBffRepository
{
    Task<CatalogItem?> GetCatalogItemById(Guid id);
    Task<CatalogItem?> GetCatalogItemByCatalogBrand(string catalogBrandName);
    Task<CatalogItem?> GetCatalogTypeByCatalogType(string catalogTypeName);

}