using Inventory.Domain.Shared;

namespace Inventory.Application.Abstractions
{
    public interface ICommand:IRequest<Result>
    {
    }
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
