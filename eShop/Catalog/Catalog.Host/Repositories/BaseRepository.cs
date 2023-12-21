using System.Linq.Expressions;
using AutoMapper;
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
    
    public async Task<int> Create(T item)
     {
        await _appContext.Set<T>().AddAsync(item);
        return await _appContext.SaveChangesAsync();
    }

    public async Task<int> Update(T item)
    {

        _appContext.Update(item);

        return await _appContext.SaveChangesAsync();
        
    }

    public async Task<int> Delete(T item)
    {
        _appContext.Set<T>().Remove(item);
        return await _appContext.SaveChangesAsync();
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