using FOV.Domain.Common;

namespace FOV.Domain.ElasticEntities;
public class UserDomain : ElasticEntity
{
    public override string DefaultName { get; set; } = "user";

    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}
