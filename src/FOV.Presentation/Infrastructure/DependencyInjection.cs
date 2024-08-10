using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;

namespace FOV.Presentation.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationDI(this IServiceCollection services, string connectionString, WebApplicationBuilder builder)
    {

        services.AddOutputCache();
        services.AddDbContextPool<FOVContext>(options => options.UseNpgsql(connectionString));
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
        services.AddIdentityCore<User>()
                  .AddRoles<IdentityRole>()
                  .AddEntityFrameworkStores<FOVContext>()
                  .AddApiEndpoints();

        //? Add JWT Settings
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme =
            options.DefaultChallengeScheme =
            options.DefaultForbidScheme =
            options.DefaultScheme =
            options.DefaultSignInScheme =
            options.DefaultSignOutScheme =
                JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                RequireExpirationTime = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                  System.Text.Encoding.UTF8.GetBytes(
                      builder.Configuration["JWT:SecretKey"])
              )
            };
        });

        //? Swagger Configuration
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "Vegetarian Restaurant  API", Version = "v1" });
        });
        services.AddDataProtection();

        return services;
    }

    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();

        await initializer.InitialiseAsync();

        await initializer.SeedAsync();


    }
}
