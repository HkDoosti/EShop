
namespace Inventory.Domain.Data.Entities;

public abstract class InventoryBaseEntity<TID>: BaseEntity<TID>
{
    public TID Id { get; set; }
    public bool IsActive { get; set; } = true;
    public string Title { get; set; }  
}
public abstract class InventoryBaseEntity : InventoryBaseEntity<int>
{
}
