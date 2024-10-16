using FOV.Application;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure;
using FOV.Infrastructure.Order.Setup;
using FOV.Presentation.Infrastructure;
using FOV.Presentation.Infrastructure.Middleware;
using OpenTelemetry.Metrics;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);
var conn = builder.Configuration.GetConnectionString("PostgresConnection");
// Add services to the container
builder.Services.AddInfrastructureDI();
builder.Services.AddApplicationDI();
builder.Services.AddControllers();
builder.Services.AddPresentationDI(conn ?? throw new ArgumentNullException(nameof(conn), "Connection string cannot be null."), builder);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.WithOrigins("http://vktrng.ddns.net:8080/")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});


builder.Services.AddOpenTelemetry().WithMetrics(x =>
{
    x.AddPrometheusExporter();
    x.AddMeter("Microsoft.AspNetCore.Hosting",
        "Microsoft.AspNetCore.Server.Kestrel");
    x.AddView("request-duration",
        new ExplicitBucketHistogramConfiguration
        {
            Boundaries = [0, 0.005, 0.01, 0.025, 0.05, 0.075, 0.1, 0.25, 0.5, 0.7]
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

    // Controls how models are expanded in the UI
    c.DefaultModelExpandDepth(0); // Models won't be expanded by default
    c.DefaultModelsExpandDepth(-1); // Disable the "Models" section
    c.DefaultModelRendering(ModelRendering.Example); // Show examples as the default view

    // Displaying additional helpful information
    c.DisplayOperationId(); // Show operation IDs
    c.DisplayRequestDuration(); // Show request duration in the UI

    // Control how endpoints are shown
    c.DocExpansion(DocExpansion.None); // Endpoints are collapsed by default

    // Enable advanced features
    c.EnableDeepLinking(); // Generate links for each section
    c.EnableFilter(); // Adds a filter box to search for operations
    c.ShowExtensions(); // Show vendor extensions in the UI
    c.EnableValidator(); // Enables swagger schema validation

    
});

app.ApplyMigrations();

await app.InitializeDatabaseAsync();
app.UseHttpsRedirection();
// Map the default Identity API endpoints except for registration
app.MapHub<OrderHub>("order-hub").RequireCors("CorsPolicy");
app.MapIdentityApi<User>();
app.UseMiddleware<ExceptionMiddleware>();

app.MapPrometheusScrapingEndpoint();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapControllers();
app.Run();
