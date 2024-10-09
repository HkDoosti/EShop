namespace Inventory.Infrastructure.Data;
public class InventoryDbContext(DbContextOptions options) : DbContext(options)
{
    SharedProperties<InventoryDomainAssembly, int, int> sharedProperties = new SharedProperties<InventoryDomainAssembly, int, int>();
    public DbSet<Stuff> Stuffs { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         
         sharedProperties.ConfigureCommonProperties(modelBuilder);
         sharedProperties.AddIsDeleteFilter(modelBuilder);
       
    }
}

