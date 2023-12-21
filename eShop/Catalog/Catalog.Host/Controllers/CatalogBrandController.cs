using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Models.DTOs;
using Catalog.Host.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;


[ApiController]
[Route("[controller]")]

public class CatalogBrandController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICatalogBrandRepository _catalogBrandRepository;

    public CatalogBrandController(ICatalogBrandRepository catalogBrandRepository, IMapper mapper)
    {
        _mapper = mapper;
        _catalogBrandRepository = catalogBrandRepository;

    }

    [HttpPost]
    public async Task<ActionResult<CatalogBrand>> PostBrand([FromBody] CatalogBrand catalogBrand)
    {
        var guid = Guid.NewGuid();
        catalogBrand.Id = guid;
        var result = await _catalogBrandRepository.CreateCatalogBrand(catalogBrand); 
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<CatalogBrand>> PutBrand([FromBody]CatalogBrandDto catalogBrandDto)
    {
        var brand = await _catalogBrandRepository.GetBrandById(catalogBrandDto.Id);

        if (brand != null)
        {
            _mapper.Map(catalogBrandDto, brand); // Use mapping to update the existing object
            var result = await _catalogBrandRepository.UpdateCatalogBrand(brand);
            return Ok(result);
        }
        else
        {
            return NotFound(); // Return a 404 Not Found status code
        }
    }
    
    [HttpDelete]
    public async Task<ActionResult<CatalogBrand>> DeleteBrand(Guid id)
    {
        var brand = await _catalogBrandRepository.GetBrandById(id);
        if (brand == null)
        {
            return StatusCode(404);
        }

        var result = await _catalogBrandRepository.DeleteCatalogBrand(brand);
        return Ok(result);
    }
    
}