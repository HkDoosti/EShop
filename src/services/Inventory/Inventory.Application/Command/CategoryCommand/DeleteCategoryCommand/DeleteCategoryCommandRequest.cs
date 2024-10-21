namespace Inventory.Application.Command.CategoryCommand.DeleteCategoryCommand;

public sealed record DeleteCategoryCommandRequest
(int Id)
    :ICommand;
