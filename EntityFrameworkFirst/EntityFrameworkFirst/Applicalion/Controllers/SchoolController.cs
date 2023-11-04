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

        public async Task<IActionResult> GetAllSchoolsAsync()
        {
            var schools = await _repositoryManager.RepositorySchool.GetAllSchoolsAsync();
            return Ok(schools);
        }
        [HttpGet("id")]

        public async Task<IActionResult> GetSchoolById(Guid schoolId)
        {
            var school = await _repositoryManager.RepositorySchool.GetSchoolAsync(schoolId);
            if (school == null)
                return NotFound();
            return Ok(school);
        }
        [HttpPost]

        public async Task<IActionResult> PostSchool([FromBody] SchoolDto schoolDto)
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

        public async Task<IActionResult> DeleteSchool(Guid schoolId)
        {
            var school = await _repositoryManager.RepositorySchool.GetSchoolAsync(schoolId);
            if (school == null)
                return NotFound();

            await _repositoryManager.RepositorySchool.DeleteSchoolAsync(school);
            return StatusCode(204);
        }

        [HttpPut]

        public async Task<IActionResult> ChangeSchool([FromBody] SchoolDto schoolDto)
        {
            var school = await _repositoryManager.RepositorySchool.GetSchoolAsync(schoolDto.Id);
            if (school == null)
                return NotFound();

            await _repositoryManager.RepositorySchool.UpdateSchoolAsync(school);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok(school);
        }
    }
}
