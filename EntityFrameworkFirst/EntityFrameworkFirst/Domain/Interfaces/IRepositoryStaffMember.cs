using EntityFrameworkFirst.Domain.Entities;

namespace EntityFrameworkFirst.Domain.Interfaces
{
    public interface IRepositoryStaffMember
    {
        Task CreateStaffMemberAsync(StaffMember member);
        Task UpdateStaffMemberAsync(StaffMember member);
        Task DeleteStaffMemberAsync(StaffMember member);
        Task<StaffMember> GetStaffMemberAsync(Guid memberId);
        Task<IReadOnlyCollection<StaffMember>> GetAllPersonalAsync();
        Task AddServicesAsync(Guid id, ICollection<Services> services);
        Task AddClassAsync(Guid id, Class @class);
    }
}
