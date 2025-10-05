using MovieApi.Application.Interfaces.Repositories;
using MovieApi.Application.Interfaces.UnitOfWorks;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Repositories;

namespace MovieApi.Persistence.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    //Consistency : Single DbContext Instance
    private readonly AppDbContext dbContext;
    public UnitOfWork(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    //Generic Repository Pattern Implementation
    public IReadRepository<T> GetReadRepository<T>() where T : class, new()
    {
        return new ReadRepository<T>(dbContext);
    }

    public IWriteRepository<T> GetWriteRepository<T>() where T : class, new()
    {
        return new WriteRepository<T>(dbContext);
    }

    //Transaction Management
    public int SaveChanges()
    {
        return dbContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await dbContext.SaveChangesAsync();

    }

    public async ValueTask DisposeAsync()
    {
        await dbContext.DisposeAsync();
    }

}