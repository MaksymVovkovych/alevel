using Catalog.Host.Data.Entity;
using Catalog.Host.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogBffController : ControllerBase
{
    private readonly ICatalogBffRepository _catalogBffRepository;
    private readonly ICatalogTypeRepository _catalogTypeRepository;
    private readonly ICatalogBrandRepository _catalogBrandRepository;
    private readonly ICatalogItemRepository _catalogItemRepository;
    public CatalogBffController(
        ICatalogBffRepository catalogBffRepository,
        ICatalogTypeRepository catalogTypeRepository,
        ICatalogBrandRepository catalogBrandRepository,
        ICatalogItemRepository catalogItemRepository)
    {
        _catalogBffRepository = catalogBffRepository;
        _catalogBrandRepository = catalogBrandRepository;
        _catalogItemRepository = catalogItemRepository;
        _catalogTypeRepository = catalogTypeRepository;
    }

    [HttpGet("Items")]
    public async Task<IEnumerable<CatalogItem>> GetItems()
    {  
        return await _catalogItemRepository.GetItems();
    
    }
    
    [HttpGet("Brands")]
    public async Task<IEnumerable<CatalogBrand>> GetBrands()
    {
        return await _catalogBrandRepository.GetBrands();
    }
    
    [HttpGet("Types")]
    public async Task<IEnumerable<CatalogType>> GetTypes()
    {
        return await _catalogTypeRepository.GetTypes();
    }
    
    [HttpGet("ByBrand")]
    public async Task<ActionResult<CatalogItem>> GetItemByBrand(string catalogBrandName)
    {
        var item =  await _catalogBffRepository.GetCatalogItemByCatalogBrand(catalogBrandName);
        if (item == null)
        {
            return StatusCode(404);
        }
        return item;
    }
    
    [HttpGet("ById")]
    public async Task<ActionResult<CatalogItem>> GetItemById(Guid id)
    {
        var item =  await _catalogBffRepository.GetCatalogItemById(id);
        if (item == null)
        {
            return StatusCode(404);
        }
        return item;
    }
    
    [HttpGet("ByType")]
    public async Task<ActionResult<CatalogItem>> GetItemByType(string catalogTypeName)
    {
        var item =  await _catalogBffRepository.GetCatalogTypeByCatalogType(catalogTypeName);
        if (item == null)
        {
            return StatusCode(404);
        }
        return item;
    }
}