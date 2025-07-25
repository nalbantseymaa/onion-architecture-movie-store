using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MovieApi.Application.Interfaces;

namespace MovieApi.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : class, new()
{
    private readonly DbContext dbContext;

    public ReadRepository(DbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    private DbSet<T> Table => dbContext.Set<T>();

    public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
    {
        Table.AsNoTracking();
        if (predicate != null) Table.Where(predicate);
        return await Table.CountAsync();
    }

    public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
    {
        if (!enableTracking) Table.AsNoTracking();
        return Table.Where(predicate);
    }

    public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
    {
        IQueryable<T> queryable = Table;
        if (enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);
        if (orderBy != null) queryable = orderBy(queryable);
        return await orderBy(queryable).ToListAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include, bool enableTracking)
    {
        IQueryable<T> queryable = Table;
        if (enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        //queryable = queryable.Where(predicate);
        return await queryable.FirstOrDefaultAsync(predicate);
    }

}