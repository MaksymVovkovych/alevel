using EntityFrameworkFirst.Entities;

namespace EntityFrameworkFirst.Repositories
{
    public interface IRepositoryStudent
    {
        Task CreateStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(Guid studentId);
        Task<Student> GetStudentAsync(Guid studentId);
        Task<IReadOnlyCollection<Student>> GetAllStudentsAsync();
    }
}
