using EntityFrameworkFirst.Domain.Entities;
using EntityFrameworkFirst.Domain.Interfaces;
using EntityFrameworkFirst.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkFirst.Infrastructure.Repositories
{
    public class RepositoryStudent : RepositoryBase<Student>, IRepositoryStudent
    {
        public RepositoryStudent(EFContext eFContext) : base(eFContext) { }

        public async Task CreateStudentAsync(Student student)
        {
            await CreateAsync(student);
        }
        public async Task UpdateStudentAsync(Student student)
        {
            await UpdateAsync(student);
        }

        public async Task DeleteStudentAsync(Student student)
        {
            await DeleteAsync(student);
        }

        public async Task<IReadOnlyCollection<Student>> GetAllStudentsAsync()
        {
            return await FindAllAsync().ToListAsync();
        }

        public async Task<Student?> GetStudentAsync(Guid studentId)
        {
            return await FindByConditionAsync(x => x.Id == studentId).FirstOrDefaultAsync();
        }
    }
}
