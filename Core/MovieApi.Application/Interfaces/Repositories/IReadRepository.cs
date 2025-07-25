using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace MovieApi.Application.Interfaces;

public interface IReadRepository<T> where T : class, new()
{
    Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
     Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
     Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
     bool enableTracking = false);

    Task<T> GetAsync(Expression<Func<T, bool>> predicate,
     Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
    bool enableTracking = false);

    IQueryable<T> Find(Expression<Func<T, bool>> predicate,
    bool enableTracking = false);

    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);

    /*
    Task : Metotların asenkron olarak çalışmasını sağlar.
    async işlemlerde await kullanılır
    Expression<Func<T, bool>> predicate : Dinamik filtreleme sağlar.   x=> x.Id == 1 gibi.
    Func<IQueryable<T>, IIncludableQueryable<T, object>> include
    : İlişkili tabloları (navigation property) sorguya dahil etmek için kullanılır. q=> q.Include(x => x.Actors)
    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy
    : Sorgu sonuçlarını sıralamak için kullanılır. q=> q.OrderBy(x => x.Name)
    bool disableTracking : Sorgu sonuçlarının değişiklik izleme (change tracking) özelliğini devre dışı bırakmak için kullanılır.
    */
}