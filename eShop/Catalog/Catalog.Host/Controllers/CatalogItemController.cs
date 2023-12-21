using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Models.DTOs;
using Catalog.Host.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogItemController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICatalogItemRepository _catalogItemRepository;

    public CatalogItemController(ICatalogItemRepository catalogItemRepository, IMapper mapper)
    {
        _mapper = mapper;
        _catalogItemRepository = catalogItemRepository;

    }

    [HttpPost]
    public async Task<ActionResult<CatalogItem>> PostItem([FromBody] CatalogItem catalogItem)
    {
        var guid = Guid.NewGuid();
        catalogItem.Id = guid;
        var result = await _catalogItemRepository.CreateCatalogItem(catalogItem); 
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<CatalogItem>> PutItem([FromBody] CatalogItemDto catalogItemDto)
    {
        var brand = await _catalogItemRepository.GetItemById(catalogItemDto.Id);

        if (brand != null)
        {
            _mapper.Map(catalogItemDto, brand); // Use mapping to update the existing object
            var result = await _catalogItemRepository.UpdateCatalogItem(brand);
            return Ok(result);
        }
        else
        {
            return NotFound(); // Return a 404 Not Found status code
        }
    }
    
    [HttpDelete]
    public async Task<ActionResult<CatalogItem>> DeleteItem(Guid id)
    {
        var item = await _catalogItemRepository.GetItemById(id);
        if (item == null)
        {
            return StatusCode(404);
        }

        var result = await _catalogItemRepository.DeleteCatalogItem(item);
        return Ok(result);
    }
}