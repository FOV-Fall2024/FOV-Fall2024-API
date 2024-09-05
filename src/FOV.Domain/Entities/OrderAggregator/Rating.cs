using System.Drawing;
using FOV.Domain.Common;

namespace FOV.Domain.Entities.OrderAggregator;
public class Rating : BaseAuditableEntity
{
    public int RatingStart { get; set; }

    public string Comment { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public Order? Order { get; set; }

    public Guid OrderId { get; set; }

    public int UsefulQuantity { get; set; }

    public int NonUsefulQuantity { get; set; }
}
