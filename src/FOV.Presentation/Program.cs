﻿using FluentValidation.AspNetCore;
using FOV.Application;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure;
using FOV.Presentation.Infrastructure;
using OpenTelemetry.Metrics;

var builder = WebApplication.CreateBuilder(args);
var conn = builder.Configuration.GetConnectionString("PostgresConnection");
// Add services to the container
builder.Services.AddControllers();


builder.Services.AddApplicationDI();
builder.Services.AddPresentationDI(conn ?? throw new ArgumentNullException(nameof(conn), "Connection string cannot be null."), builder);
builder.Services.AddInfrastructureDI();

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

app.ApplyMigrations();

await app.InitializeDatabaseAsync();
//app.UseHttpsRedirection();
// Map the default Identity API endpoints except for registration
app.MapIdentityApi<User>();


app.MapPrometheusScrapingEndpoint();
app.UseCookiePolicy();
app.UseAuthorization();
app.UseCors("AllowAllOrigins");
app.MapControllers();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FOV API V1");
});
app.Run();
