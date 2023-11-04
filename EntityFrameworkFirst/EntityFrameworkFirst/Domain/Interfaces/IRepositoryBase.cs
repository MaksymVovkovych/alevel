using System.Linq.Expressions;

namespace EntityFrameworkFirst.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> FindAllAsync();
        IQueryable<T> FindByConditionAsync(Expression<Func<T, bool>> expression);

    }
}
