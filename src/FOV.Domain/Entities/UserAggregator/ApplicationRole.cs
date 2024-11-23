using Microsoft.AspNetCore.Identity;

namespace FOV.Domain.Entities.UserAggregator;
public class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole() : base()
    {
    }
    public decimal RoleSalary { get; set; }

    public ApplicationRole(string roleName, decimal roleSalary) : base()
    {
        Id = Guid.NewGuid(); // Initialize Id as a new Guid
        Name = roleName;
        RoleSalary = roleSalary;
    }
}
