using Catalog.Host.Data.Entity;
using Catalog.Host.Mapping;

namespace Catalog.Host.Services.Interfaces.Interfaces;

public interface IBrandService
{
    Task<Brand> CreateBrand(BrandDto brandDto);
    Task<Brand> UpdateBrand(int id, BrandDto brandDto);
    Task<Brand> DaleteBrand(int id);
    IQueryable<Brand> GetBrands();
    Task<Brand?> GetBrandById(int id);
    
    
}