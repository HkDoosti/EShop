using Inventory.Domain.Errors;

namespace Inventory.Application.Command.CategoryCommand.AddCategoryCommand;

public class AddCategoryCommandRequestValidator
    : AbstractValidator<AddCategoryCommandRequest>
{
    public AddCategoryCommandRequestValidator()
    {
        RuleFor(category => category.ParentId)
            .NotEqual(0).WithMessage(DomainErrors.CategoryErrors.ParentIdCanNotBeZero.Message);

            RuleFor(category => category.Title)
            .NotNull().WithMessage(DomainErrors.CategoryErrors.TitleCanNotBeNull.Message)
            .NotEmpty().WithMessage(DomainErrors.CategoryErrors.TitleCanNotBeEmpty.Message)
            .Length(1, 100).WithMessage(DomainErrors.CategoryErrors.TitleInvalidLength.Message);

        RuleFor(category => category.Description)
            .MaximumLength(2000).WithMessage(DomainErrors.CategoryErrors.DescriptionInvalidLength.Message);

        
    }
   
}
