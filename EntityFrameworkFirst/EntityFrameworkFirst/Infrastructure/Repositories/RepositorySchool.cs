﻿using EntityFrameworkFirst.Domain.Entities;
using EntityFrameworkFirst.Domain.Interfaces;
using EntityFrameworkFirst.Infrastructure.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkFirst.Infrastructure.Repositories
{
    public class RepositorySchool : RepositoryBase<School>, IRepositorySchool
    {
        public RepositorySchool(EFContext eFContext) : base(eFContext) { }

        public async Task CreateSchoolAsync(School school)
        {
            await CreateAsync(school);
        }
        public async Task UpdateSchoolAsync(School school)
        {
            await UpdateAsync(school);
        }

        public async Task DeleteSchoolAsync(School school)
        {
            await DeleteAsync(school);
        }

        public async Task<IReadOnlyCollection<School>> GetAllSchoolsAsync()
        {
            return await FindAllAsync().ToListAsync();
        }

        public async Task<School?> GetSchoolAsync(Guid schoolId)
        {
            return await FindByConditionAsync(x => x.Id == schoolId).FirstOrDefaultAsync();
        }

        public async Task AddClasses(Guid id,ICollection<Class> classes)
        {
            var school = await GetSchoolAsync(id);
            if (school == null)
                return;
            school.Classes = classes;
            //await UpdateAsync(school);
        }
    }
}
