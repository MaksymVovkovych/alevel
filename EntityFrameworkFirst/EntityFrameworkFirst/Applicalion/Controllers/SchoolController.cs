using EntityFrameworkFirst.Applicalion.DTOs;
using EntityFrameworkFirst.Domain.Entities;
using EntityFrameworkFirst.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkFirst.Applicalion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        public SchoolController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var schools = await _repositoryManager.RepositorySchool.GetAllSchoolsAsync();
            schools.OrderByDescending(sch => sch.CaptionOfSchool);
            return Ok(schools);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(Guid schoolId)
        {
            var school = await _repositoryManager.RepositorySchool.GetSchoolAsync(schoolId);
            if (school == null)
                return NotFound();
            return Ok(school);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SchoolDto schoolDto)
        {
            var schoolId = Guid.NewGuid();
            var school = new School
            {
                Id = schoolId,
                Address = schoolDto.Address,
                CaptionOfSchool = schoolDto.CaptionOfSchool
            };
            await _repositoryManager.RepositorySchool.CreateSchoolAsync(school);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(Guid schoolId)
        {
            var school = await _repositoryManager.RepositorySchool.GetSchoolAsync(schoolId);
            if (school == null)
                return NotFound();

            await _repositoryManager.RepositorySchool.DeleteSchoolAsync(school);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeAsync([FromRoute] Guid id, [FromBody] SchoolDto schoolDto)
        {
            var school = await _repositoryManager.RepositorySchool.GetSchoolAsync(id);
            if (school == null)
                return NotFound();

            await _repositoryManager.RepositorySchool.UpdateSchoolAsync(school);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok(school);
        }

        [HttpPut("{id}/class")]
        public async Task<IActionResult> AddCLassesAsync(
            [FromRoute] Guid id, ICollection<Class> classes
            )
        {
            await _repositoryManager.RepositorySchool.AddClasses(id, classes);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok(classes);
        }

    }
}
