
using Inventory.Api;
using Inventory.Application.Behaviors;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    
    .AddInventoryApplication()
    .AddInventoryInfrastructure(builder.Configuration);


builder.Services.AddControllers(options =>
{
    options.Filters.Add<SqlInjectionFilter>();
});

builder.Services.AddValidatorsFromAssembly(assembly: Assemblies.InventoryApplicationAssembly,
    includeInternalTypes:true);

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();


app.MapControllers();

app.Run();