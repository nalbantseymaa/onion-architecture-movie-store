using MovieApi.Application.Interfaces;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Repositories;

namespace MovieApi.Application.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext dbContext;
    public UnitOfWork(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IReadRepository<T> GetReadRepository<T>() where T : class, new()
    {
        return new ReadRepository<T>(dbContext);
    }

    public IWriteRepository<T> GetWriteRepository<T>() where T : class, new()
    {
        return new WriteRepository<T>(dbContext);
    }

    public int SaveChanges()
    {
        dbContext.SaveChanges();
        return 0;
    }

    public async Task<int> SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
        return 0;
    }

    public async ValueTask DisposeAsync()
    {
        await dbContext.DisposeAsync();
    }

}