using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Domain.Entities.IngredientSupplyRequestAggregator.Enum;
public enum SupplyRequestType : byte
{
    PENDING = 0,
    APPROVED = 1,
    REJECTED = 2,
}


