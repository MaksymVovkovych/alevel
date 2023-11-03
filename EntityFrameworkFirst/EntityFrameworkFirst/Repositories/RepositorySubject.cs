using EntityFrameworkFirst.Context;
using EntityFrameworkFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkFirst.Repositories
{
    public class RepositorySubject : RepositoryBase<Subject>, IRepositorySubject
    {
        public RepositorySubject(EFContext eFContext) : base(eFContext) { }

        public async Task CreateSubjectAsync(Subject subject)
        {
            await CreateAsync(subject);
        }
        public async Task UpdateSubjectAsync(Subject subject)
        {
            await UpdateAsync(subject);
        }

        public async Task DeleteSubjectAsync(Subject subject)
        {
            await DeleteAsync(subject);
        }

        public async Task<IReadOnlyCollection<Subject>> GetAllSubjectsAsync()
        {
            return await FindAllAsync().ToListAsync();
        }

        public async Task<Subject?> GetSubjectAsync(Guid subjectId)
        {
            return await FindByConditionAsync(x => x.Id == subjectId).FirstOrDefaultAsync();
        }
    }
}
