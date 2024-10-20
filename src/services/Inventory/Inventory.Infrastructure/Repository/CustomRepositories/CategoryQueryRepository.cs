
namespace Inventory.Infrastructure.Repository.CustomRepositories;

public class CategoryQueryRepository(InventoryDbContext dbContext)
    : QueryRepository<Category, int>(dbContext), ICategoryQueryRepository
{
    public async Task<Category> GetIncludeSubCategoriesById(int id, CancellationToken cancellationToken)
    {
      return await _context.Categories
            .Include(x=>x.Subcategories)
            .AsNoTracking()
            .FirstOrDefaultAsync(x=>x.Id == id,cancellationToken)
            ;    
    }
}
