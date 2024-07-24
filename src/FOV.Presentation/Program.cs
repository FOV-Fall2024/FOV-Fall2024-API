using FOV.Application;
using FOV.Infrastructure;
using FOV.Presentation.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var conn = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationDI();
builder.Services.AddPresentationDI(conn ?? throw new ArgumentNullException(nameof(conn), "Connection string cannot be null."));
builder.Services.AddInfrastructureDI();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//await app.InitializeDatabaseAsync();
app.UseHttpsRedirection();
app.AuthenticationEndPoint();
app.UseAuthorization();

app.MapControllers();

app.Run();
