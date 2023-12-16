using Catalog.Host.Data.Entity;
using Catalog.Host.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogTypeController : ControllerBase
{
    private readonly ICatalogTypeRepository _catalogTypeRepository;

    public CatalogTypeController(ICatalogTypeRepository catalogTypeRepository)
    {
        _catalogTypeRepository = catalogTypeRepository;

    }

    [HttpPost]
    public async Task<ActionResult<CatalogType>> PostType([FromBody] CatalogType catalogType)
    {
        var guid = Guid.NewGuid();
        catalogType.Id = guid;
        await _catalogTypeRepository.CreateCatalogType(catalogType); 
        return Ok(catalogType);
    }
    
    [HttpPut]
    public async Task<ActionResult<CatalogType>> PutType([FromBody] CatalogBrand catalogType)
    {
        var type = await _catalogTypeRepository.GetTypeById(catalogType.Id);
        if (type == null)
        {
            return StatusCode(404);
        }

        await _catalogTypeRepository.UpdateCatalogType(type);
        return type;
    }
    
    [HttpDelete]
    public async Task<ActionResult<CatalogType>> DeleteType(Guid id)
    {
        var type = await _catalogTypeRepository.GetTypeById(id);
        if (type == null)
        {
            return StatusCode(404);
        }

        await _catalogTypeRepository.DeleteCatalogType(type);
        return type;
    }
}