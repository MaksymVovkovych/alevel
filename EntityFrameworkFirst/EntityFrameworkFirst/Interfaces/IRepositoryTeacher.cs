using EntityFrameworkFirst.Entities;

namespace EntityFrameworkFirst.Repositories
{
    public interface IRepositoryTeacher
    {
        Task CreateTeacherAsync(Teacher teacher);
        Task<Teacher> UpdateTeacherAsync(Teacher teacher);
        Task DeleteTeacherAsync(Guid teacherId);
        Task<Teacher> GetTeacherAsync(Guid teacherId);
        Task<IReadOnlyCollection<Teacher>> GetAllTeacherAsync();
    }
}
