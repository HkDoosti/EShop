

namespace Inventory.Infrastructure.Repository;

public class QueryRepository<TEntity, TID>(InventoryDbContext context)
    : IQueryRepository<TEntity, TID>, IDisposable
    where TEntity : BaseEntity<TID>
{
    private readonly InventoryDbContext _context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    private bool disposedValue;

   
    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.Where(predicate).ToList();
    }
    public async Task<IEnumerable<TEntity>> FindAsyncTracking(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
    }
    public IQueryable<TEntity> FindQueryable(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbSet.AsNoTracking().Where(predicate);
    }
    public async Task<IEnumerable<TEntity>> FindAsyncNoTracking(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync(cancellationToken) ??
            Enumerable.Empty<TEntity>();
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _dbSet
            .AsNoTracking()
            .ToList() ??
            Enumerable.Empty<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAsyncAll(CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .ToListAsync(cancellationToken)??
            Enumerable.Empty<TEntity>();
    }

    public async Task<TEntity> GetAsyncById(TID id, CancellationToken cancellationToken)
    {
        var result= await _dbSet.FindAsync(id,cancellationToken);
        return result?? (TEntity)new object();
    }

    public TEntity GetById(TID id)
    {
        var result = _dbSet.Find(id);
        return result ?? (TEntity)new object();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~Repository()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
