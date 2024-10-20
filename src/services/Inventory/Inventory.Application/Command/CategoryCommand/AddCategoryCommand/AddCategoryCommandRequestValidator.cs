namespace Inventory.Application.Command.CategoryCommand.AddCategoryCommand;

public class AddCategoryCommandRequestValidator
    : AbstractValidator<AddCategoryCommandRequest>
{
    public AddCategoryCommandRequestValidator()
    {
        RuleFor(category => category.ParentId)
            .NotEqual(0).WithMessage("Category ParentId cannot be zero.");

         
          
    

            RuleFor(category => category.Title)
            .NotNull().WithMessage("Category Title can not bee null.")
            .NotEmpty().WithMessage("Category Title is required.")
            .Length(1, 100).WithMessage("Category Title must be between 1 and 100 characters.");

        RuleFor(category => category.Description)
            .MaximumLength(2000).WithMessage("Category Description must have less than 2000 characters.");

        
    }
   
}
