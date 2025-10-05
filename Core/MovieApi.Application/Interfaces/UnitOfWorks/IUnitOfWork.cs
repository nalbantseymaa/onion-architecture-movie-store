using MovieApi.Application.Interfaces.Repositories;

namespace MovieApi.Application.Interfaces.UnitOfWorks;

public interface IUnitOfWork : IAsyncDisposable
{
    IReadRepository<T> GetReadRepository<T>() where T : class, new();
    IWriteRepository<T> GetWriteRepository<T>() where T : class, new();
    Task<int> SaveChangesAsync();
    int SaveChanges();

}