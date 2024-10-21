namespace Inventory.Infrastructure.Repository;

public class CommandRepository<TEntity, TID>(InventoryDbContext context)
    : ICommandRepository<TEntity, TID>, IDisposable
    where TEntity : BaseEntity<TID>
{
    private readonly InventoryDbContext _context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    private bool disposedValue;

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public void Delete(TEntity entity)
    {
        _context.Remove(entity);
        //_context.Entry(entity).Property<bool>("IsDeleted").CurrentValue = true;
    }

    public void SaveChange()
    {
        _context.SaveChanges();
    }
    

    public async Task<bool> SaveChangeAsync(CancellationToken cancellationToken)
    {
     return await  _context.SaveChangesAsync(cancellationToken)>0;
    }

    public void Update(TEntity entity)
    {
          _context.Entry(entity).State = EntityState.Modified;  
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
