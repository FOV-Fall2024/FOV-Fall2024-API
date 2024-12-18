using System.Linq;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using FOV.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Testcontainers.PostgreSql;
using Xunit;

public class IntegrationTestWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    // Create a PostgreSQL Testcontainer
    private readonly PostgreSqlContainer _postgresSqlContainer = new PostgreSqlBuilder()
        .WithImage("postgres:15")                            // Specify the PostgreSQL version
        .WithDatabase("RestaurantManagementDatabase")         // Database name
        .WithUsername("admin")                                // Username for the database
        .WithPassword("admin")                                // Password for the database
        .Build();

    // Start the PostgreSQL container asynchronously before tests run
    public Task InitializeAsync()
    {
        return _postgresSqlContainer.StartAsync();
    }

    // Configure the web host to use the PostgreSQL container's connection string
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            // Remove the existing DbContext configuration
            var descriptor = services.SingleOrDefault(x => x.ServiceType == typeof(DbContextOptions<FOVContext>));
            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            // Add the DbContext with the PostgreSQL container's connection string
            services.AddDbContext<FOVContext>(options =>
                options.UseNpgsql(_postgresSqlContainer.GetConnectionString()));
        });
    }

    // Stop the PostgreSQL container asynchronously after tests complete
    public Task DisposeAsync()
    {
        return _postgresSqlContainer.StopAsync();
    }
}
