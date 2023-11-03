using EntityFrameworkFirst.Entities;

namespace EntityFrameworkFirst.Repositories
{
    public interface IRepositorySchool
    {
        Task CreateSchoolAsync(School school);
        Task<School> UpdateSchoolAsync(School school);
        Task DeleteSchoolAsync(Guid schoolId);
        Task<School> GetSchoolAsync(Guid schoolId);
        Task<IReadOnlyCollection<School>> GetAllSchoolsAsync();
    }
}
