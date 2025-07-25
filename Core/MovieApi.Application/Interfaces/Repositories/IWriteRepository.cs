using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace MovieApi.Application.Interfaces;

public interface IWriteRepository<T> where T : class, new()
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IList<T> entities);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(T entity);

}