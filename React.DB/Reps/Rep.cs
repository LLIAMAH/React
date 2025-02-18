using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using React.DB.Reps.Interfaces;

namespace React.DB.Reps;

public class RepBase<T>(AppDbCtx ctx): IRepBase<T> where T : class
{
    private readonly AppDbCtx _ctx = ctx;
    protected readonly DbSet<T> _dbSet = ctx.Set<T>();
    public IQueryable<T> Get(Expression<Func<T, bool>>? filter = null, string? includes = null, bool asNoTracking = false)
    {
        IQueryable<T> query = this._dbSet;
        if(asNoTracking)
            query = query.AsNoTracking();
        
        if(!string.IsNullOrEmpty(includes)) 
            query = includes.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, include) => current.Include(include));
        
        if(filter != null)
            query = query.Where(filter);

        return query;
    }
}

public class Rep<T>(AppDbCtx ctx): RepBase<T>(ctx), IRep<T> where T : class
{
    public void Add(T item)
    {
        this._dbSet.Add(item);
    }

    public void Remove(T item)
    {
        this._dbSet.Remove(item);
    }
}