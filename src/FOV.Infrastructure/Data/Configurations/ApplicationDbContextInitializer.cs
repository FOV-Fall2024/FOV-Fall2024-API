﻿using System.Security.Claims;
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            var administratorsRole = new IdentityRole(Role.Administrator);
            var userRole = new IdentityRole(Role.User);

            if (!await _roleManager.RoleExistsAsync(Role.Waiter))
            {
                await _roleManager.CreateAsync(new IdentityRole(Role.Waiter));
            }
            if (!await _roleManager.RoleExistsAsync(Role.Manager))
            {
                await _roleManager.CreateAsync(new IdentityRole(Role.Manager));
            }
            if (!await _roleManager.RoleExistsAsync(Role.Cook))
            {
                await _roleManager.CreateAsync(new IdentityRole(Role.Cook));
            }
            if (!await _roleManager.RoleExistsAsync(administratorsRole.Name))
            {
                await _roleManager.CreateAsync(administratorsRole);
            }
            if (!await _roleManager.RoleExistsAsync(userRole.Name))
            {
                await _roleManager.CreateAsync(userRole);
            }

            var administrator = await _userManager.FindByEmailAsync("administrator@localhost");
            if (administrator == null)
            {
                administrator = new User { UserName = "administrator@localhost", Email = "administrator@localhost" };
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
}
