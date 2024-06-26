using Microsoft.EntityFrameworkCore;
using Northwind.Models;

namespace Northwind.Repositories.Implement;

public class DbRepository : DbContext
{
    private readonly NorthwindContext _dbContext;

    public DbRepository(NorthwindContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<T> GetAll<T>() where T : class
    {
        return _dbContext.Set<T>();
    }


    public virtual void Update<T>(T entity) where T : class
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public TEntity GetEntityById<TEntity>(string id, bool asNoTracking = false) where TEntity : class
    {
        var query = _dbContext.Set<TEntity>().AsQueryable();

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return query.FirstOrDefault(e => EF.Property<string>(e, "CustomerId") == id);
    }

    public virtual void Create<T>(T entity) where T : class
    {
        _dbContext.Entry(entity).State = EntityState.Added;
    }

    public virtual void Delete<T>(T entity) where T : class
    {
        _dbContext.Entry(entity).State = EntityState.Deleted;
    }
}