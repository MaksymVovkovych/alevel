using System.Linq.Expressions;
using Catalog.Host.Data;
using Catalog.Host.Exceptions;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public class BaseRepository<T> : IBaseRepository<T>  where T : class
{
    private readonly AppDbContext _appDbContext;
    internal ILogger<BaseRepository<T>> _logger;

    public BaseRepository(AppDbContext appDbContext, ILogger<BaseRepository<T>> logger)
    {
        _appDbContext = appDbContext;
        _logger = logger;
    }
    
    public async Task<T> Create(T entity)
    {
        await _appDbContext.Set<T>().AddAsync(entity);
        var result = await _appDbContext.SaveChangesAsync();
        if (result == 0)
        {
            throw new RepositoryException("Entity didn`t save changes!");
        }
        return entity;
    }

    public async Task<T> Update(T entity)
    {
         _appDbContext.Set<T>().Update(entity);
         var result = await _appDbContext.SaveChangesAsync();
        if (result == 0)
        {
            throw new RepositoryException("Entity didn`t save changes!");
        }
        return entity;
    }

    public async Task<T> Delete(T entity)
    {
         _appDbContext.Set<T>().Remove(entity);
         var result = await _appDbContext.SaveChangesAsync();
         if (result == 0)
         {
             throw new RepositoryException("Entity didn`t save changes!");
         }
        return entity;

    }

    public IQueryable<T> FindAll()
    {
        var result = _appDbContext.Set<T>().AsQueryable();
        if (result == null)
        {
            throw new RepositoryException("There are no entities");
        }

        return result;
    }

    public async Task<T?> FindById(int id)
    {
        var result = await _appDbContext.Set<T>().FindAsync(id);
        if (result == null)
        {
            throw new RepositoryException($"Not Found Entity By id: {id}!");
        }

        return result;
    }
}