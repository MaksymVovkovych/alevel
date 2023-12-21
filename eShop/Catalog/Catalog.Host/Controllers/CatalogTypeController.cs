using AutoMapper;
using Catalog.Host.Data.Entity;
using Catalog.Host.Models.DTOs;
using Catalog.Host.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogTypeController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICatalogTypeRepository _catalogTypeRepository;

    public CatalogTypeController(ICatalogTypeRepository catalogTypeRepository, IMapper mapper)
    {
        
        _mapper = mapper;
        _catalogTypeRepository = catalogTypeRepository;

    }

    [HttpPost]
    public async Task<ActionResult<CatalogType>> PostType([FromBody] CatalogType catalogType)
    {
        var guid = Guid.NewGuid();
        catalogType.Id = guid;
        var result = await _catalogTypeRepository.CreateCatalogType(catalogType); 
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<CatalogType>> PutType([FromBody] CatalogTypeDto catalogTypeDto)
    {
        var brand = await _catalogTypeRepository.GetTypeById(catalogTypeDto.Id);

        if (brand != null)
        {
            _mapper.Map(catalogTypeDto, brand); // Use mapping to update the existing object
            var result = await _catalogTypeRepository.UpdateCatalogType(brand);
            return Ok(result);
        }
        else
        {
            return NotFound(); // Return a 404 Not Found status code
        }
    }
    
    [HttpDelete]
    public async Task<ActionResult<CatalogType>> DeleteType(Guid id)
    {
        var type = await _catalogTypeRepository.GetTypeById(id);
        if (type == null)
        {
            return StatusCode(404);
        }

        var result = await _catalogTypeRepository.DeleteCatalogType(type);
        return Ok(result);
    }
}