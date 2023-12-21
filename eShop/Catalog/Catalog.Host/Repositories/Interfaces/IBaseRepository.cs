using System.Linq.Expressions;

namespace Catalog.Host.Repositories.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<int> Create(T item);
    Task<int> Update(T item);
    Task<int> Delete(T item);
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
}