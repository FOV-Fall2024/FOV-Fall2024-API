using FOV.Application;
using FOV.Infrastructure.Notifications.Web.SignalR.Notification.Setup;
using FOV.Infrastructure.Notifications.Web.SignalR.Order.Setup;
using FOV.Infrastructure;
using FOV.Presentation.Infrastructure.Middleware;
using FOV.Presentation.Infrastructure;
using OpenTelemetry.Metrics;
using Prometheus;
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
    x.AddMeter("Microsoft.AspNetCore.Hosting", "Microsoft.AspNetCore.Server.Kestrel");
    x.AddView("request-duration", new ExplicitBucketHistogramConfiguration
    {
        Boundaries = [0, 0.005, 0.01, 0.025, 0.05, 0.075, 0.1, 0.25, 0.5, 0.7]
    });
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.DefaultModelExpandDepth(0);
    c.DefaultModelsExpandDepth(-1);
    c.DefaultModelRendering(ModelRendering.Example);
    c.DisplayOperationId();
    c.DisplayRequestDuration();
    c.DocExpansion(DocExpansion.None);
    c.EnableDeepLinking();
    c.EnableFilter();
    c.ShowExtensions();
    c.EnableValidator();
});

app.ApplyMigrations();

await app.InitializeDatabaseAsync();

app.UseHttpsRedirection();

// Add UseRouting here before UseEndpoints
app.UseRouting();

// Middleware that runs after routing and before endpoints
app.UseMiddleware<ExceptionMiddleware>();

app.UseCookiePolicy();
app.UseHttpMetrics();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("CorsPolicy");

// Map the default Identity API endpoints except for registration
app.MapHub<OrderHub>("order-hub").RequireCors("CorsPolicy");
app.MapHub<NotificationHub>("notification-hub").RequireCors("CorsPolicy");
// app.MapIdentityApi<User>();

// UseEndpoints after UseRouting
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapMetrics(); // This exposes the /metrics endpoint for Prometheus
    endpoints.MapPrometheusScrapingEndpoint();
});

app.Run();
