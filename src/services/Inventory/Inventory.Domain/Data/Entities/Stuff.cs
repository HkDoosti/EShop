namespace Inventory.Domain.Data.Entities;

public class Stuff: InventoryBaseEntity
{
    public string Code { get; set; }  
    public Decimal Price { get; set; }
    public string? Description { get; set; } 
    public int CategoryId { get; set; }
    public Category Category { get; set; }
  
}
public class StuffConfiguration : IEntityTypeConfiguration<Stuff>
{
    public void Configure(EntityTypeBuilder<Stuff> builder)
    {
        
        builder.Property(x => x.Title).HasMaxLength(100);
        builder.Property(x => x.Code).HasMaxLength(10);
        builder.Property(x => x.Description).HasMaxLength(2000);
        builder.HasIndex(x => x.Code).IsUnique();
    }
}