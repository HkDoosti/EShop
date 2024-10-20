
namespace Inventory.Application.IRepository;

public interface IQueryRepository<TEntity,TID> where TEntity : BaseEntity<TID>
{
    bool isDeleteFilterActive {  get; set; }    
    Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<TEntity> GetAsyncByIdFiltered(TID id, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetAsyncAll(CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> FindAsyncTracking(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> FindAsyncNoTracking(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    TEntity GetByIdFiltered(TID id);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    IQueryable<TEntity> FindQueryable(Expression<Func<TEntity, bool>> predicate);
}
