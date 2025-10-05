namespace MovieApi.Application.Interfaces.Repositories;

public interface IWriteRepository<T> where T : class, new()
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IList<T> entities);
    void Update(T entity);
    void Delete(T entity);

}