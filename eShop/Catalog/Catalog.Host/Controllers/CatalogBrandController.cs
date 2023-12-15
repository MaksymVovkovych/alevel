using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;


[ApiController]
[Route("[controller]")]

public class CatalogBrandController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public CatalogBrandController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public  IActionResult GetBrands()
    {
        return Ok(new CatalogBrand(){Id= Guid.NewGuid(), Brand = "Nike"});
    }
}