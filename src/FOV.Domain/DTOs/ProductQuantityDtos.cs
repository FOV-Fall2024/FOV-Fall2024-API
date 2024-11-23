using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Infrastructure.DTOs.ProductQuantity;
public class ProductQuantityDtos
{
    public Guid DishId { get; set; }
    public string DishName { get; set; }
    public int TotalQuantity { get; set; }
}
