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
    
}