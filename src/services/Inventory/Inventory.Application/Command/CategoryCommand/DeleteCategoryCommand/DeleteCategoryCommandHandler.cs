namespace Inventory.Application.Command.CategoryCommand.DeleteCategoryCommand;

public class DeleteCategoryCommandHandler (
    ICommandRepository<Category, int> commandRepository,
    IQueryRepository<Category, int> queryRepository)
    : IRequestHandler<DeleteCategoryCommandRequest, Result>
{
   private readonly ICommandRepository<Category, int> _commandRepository= commandRepository;

   private readonly IQueryRepository<Category, int> _queryRepository= queryRepository;

    public async Task<Result> Handle(
        DeleteCategoryCommandRequest request, 
        CancellationToken cancellationToken)
    {
       var category= await _queryRepository
            .GetAsyncByIdFiltered(
           request.Id, 
           cancellationToken);

        if (category is null)
        {
            return Result
                .Failure(DomainErrors.CategoryErrors.NotFound(request.Id));
        }
        _commandRepository.Delete(category);

        await _commandRepository.SaveChangeAsync(cancellationToken);

        return Result.Success(category);
    }
}
