using System.Linq.Expressions;

namespace Catalog.Host.Repositories.Interfaces;

public interface IBaseRepository<T>
{
    Task<T> Create(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(T entity);
    IQueryable<T> FindAll();
    Task<T?> FindById(int Id);
}