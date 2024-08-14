using FOV.Application;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure;
using FOV.Presentation.Infrastructure;
using Hangfire;

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

//? Background Servie


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

// Use Hangfire dashboard.
app.UseHangfireDashboard();

// Add a recurring job.
RecurringJob.AddOrUpdate(
    "daily-email-job",
    () => Console.WriteLine("Sending daily email..."),
    Cron.Daily(8) // Runs every day at 8 AM
);

app.Run();

app.Run();
