using EntityFrameworkFirst.Applicalion.DTOs;
using EntityFrameworkFirst.Domain.Entities;
using EntityFrameworkFirst.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkFirst.Applicalion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public TeacherController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllAsync()
        {
            var teachers = await _repositoryManager.RepositoryTeacher.GetAllTeachersAsync();
            if (teachers == null)
                return NotFound();
            return Ok(teachers);
        }

        [HttpGet("id")]

        public async Task<IActionResult> GetByIdAsync(Guid teacherId)
        {
            var teacher = await _repositoryManager.RepositoryTeacher.GetTeacherAsync(teacherId);
            if (teacher == null)
                return NotFound();
            return Ok(teacher);
        }

        [HttpPost]

        public async Task<IActionResult> PostAsync([FromBody] TeacherDto teacherDto)
        {
            var teacherId = Guid.NewGuid();
            var teacher = new Teacher
            {
                Id = teacherId,
                Name = teacherDto.Name,
                Surname = teacherDto.Surname,
                Age = teacherDto.Age
            };
            await _repositoryManager.RepositoryTeacher.CreateTeacherAsync(teacher);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok(teacher);
        }

        [HttpPut]

        public async Task<IActionResult> PutAsync([FromBody] TeacherDto teacherDto)
        {
            var teacher = await _repositoryManager.RepositoryTeacher.GetTeacherAsync(teacherDto.Id);
            if (teacher == null)
                return NotFound();
            await _repositoryManager.RepositoryTeacher.UpdateTeacherAsync(teacher);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok(teacher);
        }

        [HttpDelete("id")]

        public async Task<IActionResult> DeleteAsync(Guid teacherId)
        {
            var teacher = await _repositoryManager.RepositoryTeacher.GetTeacherAsync(teacherId);
            if (teacher == null)
                return NotFound();
            await _repositoryManager.RepositoryTeacher.DeleteTeacherAsync(teacher);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok(teacher);
        }
    }
}
