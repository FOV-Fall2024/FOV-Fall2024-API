using FOV.Domain.Common;
using FOV.Domain.Entities.TableAggregator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Domain.Entities.OrderAggregator
{
    public class Order : BaseAuditableEntity
    {
        public required string OrderStatus { get; set; }
        public required string OrderType { get; set; }
        public required DateTime OrderTime { get; set; }
        public decimal TotalPrice { get; set; }
        public Table? Table { get; set; }
        public Guid TableId { get; set; }
    }
}
