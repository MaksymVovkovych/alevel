using EntityFrameworkFirst.Domain.Entities;
using EntityFrameworkFirst.Domain.Interfaces;
using EntityFrameworkFirst.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkFirst.Infrastructure.Repositories
{
    public class RepositoryTeacher : RepositoryBase<Teacher>, IRepositoryTeacher
    {
        public RepositoryTeacher(EFContext eFContext) : base(eFContext) { }

        public async Task CreateTeacherAsync(Teacher teacher)
        {
            await CreateAsync(teacher);
        }
        public async Task UpdateTeacherAsync(Teacher teacher)
        {
            await UpdateAsync(teacher);
        }

        public async Task DeleteTeacherAsync(Teacher teacher)
        {
            await DeleteAsync(teacher);
        }

        public async Task<IReadOnlyCollection<Teacher>> GetAllTeachersAsync()
        {
            return await FindAllAsync().ToListAsync();
        }

        public async Task<Teacher?> GetTeacherAsync(Guid teacherId)
        {
            return await FindByConditionAsync(x => x.Id == teacherId).FirstOrDefaultAsync();
        }
    }
}
