using EntityFrameworkFirst.Applicalion.DTOs;
using EntityFrameworkFirst.Domain.Entities;
using EntityFrameworkFirst.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkFirst.Applicalion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffMemberController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        public StaffMemberController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var students = await _repositoryManager.RepositoryStaffMember.GetAllPersonalAsync();
            if (students == null)
                return NotFound();
            return Ok(students.OrderBy(p => p.Name));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(Guid staffMemberId)
        {
            var staffMember = await _repositoryManager.RepositoryStaffMember.GetStaffMemberAsync(staffMemberId);
            if (staffMember == null)
                return NotFound();
            return Ok(staffMember);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] StaffMemberDto staffMemberProp)
        {
            var staffMemberGuid = Guid.NewGuid();
            var staffMember = new StaffMember
            {
                Id = staffMemberGuid,
                Email = staffMemberProp.Email,
                Name = staffMemberProp.Name,
                Surname = staffMemberProp.Surname
            };
            await _repositoryManager.RepositoryStaffMember.CreateStaffMemberAsync(staffMember);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok(staffMember);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(Guid staffMemberId)
        {
            var staffMember = await _repositoryManager.RepositoryStaffMember.GetStaffMemberAsync(staffMemberId);
            if (staffMember == null)
                return NotFound();
            await _repositoryManager.RepositoryStaffMember.DeleteStaffMemberAsync(staffMember);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok(staffMember);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeAsync(
            [FromRoute] Guid id,
            [FromBody] StaffMemberDto staffMemberDto
            )
        {
            var staffMember = await _repositoryManager.RepositoryStaffMember.GetStaffMemberAsync(id);
            if (staffMember == null)
                return NotFound();

            staffMember.Name = staffMemberDto.Name;
            staffMember.Surname = staffMemberDto.Surname;
            staffMember.Email = staffMemberDto.Email;

            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok(staffMember);
        }

        [HttpPut("{id}/class")]
        public async Task<IActionResult> AddClassAsync(
            [FromRoute] Guid id,
            ClassDto @class
            )
        {

            await _repositoryManager.RepositoryStaffMember.AddClassAsync(id, new Class
            {
                Capacity = @class.Capacity,
                ClassNumber = @class.ClassNumber,
            });
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}/services")]
        public async Task<IActionResult> AddServicesAsync(
            [FromRoute] Guid id,
            ICollection<ServiceDto> servicesDto
            )
        {
            var services = servicesDto.Select(dto => new Services
            {
                Description = dto.Description,
                ServiceName = dto.ServiceName,
                TypeService = dto.TypeService
            }).ToList();

            await _repositoryManager.RepositoryStaffMember.AddServicesAsync(id, services);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok();
        }
    }
}
