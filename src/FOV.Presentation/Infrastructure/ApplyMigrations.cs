using FOV.Infrastructure.Data;
using FOV.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FOV.Presentation.Infrastructure;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using FOVContext dbContext = scope.ServiceProvider.GetRequiredService<FOVContext>();

        dbContext.Database.Migrate();
    }
}

