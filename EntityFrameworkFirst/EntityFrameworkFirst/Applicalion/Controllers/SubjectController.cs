using EntityFrameworkFirst.Applicalion.DTOs;
using EntityFrameworkFirst.Domain.Entities;
using EntityFrameworkFirst.Domain.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkFirst.Applicalion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        public SubjectController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllSubjectsAsync()
        {
            var subjects = await _repositoryManager.RepositorySubject.GetAllSubjectsAsync();
            return Ok(subjects);
        }
        [HttpGet("id")]

        public async Task<IActionResult> GetSubjectById(Guid subjectId)
        {
            var subject = await _repositoryManager.RepositorySubject.GetSubjectAsync(subjectId);
            if (subject == null)
                return NotFound();
            return Ok(subject);
        }
        [HttpPost]

        public async Task<IActionResult> PostSubject([FromBody] SubjectDto subject)
        {
            var classId = Guid.NewGuid();
            var sub = new Subject { Id = classId, SubjectName = subject.SubjectName };
            await _repositoryManager.RepositorySubject.CreateSubjectAsync(sub);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpDelete("id")]

        public async Task<IActionResult> DeleteSubject(Guid subjectId)
        {
            var subject = await _repositoryManager.RepositorySubject.GetSubjectAsync(subjectId);
            if (subject == null)
                return NotFound();

            await _repositoryManager.RepositorySubject.DeleteSubjectAsync(subject);
            return StatusCode(204);
        }

        [HttpPut]

        public async Task<IActionResult> ChangeSubject(SubjectDto subject)
        {
            var sub = await _repositoryManager.RepositorySubject.GetSubjectAsync(subject.Id);
            if (sub == null)
                return NotFound();

            await _repositoryManager.RepositorySubject.UpdateSubjectAsync(sub);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok(sub);
        }
    }
}
