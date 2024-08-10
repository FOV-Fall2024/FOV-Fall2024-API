using FOV.Application;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure;
using FOV.Presentation.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var conn = builder.Configuration.GetConnectionString("PostgresConnection");
// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationExceptionFilter>();
});


builder.Services.AddApplicationDI();
builder.Services.AddPresentationDI(conn ?? throw new ArgumentNullException(nameof(conn), "Connection string cannot be null."), builder);
builder.Services.AddInfrastructureDI();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.InitializeDatabaseAsync();
app.UseHttpsRedirection();
// Map the default Identity API endpoints except for registration
app.MapIdentityApi<User>();

// Map custom registration endpoint
//app.AddCustomEndpoints();

app.UseAuthorization();

app.MapControllers();

app.Run();
