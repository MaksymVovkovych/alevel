using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly Product[] _products = new[]
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product#1",
                Quantity = 1,
                Avatar = "awfwwaf"
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product#1",
                Quantity = 1,
                Avatar = "awfwwaf"
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product#1",
                Quantity = 1,
                Avatar = "awfwwaf"
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product#1",
                Quantity = 1,
                Avatar = "awfwwaf"
            },
        };


        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> Get()
        {
            return _products;
        }
    }
}