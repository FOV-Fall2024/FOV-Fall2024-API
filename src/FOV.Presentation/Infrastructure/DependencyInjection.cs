using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Data.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FOV.Presentation.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationDI(this IServiceCollection services, string connectionString)
        {
            services.AddOutputCache();
            services.AddDbContextPool<FOVContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<ApplicationDbContextInitializer>();
            services.AddSingleton(TimeProvider.System);

            //? Database Configuration
            services.AddIdentityCore<User>()
                      .AddRoles<IdentityRole>()
                      .AddEntityFrameworkStores<FOVContext>()
                      .AddApiEndpoints();
            services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

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


}
