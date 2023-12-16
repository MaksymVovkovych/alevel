using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogItemController : ControllerBase
{
    private readonly ICatalogItemRepository _catalogItemRepository;

    public CatalogItemController(ICatalogItemRepository catalogItemRepository)
    {
        _catalogItemRepository = catalogItemRepository;

    }

    [HttpPost]
    public async Task<ActionResult<CatalogItem>> PostItem([FromBody] CatalogItem catalogItem)
    {
        var guid = Guid.NewGuid();
        catalogItem.Id = guid;
        await _catalogItemRepository.CreateCatalogItem(catalogItem); 
        return Ok(catalogItem);
    }
    
    [HttpPut]
    public async Task<ActionResult<CatalogItem>> PutItem([FromBody] CatalogItem catalogItem)
    {
        var item = await _catalogItemRepository.GetItemById(catalogItem.Id);
        if (item == null)
        {
            return StatusCode(404);
        }

        await _catalogItemRepository.UpdateCatalogItem(item);
        return item;
    }
    
    [HttpDelete]
    public async Task<ActionResult<CatalogItem>> DeleteItem(Guid id)
    {
        var item = await _catalogItemRepository.GetItemById(id);
        if (item == null)
        {
            return StatusCode(404);
        }

        await _catalogItemRepository.DeleteCatalogItem(item);
        return item;
    }
}