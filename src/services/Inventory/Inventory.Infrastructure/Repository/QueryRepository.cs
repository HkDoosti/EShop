



namespace Inventory.Infrastructure.Repository;

public class QueryRepository<TEntity, TID>(
    InventoryDbContext context)
    : IQueryRepository<TEntity, TID>, IDisposable
    where TEntity : BaseEntity<TID>
{
    protected readonly InventoryDbContext _context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    private bool disposedValue;
    public bool isDeleteFilterActive { get; set; } = true;

    public IQueryable<TEntity> GetEntities() 
    {
        if (isDeleteFilterActive)
        {
            return _context.Set<TEntity>().IgnoreQueryFilters();
        }
        else
        {
            return _context.Set<TEntity>();
        }
    }
    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate,CancellationToken cancellationToken)
    {
        try { 
            return await GetEntities().Where(predicate).CountAsync(cancellationToken); 
        } catch (Exception ex) 
        {
            throw;
        }
        
    }
    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return GetEntities().Where(predicate).ToList();
    }
    public async Task<IEnumerable<TEntity>> FindAsyncTracking(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await GetEntities().AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
    }
    public IQueryable<TEntity> FindQueryable(Expression<Func<TEntity, bool>> predicate)
    {
        return GetEntities().AsNoTracking().Where(predicate);
    }
    public async Task<IEnumerable<TEntity>> FindAsyncNoTracking(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await GetEntities()
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync(cancellationToken) ??
            Enumerable.Empty<TEntity>();
    }

    public IEnumerable<TEntity> GetAll()
    {
        return GetEntities()
            .AsNoTracking()
            .ToList() ??
            Enumerable.Empty<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAsyncAll(CancellationToken cancellationToken)
    {
        return await GetEntities()
            .AsNoTracking()
            .ToListAsync(cancellationToken)??
            Enumerable.Empty<TEntity>();
    }

    public async Task<TEntity> GetAsyncByIdFiltered(TID id, CancellationToken cancellationToken)
    {
        
        var result= await _dbSet.FindAsync(id,cancellationToken);
        return result;
    }

    public TEntity GetByIdFiltered(TID id)
    {
        var result = _dbSet.Find(id);
        return result ;
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
