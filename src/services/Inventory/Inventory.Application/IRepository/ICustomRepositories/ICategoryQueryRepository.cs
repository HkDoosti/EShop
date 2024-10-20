 
namespace Inventory.Application.IRepository.ICustomRepositories;

public interface ICategoryQueryRepository
{
    Task<Category> GetIncludeSubCategoriesById(int id, CancellationToken cancellationToken);
    //Task<Category> GetCountCategories(int id, CancellationToken cancellationToken);
    bool isDeleteFilterActive { get; set; }
    Task<int> CountAsync(Expression<Func<Category, bool>> predicate, CancellationToken cancellationToken);
    Task<Category> GetAsyncByIdFiltered(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Category>> GetAsyncAll(CancellationToken cancellationToken);
    Task<IEnumerable<Category>> FindAsyncTracking(Expression<Func<Category, bool>> predicate, CancellationToken cancellationToken);
    Task<IEnumerable<Category>> FindAsyncNoTracking(Expression<Func<Category, bool>> predicate, CancellationToken cancellationToken);
    Category GetByIdFiltered(int id);
    IEnumerable<Category> GetAll();
    IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate);
    IQueryable<Category> FindQueryable(Expression<Func<Category, bool>> predicate);

}
