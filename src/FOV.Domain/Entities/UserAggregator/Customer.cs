using FOV.Domain.Common;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Domain.Entities.UserAggregator;
public class Customer : BaseAuditableEntity, IsSoftDeleted
{
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }
    public Status Status { get; set; }
    public virtual ICollection<Rating> Rating { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = [];
    public Customer()
    {

    }

    public Customer(string name,string phoneNumber)
    {
        CustomerName = name;
        PhoneNumber = phoneNumber;
    }

    public void UpdateState(bool state)
    {
        Status = state ? Status.Active : Status.Inactive;
        LastModified = DateTime.UtcNow.AddHours(7);
    }

}
