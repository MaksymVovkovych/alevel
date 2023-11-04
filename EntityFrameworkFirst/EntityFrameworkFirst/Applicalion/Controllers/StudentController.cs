using EntityFrameworkFirst.Applicalion.DTOs;
using EntityFrameworkFirst.Domain.Entities;
using EntityFrameworkFirst.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkFirst.Applicalion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        public StudentController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllAsync()
        {
            var students = await _repositoryManager.RepositoryStudent.GetAllStudentsAsync();
            if (students == null)
                return NotFound();
            return Ok(students);
        }

        [HttpGet("id")]

        public async Task<IActionResult> GetByIdAsync(Guid studentId)
        {
            var student = await _repositoryManager.RepositoryStudent.GetStudentAsync(studentId);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpPost]

        public async Task<IActionResult> PostAsync([FromBody] StudentDto studentDto)
        {
            var studentGuid = Guid.NewGuid();
            var student = new Student
            {
                Id = studentGuid,
                Email = studentDto.Email,
                Name = studentDto.Name,
                Surname = studentDto.Surname
            };
            await _repositoryManager.RepositoryStudent.CreateStudentAsync(student);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok(student);
        }

        [HttpDelete("id")]

        public async Task<IActionResult> DeleteAsync(Guid studentId)
        {
            var student = await _repositoryManager.RepositoryStudent.GetStudentAsync(studentId);
            if (student == null)
                return NotFound();
            await _repositoryManager.RepositoryStudent.DeleteStudentAsync(student);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPut]

        public async Task<IActionResult> ChangeAsync([FromBody] StudentDto studentDto)
        {
            var student = await _repositoryManager.RepositoryStudent.GetStudentAsync(studentDto.Id);
            if (student == null)
                return NotFound();

            student.Name = studentDto.Name;
            student.Surname = studentDto.Surname;
            student.Email = studentDto.Email;

            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok(student);
        }
    }
}
