using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Domain.Entities.DishAggregator.Enums;
public enum DishIngredientStatus : byte
{
    Normal = 0,
    UpdateQuantity = 1,
    RecentRemove = 2,
    InComing  = 3,

}
