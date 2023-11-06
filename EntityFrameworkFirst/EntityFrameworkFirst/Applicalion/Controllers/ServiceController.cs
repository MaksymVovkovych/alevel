using EntityFrameworkFirst.Applicalion.DTOs;
using EntityFrameworkFirst.Domain.Entities;
using EntityFrameworkFirst.Domain.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkFirst.Applicalion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        public ServiceController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var services = await _repositoryManager.RepositoryService.GetAllServicesAsync();
            return Ok(services);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(Guid serviceId)
        {
            var service = await _repositoryManager.RepositoryService.GetServiceAsync(serviceId);
            if (service == null)
                return NotFound();
            return Ok(service);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ServiceDto serviceDto)
        {
            var serviceId = Guid.NewGuid();
            var service = new Services
            {
                Id = serviceId,
                ServiceName = serviceDto.ServiceName,
                Description = serviceDto.Description,
                TypeService = serviceDto.TypeService,

            };
            await _repositoryManager.RepositoryService.CreateServiceAsync(service);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(Guid serviceId)
        {
            var service = await _repositoryManager.RepositoryService.GetServiceAsync(serviceId);
            if (service == null)
                return NotFound();

            await _repositoryManager.RepositoryService.DeleteServiceAsync(service);
            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeAsync([FromRoute]Guid id,[FromBody]ServiceDto serviceDto)
        {
            var service = await _repositoryManager.RepositoryService.GetServiceAsync(id);
            if (service == null)
                return NotFound();

            await _repositoryManager.RepositoryService.UpdateServiceAsync(service);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok(service);
        }
    }
}
