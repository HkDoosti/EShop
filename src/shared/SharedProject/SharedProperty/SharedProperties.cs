
namespace SharedProject.SharedProperty;

public class SharedProperties<T,TEntityId,TUserId>  where T : class
{
    private readonly Assembly assembly = typeof(T).Assembly;
    
    public void ConfigureCommonProperties(ModelBuilder modelBuilder)
    {
        var entityTypes = assembly.GetExportedTypes()
            .Where(t => t.IsClass && 
                        !t.IsAbstract && 
                        typeof(BaseEntity<TEntityId>).IsAssignableFrom(t)
                        );

        foreach (var entityType in entityTypes)
        {
            modelBuilder.Entity(entityType, b => 
            {
                b.Property<bool>("IsDeleted").IsRequired();
                b.Property<DateTime>("CreationDate").IsRequired();
                b.Property<DateTime>("EditionDate");
                 
            }
            );
        }
    }

    public void AddIsDeleteFilter(ModelBuilder modelBuilder)
    {
        foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes())
        {
            var propertyInfo = mutableEntityType.ClrType.GetProperty("IsDeleted");

            if (propertyInfo is not null)
            {
              
                var parameter = Expression.Parameter(mutableEntityType.ClrType);

                BinaryExpression condition = Expression.Equal(Expression.Constant(propertyInfo), Expression.Constant(false));

                 
                var lambdaExpression = Expression.Lambda(condition, parameter);

                 
                lambdaExpression.Compile();

                // set filter
                mutableEntityType.SetQueryFilter(lambdaExpression);
            }
        }
    }

     
}
