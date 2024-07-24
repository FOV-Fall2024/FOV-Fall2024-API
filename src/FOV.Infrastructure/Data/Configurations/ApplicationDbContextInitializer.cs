using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.UserAggregator.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace FOV.Infrastructure.Data.Configurations
{


    public class ApplicationDbContextInitializer
    {
        private readonly ILogger<ApplicationDbContextInitializer> _logger;
        private readonly FOVContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, FOVContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
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
            catch (System.Exception ex)
            {

                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }


        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            var administratorsRole = new IdentityRole(Role.Administrator);
            var userRole = new IdentityRole(Role.User);

            await _roleManager.CreateAsync(administratorsRole);
            await _roleManager.CreateAsync(userRole);

            var administrator = new User { UserName = "administrator@localhost", Email = "administrator@localhost" };
            await _userManager.CreateAsync(administrator, "Administrator1!");
            if (!string.IsNullOrWhiteSpace(administratorsRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new[] { administratorsRole.Name });
            }

            await _userManager.AddClaimsAsync(administrator,
          [
              new(nameof(Role), Role.Administrator),
              new(nameof(administrator.UserName), administrator.UserName),
              new(nameof(administrator.Email), administrator.Email)
          ]);

            await _context.SaveChangesAsync();
        }
    }
}
