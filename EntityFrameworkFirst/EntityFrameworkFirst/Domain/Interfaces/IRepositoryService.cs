using EntityFrameworkFirst.Domain.Entities;

namespace EntityFrameworkFirst.Domain.Interfaces
{
    public interface IRepositoryService
    {
        Task CreateServiceAsync(Services service);
        Task UpdateServiceAsync(Services service);
        Task DeleteServiceAsync(Services service);
        Task<Services> GetServiceAsync(Guid serviceId);
        Task<IReadOnlyCollection<Services>> GetAllServicesAsync();
    }
}
