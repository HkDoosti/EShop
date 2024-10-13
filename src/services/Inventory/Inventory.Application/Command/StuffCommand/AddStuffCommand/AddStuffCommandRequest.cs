namespace Inventory.Application.Command.StuffCommand.AddStuffCommand;

public class AddStuffCommandRequest
{
    public required string Code { get; set; }
    public Decimal Price { get; set; }
    public string? Description { get; set; }
    public int CategoryId { get; set; }
}
