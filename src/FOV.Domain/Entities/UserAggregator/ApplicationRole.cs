using Microsoft.AspNetCore.Identity;

namespace FOV.Domain.Entities.UserAggregator;
public class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole() : base()
    {
    }

    public ApplicationRole(string roleName) : base()
    {
        Id = Guid.NewGuid(); // Initialize Id as a new Guid
        Name = roleName;
    }
}
