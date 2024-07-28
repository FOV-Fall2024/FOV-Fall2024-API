using System.Linq.Expressions;
using FOV.Domain.Common;
using FOV.Infrastructure.Common;

namespace FOV.Infrastructure.Repository.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseAuditableEntity
    {
        Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity?> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> AddAsync(TEntity entity);
        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
        Task AddRangeAsync(List<TEntity> entities);
        Task<Pagination<TEntity>> ToPagination(int pageNumber = 0, int pageSize = 10);

        void Remove(TEntity entity);
    }
}
