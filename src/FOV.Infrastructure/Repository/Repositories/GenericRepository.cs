using System.Linq.Expressions;
using FOV.Domain.Common;
using FOV.Infrastructure.Common;
using FOV.Infrastructure.Constant;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FOV.Infrastructure.Repository.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseAuditableEntity
{
    protected DbSet<TEntity> _dbSet;

    public GenericRepository(FOVContext context)
    {
        _dbSet = context.Set<TEntity>();
    }
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        entity.Created = DateTime.UtcNow;
        var result = await _dbSet.AddAsync(entity);
        return result.Entity;
    }

    public async Task AddRangeAsync(List<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.Created = DateTime.UtcNow;
        }
        await _dbSet.AddRangeAsync(entities);
    }

    public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
      => await includes
            .Aggregate(_dbSet!.AsQueryable(), (entity, property) => entity!.Include(property)).AsNoTracking()
            .Where(expression!)
            .FirstOrDefaultAsync();

    public async Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes) =>
    await includes.Aggregate(_dbSet.AsQueryable(), (entity, property) => entity.Include(property).IgnoreAutoIncludes())
    .OrderByDescending(x => x.Created)
    .ToListAsync();


    public async Task<TEntity?> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includes)
    {
        return await includes
            .Aggregate(_dbSet.AsQueryable(), (entity, property) => entity.Include(property))
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public void Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<Pagination<TEntity>> ToPagination(int pageNumber = 0, int pageSize = 10)
    {
        var itemCount = await _dbSet.CountAsync();
        var items = await _dbSet.Skip(pageNumber * pageSize)
                                .Take(pageSize)
                                .AsNoTracking()
                                .ToListAsync();

        var result = new Pagination<TEntity>()
        {
            PageIndex = pageNumber,
            PageSize = pageSize,
            TotalItemsCount = itemCount,
            Items = items,
        };

        return result;
    }

    public void Update(TEntity entity)
    {
        entity.LastModified = DateTime.UtcNow   ;
        _dbSet.Update(entity);
    }

    public void UpdateRange(List<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.LastModified = CurrentTime.RecentTime;
        }
        _dbSet.UpdateRange(entities);
    }

    public async Task<List<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
    => await includes
      .Aggregate(_dbSet!.AsQueryable(), (entity, property) => entity.Include(property)).AsNoTracking()
      .Where(expression!)
      .OrderByDescending(x => x.Created)
      .ToListAsync();
}
