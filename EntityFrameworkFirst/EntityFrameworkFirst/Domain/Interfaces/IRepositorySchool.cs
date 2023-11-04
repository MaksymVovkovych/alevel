using EntityFrameworkFirst.Domain.Entities;

namespace EntityFrameworkFirst.Domain.Interfaces
{
    public interface IRepositorySchool
    {
        Task CreateSchoolAsync(School school);
        Task UpdateSchoolAsync(School school);
        Task DeleteSchoolAsync(School schoolId);
        Task<School> GetSchoolAsync(Guid schoolId);
        Task<IReadOnlyCollection<School>> GetAllSchoolsAsync();
    }
}
