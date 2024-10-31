using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;
using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Domain.Entities.UserAggregator;
public class Customer : BaseAuditableEntity, IsSoftDeleted
{

    public string Address { get; set; } = string.Empty;
    public int Point { get; set; } = 0;
    public User? User { get; set; }
    public string UserId { get; set; } = string.Empty;
    public Status Status { get; set; }

    public Customer()
    {

    }

    public Customer(string address, string userId, int point)
    {
        UserId = userId;
        Address = address;
        Point = point;
    }

    public void UpdateState(bool state)
    {
        Status = state ? Status.Active : Status.Inactive;
        LastModified = DateTime.UtcNow.AddHours(7);
    }

    public void Update(string address)
    {
        Address = address;
    }

}
