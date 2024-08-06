using Microsoft.AspNetCore.Identity;


namespace FOV.Domain.Entities.UserAggregator;

public class User : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public Customer? Customer { get; set; }
    public Employee? Employee { get; set; }

    public User()
    {

    }

    public User(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = firstName + " " + lastName;
    }
}
