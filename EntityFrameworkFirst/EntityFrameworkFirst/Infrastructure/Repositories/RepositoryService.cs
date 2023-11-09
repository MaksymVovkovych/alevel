using EntityFrameworkFirst.Domain.Entities;
using EntityFrameworkFirst.Domain.Interfaces;
using EntityFrameworkFirst.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkFirst.Infrastructure.Repositories
{
    public class RepositoryService : RepositoryBase<Services>, IRepositoryService
    {
        public RepositoryService(EFContext eFContext) : base(eFContext) { }

        public async Task CreateServiceAsync(Services service)
        {
            await CreateAsync(service);
        }
        public async Task UpdateServiceAsync(Services service)
        {
            await UpdateAsync(service);
        }

        public async Task DeleteServiceAsync(Services service)
        {
            await DeleteAsync(service);
        }

        public async Task<IReadOnlyCollection<Services>> GetAllServicesAsync()
        {
            return await FindAllAsync().ToListAsync();
        }

        public async Task<Services?> GetServiceAsync(Guid serviceId)
        {
            return await FindByConditionAsync(x => x.Id == serviceId).FirstOrDefaultAsync();
        }
    }
}
