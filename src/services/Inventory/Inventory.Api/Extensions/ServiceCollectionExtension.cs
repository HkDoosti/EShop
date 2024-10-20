

namespace Inventory.Api.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInventoryInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<InventoryDbContext>(option =>
        {
            option.UseNpgsql(configuration.GetConnectionString("InventoryConnectionString"));
        });
         
        return services;
    }
    public static IServiceCollection AddInventoryApplication(this IServiceCollection services)
    {
        //services.AddValidatorsFromAssembly(Assemblies.InventoryApplicationAssembly);
            
        services.AddMediatR(cfg => 
        {
            cfg.RegisterServicesFromAssemblies(Assemblies.InventoryApplicationAssembly);
        });

        services.AddAutoMapper(Assemblies.InventoryApplicationAssembly);

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnhandledBehaviorException<,>));

        services.AddScoped(typeof(IQueryRepository<,>), typeof(QueryRepository<,>));

        services.AddScoped(typeof(ICommandRepository<,>), typeof(CommandRepository<,>));

        services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();

        return services;
    }
    
     
}
