using AutoMapper;
using Catalog.Host.Configurations;
using Catalog.Host.Data.Entity;
using Catalog.Host.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Catalog.Host.Controllers;


[Authorize]
[ApiController]
[Route("[controller]")]
public class CatalogBffController : ControllerBase
{
    private readonly ILogger<CatalogBffController> _logger;
    private readonly ICatalogBffService _catalogService;
    private readonly IOptions<CatalogConfig> _config;
    private readonly IMapper _mapper;

    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogBffService catalogService,
        IOptions<CatalogConfig> config,
        IMapper mapper)
    {
        _logger = logger;
        _catalogService = catalogService;
        _config = config;
        _mapper = mapper;
    }

    [HttpPost("items")]
    [AllowAnonymous]
    public async Task<IActionResult> GetItemsByPageAsync([FromBody] PaginatedItemsRequest request)
    {
        var item = new CatalogItem
        {
            Id = Guid.NewGuid(), AvailableStock = 100, Description = "Prism White T-Shirt",
            Name = "Prism White T-Shirt", Price = 12, PictureFileName = "3.png"
        };

        var getItemDto = _mapper.Map<CatalogGetItemDto>(item);
        
        var result = await _catalogService.GetCatalogItemsAsync(request);
        
        return Ok(result);
    }

    [HttpGet("item/{id}")]
    public async Task<IActionResult> GetItemByIdAsync(Guid id)
    {
        
        
        var result = await _catalogService.GetItemByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("items/brand/{brandId}")]
    public async Task<IActionResult> GetItemsByBrandAsync(Guid brandId)
    {
        var result = await _catalogService.GetItemsByBrandAsync(brandId);
        return Ok(result);
    }

    [HttpGet("items/type/{typeId}")]
    public async Task<IActionResult> GetItemsByTypeAsync(Guid typeId)
    {
        var result = await _catalogService.GetItemsByTypeAsync(typeId);
        return Ok(result);
    }

    //Brand
    [HttpGet("brand/{id}")]
    public async Task<IActionResult> GetBrandByIdAsync(Guid id)
    {
        var result = await _catalogService.GetBrandByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("brands")]
    [AllowAnonymous]
    public async Task<IActionResult> GetBrandsByPageAsync([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _catalogService.GetBrandsByPageAsync(pageIndex, pageSize);
        return Ok(result);
    }

    //Type
    [HttpGet("type/{id}")]
    public async Task<IActionResult> GetTypeByIdAsync(Guid id)
    {
        var result = await _catalogService.GetTypeByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("types")]
    [AllowAnonymous]
    public async Task<IActionResult> GetTypesByPageAsync([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _catalogService.GetTypesByPageAsync(pageIndex, pageSize);
        return Ok(result);
    }
}