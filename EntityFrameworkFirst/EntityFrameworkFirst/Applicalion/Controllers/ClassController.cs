using EntityFrameworkFirst.Applicalion.DTOs;
using EntityFrameworkFirst.Domain.Entities;
using EntityFrameworkFirst.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkFirst.Applicalion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        public ClassController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllAsync()
        {
            var classes = await _repositoryManager.RepositoryClass.GetAllClassesAsync();
            return Ok(classes);

        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var @class = await _repositoryManager.RepositoryClass.GetClassAsync(id);
            if (@class == null)
                return NotFound();
            return Ok(@class);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ClassDto classParamiter)
        {
            var classId = Guid.NewGuid();
            var @class = new Class
            {
                Id = classId,
                ClassNumber = classParamiter.ClassNumber,
                Capacity = classParamiter.Capacity,
            };
            await _repositoryManager.RepositoryClass.CreateClassAsync(@class);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeAsync([FromRoute] Guid id, [FromBody] ClassDto classParamiter)
        {
            var @class = await _repositoryManager.RepositoryClass.GetClassAsync(id);
            if (@class == null)
                return NotFound();

            @class.ClassNumber = classParamiter.ClassNumber;
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok(@class);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            var @class = await _repositoryManager.RepositoryClass.GetClassAsync(Id);
            if (@class == null)
                return NotFound();

            await _repositoryManager.RepositoryClass.DeleteClassAsync(@class);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return StatusCode(204);
        }

    }
}
