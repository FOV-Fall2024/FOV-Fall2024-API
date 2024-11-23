using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Domain.Entities.ShiftAggregator;
public class ShiftRestaurant : BaseAuditableEntity, IsSoftDeleted
{
    public Restaurant? Restaurant { get; set; }
    public Guid? RestaurantId { get; set; }
    public Shift? Shift { get; set; }
    public Guid? ShiftId { get; set; }
    public DateOnly Date { get; set; }
    public string? Url { get; set; }
    public Status Status { get; set; }
}
