using EntityFrameworkFirst.Context;
using EntityFrameworkFirst.Entities;
using EntityFrameworkFirst.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFrameworkFirst.Repositories
{
    public class RepositoryClass : RepositoryBase<Class>, IRepositoryClass
    {
        public RepositoryClass(EFContext eFContext) : base(eFContext) { }

        public async Task CreateClassAsync(Class @class)
        {
            await CreateAsync(@class);
        }
        public async Task UpdateClassAsync(Class @class)
        {
            await UpdateAsync(@class);
        }

        public async Task DeleteClassAsync(Class @class)
        {
            await DeleteAsync(@class);
        }

        public async Task<IReadOnlyCollection<Class>> GetAllClassesAsync()
        {
            return await FindAllAsync().ToListAsync();
        }

        public async Task<Class?> GetClassAsync(Guid classId)
        {
            return await FindByConditionAsync(x => x.Id == classId).FirstOrDefaultAsync();
        }
    }
}
