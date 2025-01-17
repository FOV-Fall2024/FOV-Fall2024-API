﻿using System.Text;
using FluentValidation;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Configuration;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Data.Configurations;
using FOV.Presentation.Infrastructure.BackgroundServer;
using Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

namespace FOV.Presentation.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationDI(this IServiceCollection services, string connectionString, WebApplicationBuilder builder)
    {

        //? Add Els
        services.Configure<ElasticSettings>(builder.Configuration.GetSection("ElasticSettings"));
        services.AddValidatorsFromAssembly(typeof(Program).Assembly);


        //? Add SignalR
        services.AddSignalR();

        //? Add CQRS
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
                builder => builder
                    .AllowAnyOrigin()  // Allow any origin (you can restrict this to specific origins)
                    .AllowAnyMethod()  // Allow any HTTP method (GET, POST, etc.)
                    .AllowAnyHeader()); // Allow any headers
        });
        //? Hang Fire Adding
        //services.AddHostedService<ScheduleCronJobWorker>();
        //services.AddHostedService<CheckIngredientWorker>();
        //services.AddHostedService<ScheduleCheckIngredientDailyWorker>();

        //? Background Servie

        services.AddOutputCache();
        services.AddDbContextPool<FOVContext>(options =>
        {
            options.UseNpgsql(connectionString);
            options.EnableSensitiveDataLogging();
        });
        services.AddScoped<ApplicationDbContextInitializer>();
        services.AddSingleton(TimeProvider.System);

        //? Redis Configuration

        services.AddSingleton<IConnectionMultiplexer>(sp =>
        {
            var configuration = ConfigurationOptions.Parse(builder.Configuration["ConnectionStrings:RedisConnection"], true);
            return ConnectionMultiplexer.Connect(configuration);
        });
        services.AddScoped<IDatabase>(sp =>
        {
            var connectionMultiplexer = sp.GetRequiredService<IConnectionMultiplexer>();
            return connectionMultiplexer.GetDatabase();
        });



        //? Database Configuration
        builder.Services.AddIdentity<User, ApplicationRole>()
 .AddEntityFrameworkStores<FOVContext>()
 .AddDefaultTokenProviders();
        //        builder.Services.AddIdentity<User1, IdentityRole>()
        //.AddEntityFrameworkStores<ApplicationDbContext, Guid>()
        //.AddDefaultTokenProviders();
        //services.AddIdentity<User, IdentityRole<Guid>>()
        //        .AddEntityFrameworkStores<FOVContext>()



        //services.AddIdentity<User, IdentityRole>()
        // .AddEntityFrameworkStores<FOVContext>()
        // .AddDefaultTokenProviders();

        // Register RoleManager
        services.AddScoped<RoleManager<ApplicationRole>>();



        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
     .AddJwtBearer(options =>
     {
         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidateLifetime = true,
             ValidateIssuerSigningKey = true,
             ValidIssuer = builder.Configuration["JWTSecretKey:ValidIssuer"],
             ValidAudience = builder.Configuration["JWTSecretKey:ValidAudience"],
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTSecretKey:SecretKey"])),
             ClockSkew = TimeSpan.FromSeconds(1)

         };
         options.Events = new JwtBearerEvents
         {
             OnChallenge = context =>
             {
                 // Skip the default challenge behavior
                 context.HandleResponse();

                 // Return a custom response message for 401 Unauthorized
                 context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                 context.Response.ContentType = "application/json";
                 var result = Newtonsoft.Json.JsonConvert.SerializeObject(new
                 {
                     message = "You need to log in to access this resource."
                 });
                 return context.Response.WriteAsync(result);
             }
         };
     });




        services.Configure<CookiePolicyOptions>(options =>
        {
            options.MinimumSameSitePolicy = SameSiteMode.None;
            options.Secure = CookieSecurePolicy.Always;
        });

        //? Swagger Configuration
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "FOV API", Version = "v1" });
            c.EnableAnnotations();
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid JWT token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer",
            });
            c.OperationFilter<AuthorizeOperationFilter>();

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
        });
        services.AddDataProtection();

        return services;
    }

    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        //? Add Error Handler
        app.UseMiddleware<ErrorHandlerMiddleware>();

        using var scope = app.Services.CreateScope();
        var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();

        await initializer.InitialiseAsync();

        await initializer.SeedAsync();


    }
}
