﻿
namespace Inventory.Application.IRepository;

public interface IRepository<TEntity,TID> where TEntity : BaseEntity<TID>
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(TID id, CancellationToken cancellationToken);
    Task SaveChangeAsync(CancellationToken cancellationToken);

    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TID id);
    void SaveChange();
    Task<TEntity> GetAsyncById(TID id, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetAsyncAll(CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> FindAsyncTracking(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> FindAsyncNoTracking(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    TEntity GetById(TID id);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    IQueryable<TEntity> FindQueryable(Expression<Func<TEntity, bool>> predicate);
}
