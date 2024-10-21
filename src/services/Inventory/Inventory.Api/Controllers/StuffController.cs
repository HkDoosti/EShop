namespace Inventory.Api.Controllers;

public class StuffController(ISender sender)
    : InventoryBaseController(sender)
{
}
