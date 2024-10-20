using Inventory.Domain.Shared;

namespace Inventory.Application.Command.CategoryCommand.AddCategoryCommand;

public class AddCategoryCommandHandler(
    ICommandRepository<Category, int> commandRepository,
    ICategoryQueryRepository queryRepository,
     IMapper mapper)
    : IRequestHandler<AddCategoryCommandRequest, Result>
{
    private readonly ICommandRepository<Category, int> _commandRepository = commandRepository;
    private readonly ICategoryQueryRepository _queryRepository = queryRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<Result> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
    {
         
            var category = _mapper.Map<Category>(request);
            var countAllParent = 0;
            Category? parent = null;
            if (category.ParentId is not null)
            {
                parent = await _queryRepository.GetIncludeSubCategoriesById(category.ParentId ?? 0, cancellationToken);
                
            }
            else
            {
                _queryRepository.isDeleteFilterActive = false;
                countAllParent = await _queryRepository.CountAsync(x => x.ParentId == null, cancellationToken);
            }
            category.GenerateHierarchyCode(parent, countAllParent);
            _commandRepository.Add(category);

             await _commandRepository.SaveChangeAsync(cancellationToken);
        return Result.Success();
         
    }

     
}
