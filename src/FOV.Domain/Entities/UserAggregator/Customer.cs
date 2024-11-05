using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using static QRCoder.PayloadGenerator;

namespace FOV.Domain.Entities.UserAggregator;
public class Customer : BaseAuditableEntity, IsSoftDeleted
{
    public int Point { get; set; } = 0;
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public Status Status { get; set; }
    public ICollection<Order> Orders { get; set; } = [];
    public Customer()
    {

    }
    public Customer(string phoneNumber, string fullName)
    {
        PhoneNumber = phoneNumber;
        FullName = fullName;
        Point = 0;
    }
    public void UpdateState(bool state)
    {
        Status = state ? Status.Active : Status.Inactive;
        LastModified = DateTime.UtcNow.AddHours(7);
    }
    public void Update(string phoneNumber, string fullName)
    {
        PhoneNumber = phoneNumber;
        FullName = fullName;
    }
}
