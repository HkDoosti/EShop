namespace Inventory.Application.Behaviors;

public sealed class UnhandledBehaviorException<TRequest, TResponse>
    (IEnumerable<IValidator<TRequest>> validators,
    ILogger<TRequest> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TRequest>
    where TResponse : class
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;
    private readonly ILogger<TRequest> _logger= logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try 
        {
          return await  next();
        }
        catch (Exception e)
        {
            throw;
        }
          
    }
}
