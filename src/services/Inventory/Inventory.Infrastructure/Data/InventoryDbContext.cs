using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Inventory.Infrastructure.Data;
public class InventoryDbContext(DbContextOptions options) : DbContext(options)
{
    SharedProperties<InventoryDomainAssembly, int, int> sharedProperties = new SharedProperties<InventoryDomainAssembly, int, int>();
    public DbSet<Stuff> Stuffs { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new StuffConfiguration());

        sharedProperties.ConfigureCommonProperties(modelBuilder);
         sharedProperties.AddIsDeleteFilter(modelBuilder);
       
    }
    public override EntityEntry Remove(object entity)
   
    {
        var entry = Entry(entity);
        if (entry.State == EntityState.Detached)
        {
            Attach(entity);
            entry = Entry(entity);
        }

        entry.CurrentValues["IsDeleted"] = true; 
        entry.CurrentValues["DeletedDateTime"] = DateTime.UtcNow;
        entry.State = EntityState.Modified;  
        return entry;
    }
    public override EntityEntry<TEntity> Remove<TEntity>(TEntity entity)
    {
        var entry = Entry(entity);
        if (entry.State == EntityState.Detached)
        {
            Attach(entity);
            entry = Entry(entity);
        }

        entry.CurrentValues["IsDeleted"] = true;
        entry.CurrentValues["DeletedDateTime"] = DateTime.UtcNow;
        entry.State = EntityState.Modified;
        return entry;
    }
}

