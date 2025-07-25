using MovieApi.Application.Interfaces;

namespace MovieApi.Application.UnitOfWorks;

public interface IUnitOfWork : IAsyncDisposable
{
    IReadRepository<T> GetReadRepository<T>() where T : class, new();
    IWriteRepository<T> GetWriteRepository<T>() where T : class, new();
    Task<int> SaveChangesAsync();
    int SaveChanges();

}