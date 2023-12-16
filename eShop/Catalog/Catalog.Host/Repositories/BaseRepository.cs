using System.Linq.Expressions;
using Catalog.Host.Data;
using Catalog.Host.Data.Entity;
using Catalog.Host.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly AppDbContext _appContext;

    public BaseRepository(AppDbContext appContext)
    {
        _appContext = appContext;
    }
    
    public async Task Create(T item)
    {
        await _appContext.Set<T>().AddAsync(item);
        await _appContext.SaveChangesAsync();
    }

    public async Task Update(T item)
    {
        _appContext.Set<T>().Update(item);
        await _appContext.SaveChangesAsync();
    }

    public async Task Delete(T item)
    {
        _appContext.Set<T>().Remove(item);
        await _appContext.SaveChangesAsync();
    }

    public IQueryable<T> FindAll()
    {
        return _appContext.Set<T>().AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return _appContext.Set<T>().Where(expression);
    }
}