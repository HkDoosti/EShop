
namespace Inventory.Domain.Data.Entities;

public class Category : InventoryBaseEntity
{
    public string? Description { get; set; }  
    public SqlHierarchyId Code { get; set; }
    public int? ParentId { get; set; }
    public Category Parent { get; set; }
    public ICollection<Stuff>? Stuffs { get; set; }
    public void GenerateHierarchyCode(Category parent)
    {
        if (parent == null)
        {
            Code = SqlHierarchyId.Parse("/"); // Root  
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(parent.Code.ToString());
            sb.Append("/");
            sb.Append((parent.Subcategories.Count() + 1).ToString());
            Code = SqlHierarchyId.Parse(sb.ToString());
        }
    }

    public ICollection<Category> Subcategories { get; set; } = new List<Category>();

}
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        var hierarchyIdConverter = new ValueConverter<SqlHierarchyId, string>(
    v => v.ToString(),
    v => SqlHierarchyId.Parse(v));
        builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Code).HasMaxLength(20).HasConversion(hierarchyIdConverter);
        builder.Property(x => x.Description).HasMaxLength(2000);
        builder.HasIndex(x=>x.Code).IsUnique();
    }
}