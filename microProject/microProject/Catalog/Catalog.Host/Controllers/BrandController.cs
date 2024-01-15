using Catalog.Host.Data.Entity;
using Catalog.Host.Mapping;
using Catalog.Host.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;




[ApiController]
[Route("[controller]")]
public class BrandController : ControllerBase
{
    private  readonly IBrandService _brandService;
    
    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }
    
    [HttpGet]
    public async Task<IQueryable<Brand>> GetBrands()
    {
        return _brandService.GetBrands();
    }
    
    [HttpGet("ById")]
    public async Task<Brand?> GetBrandByIdAsync(int id)
    {
        return await _brandService.GetBrandById(id);
    }

    [HttpPost]
    public async Task<Brand> PostBrandAsync(BrandDto brandDto)
    {
        return await _brandService.CreateBrand(brandDto);
    }
    
    [HttpPut]
    public async Task<Brand> UpdateBrandAsync(int id, BrandDto brandDto)
    {

        return await _brandService.UpdateBrand(id, brandDto);
    }
    
    [HttpDelete]
    public async Task<Brand> DeleteBrandrAsync(int id)
    {
        return await _brandService.DaleteBrand(id);
    }
}