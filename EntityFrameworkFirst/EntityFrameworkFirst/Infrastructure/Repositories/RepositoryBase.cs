using EntityFrameworkFirst.Domain.Interfaces;
using EntityFrameworkFirst.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EntityFrameworkFirst.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly EFContext _context;
        public RepositoryBase(EFContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> FindAllAsync()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>()
                .Where(expression);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
