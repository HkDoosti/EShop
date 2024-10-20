using Inventory.Domain.Shared;

namespace Inventory.Api.Controllers;
//[SqlInjectionFilter]
[ApiController]
[Route("inventory/api/[controller]/[Action]")]
public abstract class InventoryBaseController(ISender sender) :ControllerBase
{
   
    protected readonly ISender _sender= sender;
    protected IActionResult HandleFailure(Result result) =>
        result switch
        {
            { IsSuccess:true}=> throw new InvalidOperationException(),
            IValidationResult validationResult => BadRequest(
                CreateProblemDetail(
                "Validation Error",
                StatusCodes.Status400BadRequest,
                result.Error,
                validationResult.Errors
                )),
            _=> BadRequest(
                CreateProblemDetail(
                "Bad Request", 
                StatusCodes.Status400BadRequest,
                result.Error 
                ))
        };

    private static ProblemDetails CreateProblemDetail(
        string title,
        int status,
        Error error,
        Error[]? errors = null) =>
        new()
        {
            Title = title,
            Type = error.Code,
            Detail = error.Message,
            Status = status,
            Extensions = { { nameof(errors) ,errors} }

        };
    
}
