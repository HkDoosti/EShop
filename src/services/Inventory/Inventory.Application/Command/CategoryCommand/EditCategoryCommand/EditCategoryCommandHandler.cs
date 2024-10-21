namespace Inventory.Application.Command.CategoryCommand.EditCategoryCommand;

public class EditCategoryCommandHandler(
    ICommandRepository<Category, int> commandRepository,
    ICategoryQueryRepository queryRepository,
     IMapper mapper)
    : IRequestHandler<EditCategoryCommandRequest, Result>
{
    private readonly ICommandRepository<Category, int> _commandRepository = commandRepository;
    private readonly ICategoryQueryRepository _queryRepository = queryRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<Result> Handle(EditCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var category = await _queryRepository
            .GetAsyncByIdFiltered(
           request.Id,
           cancellationToken);

        if (category is null)
        {
            return Result
                .Failure(DomainErrors.CategoryErrors.NotFound(request.Id));
        }
         _mapper.Map(request,category); 
       
        _commandRepository.Update(category);

        await _commandRepository.SaveChangeAsync(cancellationToken);
        return Result.Success();

    }


}
