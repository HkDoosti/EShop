
namespace Inventory.Application.Mapping;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, AddCategoryCommandRequest>().ReverseMap();
    }
}
