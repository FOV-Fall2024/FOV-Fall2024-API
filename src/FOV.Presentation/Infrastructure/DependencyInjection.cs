using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Identity;

namespace FOV.Presentation.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationDI(this IServiceCollection services)
        {
            //? Database Configuration
            services.AddOutputCache();
            services.AddIdentityCore<User>()
                      .AddRoles<IdentityRole>()
                      .AddEntityFrameworkStores<FOVContext>()
                      .AddApiEndpoints();

            services.AddDataProtection();

            //? Swagger Configuration
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "Vegetarian Restaurant  API", Version = "v1" });
            });

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

 
}
