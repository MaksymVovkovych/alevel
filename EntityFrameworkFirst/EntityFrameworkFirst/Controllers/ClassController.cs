using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkFirst.Repositories;
using EntityFrameworkFirst.Entities;
using Azure.Core;

namespace EntityFrameworkFirst.Controllers
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

        public async Task<IActionResult> GetAllClassesAsync()
        {
            var classes = await _repositoryManager.RepositoryClass.GetAllClassesAsync();
            return Ok(classes);
        }
        [HttpGet("id")]

        public async Task<IActionResult> GetClassById(Guid id)
        {
            var @class = await _repositoryManager.RepositoryClass.GetClassAsync(id);
            if(@class == null) 
                return NotFound();
            return Ok(@class);
        }
        [HttpPost]

        public async Task<IActionResult> PostClass([FromBody]Class classParamiter)
        {
            var classId = Guid.NewGuid();
            var @class = new Class { Id = classId, ClassNumber = classParamiter.ClassNumber };
            await _repositoryManager.RepositoryClass.CreateClassAsync(@class);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return StatusCode(201);
        }

        //[HttpPut]

        //public async Task<IActionResult> ChangeClass([FromBody] Class classParamiter)
        //{
        //    var @class = await _repositoryManager.RepositoryClass.GetClassAsync(classParamiter.Id);
        //    if(@class == null)
        //        return NotFound();

        //    @class.ClassNumber = classParamiter.ClassNumber;
        //}
        
    }
}
