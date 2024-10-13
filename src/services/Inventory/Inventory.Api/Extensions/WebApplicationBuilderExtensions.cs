
namespace Inventory.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddInventoryDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<InventoryDbContext>(option =>
        {
            option.UseNpgsql(builder.Configuration.GetConnectionString("InventoryConnectionString"));
        });
    }
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped(typeof( IQueryRepository<,>), typeof(QueryRepository<,>));
        builder.Services.AddScoped(typeof( ICommandRepository<,>), typeof(CommandRepository<,>));
    }
    }
