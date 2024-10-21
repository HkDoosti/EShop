var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInventoryApplication()
    .AddInventoryInfrastructure(builder.Configuration);


builder.Services.AddControllers(options =>
{
    options.Filters.Add<SqlInjectionFilter>();
});



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