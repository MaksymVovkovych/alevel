using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;


[ApiController]
[Route("[controller]")]

public class CatalogBrandController : ControllerBase
{
    private readonly ICatalogBrandRepository _catalogBrandRepository;

    public CatalogBrandController(ICatalogBrandRepository catalogBrandRepository)
    {
        _catalogBrandRepository = catalogBrandRepository;

    }

    [HttpPost]
    public async Task<ActionResult<CatalogBrand>> PostBrand([FromBody] CatalogBrand catalogBrand)
    {
        var guid = Guid.NewGuid();
        catalogBrand.Id = guid;
        await _catalogBrandRepository.CreateCatalogBrand(catalogBrand); 
        return Ok(catalogBrand);
    }
    
    [HttpPut]
    public async Task<ActionResult<CatalogBrand>> PutBrand([FromBody] CatalogBrand catalogBrand)
    {
        var brand = await _catalogBrandRepository.GetBrandById(catalogBrand.Id);
        if (brand == null)
        {
            return StatusCode(404);
        }

        await _catalogBrandRepository.UpdateCatalogBrand(brand);
        return brand;
    }
    
    [HttpDelete]
    public async Task<ActionResult<CatalogBrand>> DeleteBrand(Guid id)
    {
        var brand = await _catalogBrandRepository.GetBrandById(id);
        if (brand == null)
        {
            return StatusCode(404);
        }

        await _catalogBrandRepository.DeleteCatalogBrand(brand);
        return brand;
    }
    
}