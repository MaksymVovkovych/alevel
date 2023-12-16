using System.Linq.Expressions;

namespace Catalog.Host.Repositories.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task Create(T item);
    Task Update(T item);
    Task Delete(T item);
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
}