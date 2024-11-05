using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;
using FOV.Domain.Entities.IngredientSupplyRequestAggregator.Enum;

namespace FOV.Domain.Entities.IngredientSupplyRequestAggregator;
public class IngredientSupplyRequest : BaseAuditableEntity
{
    public string RequestCode { get; set; } = string.Empty;

    public SupplyRequestType Type { get; set; }

    public virtual ICollection<IngredientSupplyRequestDetail> IngredientSupplyRequestDetails { get; set; }
    public IngredientSupplyRequest()
    {
        
    }
}
