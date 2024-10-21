namespace Inventory.Application.Command.CategoryCommand.EditCategoryCommand;

public sealed record EditCategoryCommandRequest
(
     int Id,
     string Title,
     string? Description
) : ICommand;
