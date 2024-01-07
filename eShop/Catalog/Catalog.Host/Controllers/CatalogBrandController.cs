using System.Net;
using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Models.DTOs;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Catalog.Host.Services.Interfaces.AddResponses;
using Catalog.Host.Services.Interfaces.DeleteRequests;
using Catalog.Host.Services.Interfaces.UpdateRequests;
using Catalog.Host.Services.Interfaces.UpdateResponses;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;


[ApiController]
[Route("[controller]")]

public class CatalogBrandController : ControllerBase
{
    private readonly ILogger<CatalogBrandController> _logger;
    private readonly ICatalogBrandService _catalogBrandService;

    public CatalogBrandController(
        ILogger<CatalogBrandController> logger,
        ICatalogBrandService catalogBrandService)
    {
        _logger = logger;
        _catalogBrandService = catalogBrandService;
    }

    [HttpGet("brands")]
    public async Task<IActionResult> GetBrandsByPage(int pageIndex = 1, int pageSize = 10)
    {
        var result = await _catalogBrandService.GetByPageAsyncHttpGet(pageIndex, pageSize);
        return Ok(result);
    }

    [HttpPost("brands")]
    [ProducesResponseType(typeof(AddCatalogBrandResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddBrand(AddCatalogBrandRequest request)
    {
        var result = await _catalogBrandService.AddAsync(request);
        return Ok(new AddCatalogBrandResponse<Guid?>() { Id = result });
    }

    [HttpPut("brands/{id}")]
    [ProducesResponseType(typeof(UpdateCatalogBrandResponse<int>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateBrand(Guid id, UpdateCatalogBrandRequest request)
    {
        var result = await _catalogBrandService.UpdateAsync(request);
        return Ok(result);
    }

    [HttpDelete("brands/{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteBrand(Guid id)
    {
        try
        {
            await _catalogBrandService.DeleteAsync(new DeleteCatalogBrandRequest { Id = id });
            return Ok("Brand successfully deleted");
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Brand not found");
        }
    }
}