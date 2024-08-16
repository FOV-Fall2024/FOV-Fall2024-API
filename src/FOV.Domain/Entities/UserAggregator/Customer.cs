using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;

namespace FOV.Domain.Entities.UserAggregator;
public class Customer : BaseAuditableEntity, IsSoftDeleted
{
    // update vaule object soon
    public bool IsDeleted { get; set; }

    public string Address { get; set; } = string.Empty;

    public User? User { get; set; }
    public string UserId { get; set; } = string.Empty;

    public Customer()
    {

    }

    public Customer(string address, string userId)
    {
        UserId = userId;
        Address = address;
    }

    public void UpdateState(bool isDeleted) => IsDeleted = isDeleted;

}
