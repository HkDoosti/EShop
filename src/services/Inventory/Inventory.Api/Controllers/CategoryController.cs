namespace Inventory.Api.Controllers;

public class CategoryController(ISender sender) 
    : InventoryBaseController(sender)
{
    
    [HttpPost]
    public async Task<IActionResult> Add(AddCategoryCommandRequest addCategory, CancellationToken cancellationToken)
    {
       var res= await _sender.Send(addCategory,cancellationToken);
        if(res.IsFailure)
        {
           return HandleFailure(res);
        }
        return Ok(res);
    }
}
