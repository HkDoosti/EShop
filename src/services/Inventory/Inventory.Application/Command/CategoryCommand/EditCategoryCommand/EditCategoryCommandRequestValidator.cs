
namespace Inventory.Application.Command.CategoryCommand.EditCategoryCommand;

public sealed class EditCategoryCommandRequestValidator
    : AbstractValidator<EditCategoryCommandRequest>
{
    public EditCategoryCommandRequestValidator()
    {
        RuleFor(category => category.Id)
           .NotNull().NotEqual(0);

        RuleFor(category => category.Title)
            .NotNull().WithMessage(DomainErrors.CategoryErrors.TitleCanNotBeNull.Message)
            .NotEmpty().WithMessage(DomainErrors.CategoryErrors.TitleCanNotBeEmpty.Message)
            .Length(1, 100).WithMessage(DomainErrors.CategoryErrors.TitleInvalidLength.Message);

        RuleFor(category => category.Description)
            .MaximumLength(2000).WithMessage(DomainErrors.CategoryErrors.DescriptionInvalidLength.Message);

        
    }
   
}
