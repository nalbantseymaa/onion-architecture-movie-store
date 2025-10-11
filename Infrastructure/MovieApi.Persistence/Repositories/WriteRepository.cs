using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Interfaces.Repositories;

namespace MovieApi.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : class, new()
{
    private readonly DbContext dbContext;
    private readonly DbSet<T> dbSet;

    public WriteRepository(DbContext dbContext)
    {
        this.dbContext = dbContext;
        dbSet = dbContext.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IList<T> entities)
    {
        await dbSet.AddRangeAsync(entities);
    }

    public void Update(T entity)
    {
        dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        dbSet.Remove(entity);
    }
}
