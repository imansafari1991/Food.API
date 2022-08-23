using Food.API.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Food.API.Data.Intefaces;

public interface IBaseRepository<TEntity> where TEntity:class,IEntity
{
    DbSet<TEntity> Entities { get; }
    IQueryable<TEntity> Table { get; }
    IQueryable<TEntity> TableNoTracking { get; }

    void Add(TEntity entity, bool saveNow = true);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
    void AddRange(IEnumerable<TEntity> entities, bool saveNow = true);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
    void Delete(TEntity entity, bool saveNow = true);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
    void DeleteRange(IEnumerable<TEntity> entities, bool saveNow = true);
    Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
    TEntity GetById(params object[] ids);
    ValueTask<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);
    void Update(TEntity entity, bool saveNow = true);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
    void UpdateRange(IEnumerable<TEntity> entities, bool saveNow = true);
    Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
}