using FOV.Infrastructure;
using FOV.Presentation.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructureDI(conn);
builder.Services.AddPresentationDI();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.InitializeDatabaseAsync();
app.UseHttpsRedirection();
await app.AuthenticationEndPoint();
app.UseAuthorization();

app.MapControllers();

app.Run();
