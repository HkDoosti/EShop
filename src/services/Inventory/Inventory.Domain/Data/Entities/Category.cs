namespace Inventory.Domain.Data.Entities;

public class Category : InventoryBaseEntity
{
    public int ParentId { get; set; }
    public string? Description { get; set; }  
    public int Periority { get; set; }
    public ICollection<Stuff>? Stuffs { get; set; }

}
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Title).HasMaxLength(100);
        builder.Property(x => x.Description).HasMaxLength(2000);
    }
}