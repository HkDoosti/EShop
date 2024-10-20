using Inventory.Domain.Shared;

namespace Inventory.Application.Abstractions;

public interface IQuery<TResponse>:IRequest<Result<TResponse>>
{
}
