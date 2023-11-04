using EntityFrameworkFirst.Domain.Entities;

namespace EntityFrameworkFirst.Domain.Interfaces
{
    public interface IRepositoryStudent
    {
        Task CreateStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(Student studentId);
        Task<Student> GetStudentAsync(Guid studentId);
        Task<IReadOnlyCollection<Student>> GetAllStudentsAsync();
    }
}
