



namespace Inventory.Api.Extensions;

public static class ExtensionClass
{
    public static void AddInventoryDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<InventoryDbContext>(option =>
        {
            option.UseNpgsql(builder.Configuration.GetConnectionString("InventoryConnectionString"));
        });
    }
}
