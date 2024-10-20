namespace Inventory.Application.Command.CategoryCommand.AddCategoryCommand;

public sealed record AddCategoryCommandRequest
(
     int Id,
     string Title,
     string? Description,
     int? ParentId
) : ICommand;
