using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ItechArt.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ItechArt.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet;


    public Repository(DbContext dbContext)
    {
        _dbSet = dbContext.Set<TEntity>();
    }


    public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync(IEntityLoadStrategy<TEntity> includes = null)
    {
        return await IncludeEntities(includes).ToListAsync();
    }

    public virtual async Task<TEntity> GetFirstOrDefaultAsync(IEntityLoadStrategy<TEntity> includes = null)
    {
        return await IncludeEntities(includes).FirstOrDefaultAsync();
    }

    public virtual async Task<IReadOnlyCollection<TEntity>> GetWhereAsync(
        Expression<Func<TEntity, bool>> filter,
        IEntityLoadStrategy<TEntity> includes = null)
    {
        return await IncludeEntities(includes).Where(filter).ToListAsync();
    }

    public virtual void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public virtual void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public virtual void Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
    }


    protected virtual IQueryable<TEntity> IncludeEntities(IEntityLoadStrategy<TEntity> includes = null)
    {
        return includes == null
            ? _dbSet
            : includes.Includes.Aggregate((IQueryable<TEntity>)_dbSet,
                (q, include) => q.Include(include));
    }
}