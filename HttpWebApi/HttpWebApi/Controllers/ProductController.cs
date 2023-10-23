using HttpWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HttpWebApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _prosuctRepository;

        public ProductController(IProductRepository prosuctRepository)
        {
            _prosuctRepository = prosuctRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _prosuctRepository.GetAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _prosuctRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return StatusCode(404);
            }
            return Ok(product.Value.Item2);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product reqest)
        {
            var productId = Guid.NewGuid();
            var product = new Product
            {
                Id = productId,
                Name = reqest.Name,
                Category = reqest.Category,
                Count = reqest.Count
            };
            await _prosuctRepository.PostProductAsync(product);
            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Product request)
        {
            var product = _prosuctRepository.GetProductByIdAsync(request.Id);
            if (product == null)
            {
                return NotFound();
            }

            product.Result.Value.Item2.Name = request.Name;
            product.Result.Value.Item2.Category = request.Category;
            product.Result.Value.Item2.Count = request.Count;
            await _prosuctRepository.UpdateAsync(product.Result.Value.Item2);

            return Ok(product.Result.Value.Item2);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var product = _prosuctRepository.GetProductByIdAsync(Id);
            if (product == null)
            {
                return NotFound();
            }
            await _prosuctRepository.DeleteAsync(Id);
            return Ok();
        }
    }
}
