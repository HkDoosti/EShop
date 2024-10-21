namespace Inventory.Application.Command.CategoryCommand.DeleteCategoryCommand;

public sealed class DeleteCategoryCommandRequestValidator:AbstractValidator<DeleteCategoryCommandRequest>
{
    public DeleteCategoryCommandRequestValidator()
    {
        RuleFor(category => category.Id)
            .NotNull().NotEqual(0);
    }
}
