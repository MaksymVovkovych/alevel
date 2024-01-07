using System.Net;
using Catalog.Host.Services.Interfaces;
using Catalog.Host.Services.Interfaces.AddResponses;
using Catalog.Host.Services.Interfaces.DeleteRequests;
using Catalog.Host.Services.Interfaces.UpdateRequests;
using Catalog.Host.Services.Interfaces.UpdateResponses;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogTypeController : ControllerBase
{
    private readonly ILogger<CatalogTypeController> _logger;
    private readonly ICatalogTypeService _catalogTypeService;

    public CatalogTypeController(
        ILogger<CatalogTypeController> logger,
        ICatalogTypeService catalogTypeService)
    {
        _logger = logger;
        _catalogTypeService = catalogTypeService;
    }

    [HttpGet("types")]
    public async Task<IActionResult> GetTypesByPage(int pageIndex = 1, int pageSize = 10)
    {
        var result = await _catalogTypeService.GetByPageAsyncHttpGet(pageIndex, pageSize);
        return Ok(result);
    }

    [HttpPost("types")]
    [ProducesResponseType(typeof(AddCatalogTypeResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddType(AddCatalogTypeRequest request)
    {
        var result = await _catalogTypeService.AddAsync(request);
        return Ok(new AddCatalogTypeResponse<Guid?>() { Id = result });
    }

    [HttpPut("types/{id}")]
    [ProducesResponseType(typeof(UpdateCatalogTypeResponse<int>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateType(Guid id, UpdateCatalogTypeRequest request)
    {
        var result = await _catalogTypeService.UpdateAsync(request);
        return Ok(result);
    }

    [HttpDelete("types/{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteType(Guid id)
    {
        try
        {
            await _catalogTypeService.DeleteAsync(new DeleteCatalogTypeRequest() { Id = id });
            return Ok("Type successfully deleted");
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Type not found");
        }
    }
}