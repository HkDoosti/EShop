namespace Inventory.Application.Command.StuffCommand.AddStuffCommand;

public sealed record AddStuffCommandRequest
(int Id,
    string Code,
    Decimal Price,
    string? Description,
    int CategoryId):ICommand;
    
