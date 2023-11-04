using EntityFrameworkFirst.Domain.Entities;

namespace EntityFrameworkFirst.Domain.Interfaces
{
    public interface IRepositoryTeacher
    {
        Task CreateTeacherAsync(Teacher teacher);
        Task UpdateTeacherAsync(Teacher teacher);
        Task DeleteTeacherAsync(Teacher teacher);
        Task<Teacher> GetTeacherAsync(Guid teacherId);
        Task<IReadOnlyCollection<Teacher>> GetAllTeachersAsync();
    }
}
