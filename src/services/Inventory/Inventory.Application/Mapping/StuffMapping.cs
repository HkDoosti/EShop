using Inventory.Application.Command.CategoryCommand.AddCategoryCommand;
using Inventory.Application.Command.StuffCommand.AddStuffCommand;
using Inventory.Domain.Data.Entities;

namespace Inventory.Application.Mapping;

public class StuffMapping : Profile
{
    public StuffMapping()
    {
        CreateMap<Stuff, AddStuffCommandRequest>().ReverseMap();
        
    }
}
