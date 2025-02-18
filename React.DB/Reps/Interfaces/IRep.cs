using System.Linq.Expressions;
namespace React.DB.Reps.Interfaces;

public interface IRepBase<T>
{
    IQueryable<T> Get(Expression<Func<T, bool>>? filter = null, string? includes = null, bool asNoTracking = false);
}

public interface IRep<T> : IRepBase<T>
{
    void Add(T item);
    void Remove(T item);
}