
namespace Inventory.Application.IRepository;

public interface ICommandRepository<TEntity,TID> where TEntity : BaseEntity<TID>
{
    void Add(TEntity entity);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    void SaveChange();
    Task SaveChangeAsync(CancellationToken cancellationToken);
}
