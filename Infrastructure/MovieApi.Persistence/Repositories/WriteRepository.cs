using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Interfaces;

namespace MovieApi.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : class, new()
{
    private readonly DbContext dbContext;

    public WriteRepository(DbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    private DbSet<T> Table => dbContext.Set<T>();

    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public async Task AddRangeAsync(IList<T> entities)
    {
        await Table.AddRangeAsync(entities);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        await Task.Run(() => Table.Update(entity));
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        Table.Remove(entity);
    }
}
