

namespace Inventory.Api.Controllers;

public class CategoryController(ISender sender)
    : InventoryBaseController(sender)
{

    [HttpPost]
    public async Task<IActionResult> Add(AddCategoryCommandRequest addCategory, CancellationToken cancellationToken)
    {
        var res = await _sender.Send(addCategory, cancellationToken);
        if (res.IsFailure)
        {
            return HandleFailure(res);
        }
        return Ok(res);
    }
    [HttpPost]
    public async Task<IActionResult> Delete(DeleteCategoryCommandRequest deleteCategory, CancellationToken cancellationToken)
    {
        var res = await _sender.Send(deleteCategory, cancellationToken);
        if (res.IsFailure)
        {
            return HandleFailure(res);
        }
        return Ok(res);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(EditCategoryCommandRequest editCategory, CancellationToken cancellationToken)
    {
        var res = await _sender.Send(editCategory, cancellationToken);
        if (res.IsFailure)
        {
            return HandleFailure(res);
        }
        return Ok(res);
    }
}
