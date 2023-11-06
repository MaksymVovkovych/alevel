using EntityFrameworkFirst.Domain.Entities;
using EntityFrameworkFirst.Domain.Interfaces;
using EntityFrameworkFirst.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkFirst.Infrastructure.Repositories
{
    public class RepositoryStaffMember : RepositoryBase<StaffMember>, IRepositoryStaffMember
    {
        public RepositoryStaffMember(EFContext eFContext) : base(eFContext) { }

        public async Task CreateStaffMemberAsync(StaffMember staffMember)
        {
            await CreateAsync(staffMember);
        }
        public async Task UpdateStaffMemberAsync(StaffMember staffMember)
        {
            await UpdateAsync(staffMember);
        }

        public async Task DeleteStaffMemberAsync(StaffMember staffMember)
        {
            await DeleteAsync(staffMember);
        }

        public async Task<IReadOnlyCollection<StaffMember>> GetAllPersonalAsync()
        {
            return await FindAllAsync().ToListAsync();
        }

        public async Task<StaffMember?> GetStaffMemberAsync(Guid staffMemberId)
        {
            return await FindByConditionAsync(x => x.Id == staffMemberId).FirstOrDefaultAsync();
        }

        public async Task AddClassAsync(Guid id, Class @class)
        {
            var staffMember = await GetStaffMemberAsync(id);
            if (staffMember == null)
                return;
            staffMember.Class = @class;
        }

        public async Task AddServicesAsync(Guid id, ICollection<Services> services)
        {
            var staffMember = await GetStaffMemberAsync(id);
            if (staffMember == null)
                return;
            staffMember.Services = services;
        }
    }
}
