using System.Security.Claims;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.UserAggregator.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace FOV.Infrastructure.Data.Configurations;



public class ApplicationDbContextInitializer
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger;
    private readonly FOVContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;


    public ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, FOVContext context, UserManager<User> userManager, RoleManager<ApplicationRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Npgsql.PostgresException ex) when (ex.SqlState == "42P07")
        {
            // Specific handling for "relation already exists" error
            _logger.LogWarning(ex, "The table already exists. Skipping migration.");
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing the database.");
            throw;
        }
    }


    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        var administratorsRole = new ApplicationRole(Role.Administrator);

        if (!await _roleManager.RoleExistsAsync(Role.Waiter.ToString()))
        {
            var role = new ApplicationRole(Role.Waiter.ToString());
            await _roleManager.CreateAsync(role);
        }

        if (!await _roleManager.RoleExistsAsync(Role.Manager))
        {
            var managerRole = new ApplicationRole(Role.Manager);
            await _roleManager.CreateAsync(managerRole);
        }

        if (!await _roleManager.RoleExistsAsync(Role.Chef))
        {
            var chefRole = new ApplicationRole(Role.Chef);
            await _roleManager.CreateAsync(chefRole);
        }

        if (!await _roleManager.RoleExistsAsync(Role.HeadChef))
        {
            var headChefRole = new ApplicationRole(Role.HeadChef);
            await _roleManager.CreateAsync(headChefRole);
        }

        if (!await _roleManager.RoleExistsAsync(administratorsRole.Name))
        {
            await _roleManager.CreateAsync(administratorsRole);
        }

        var administrator = await _userManager.FindByEmailAsync("administrator@localhost");
        if (administrator == null)
        {
            administrator = new User { UserName = "administrator@localhost", Email = "administrator@localhost", FullName = "Admin", PhoneNumber = "0867960120", EmployeeCode = "ADM_000", HireDate = DateTime.UtcNow, Status = Domain.Entities.TableAggregator.Enums.Status.Active };
            await _userManager.CreateAsync(administrator, "Administrator1!");

            if (!string.IsNullOrWhiteSpace(administratorsRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new[] { administratorsRole.Name });
            }

            await _userManager.AddClaimsAsync(administrator, new[]
            {
    new Claim(nameof(Role), Role.Administrator),
    new Claim(nameof(administrator.UserName), administrator.UserName),
    new Claim(nameof(administrator.Email), administrator.Email)
});
        }
        await _context.SaveChangesAsync();
    }
}
