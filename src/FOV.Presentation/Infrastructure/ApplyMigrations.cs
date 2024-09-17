using FOV.Infrastructure.Data;
using FOV.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace FOV.Presentation.Infrastructure;

public static class MigrationExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using FOVContext dbContext = scope.ServiceProvider.GetRequiredService<FOVContext>();

        try
        {
            dbContext.Database.Migrate();
        }
        catch (NpgsqlException ex) when (ex.Message.Contains("relation \"AspNetRoles\" already exists"))
        {
            // Handle the specific exception
            Console.WriteLine("Table already exists. Skipping migration.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }
}

