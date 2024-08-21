using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Domain.Entities.DTOs;
public class ProductCheckDTO
{

    public Guid ProductId { get; set; }

    public int Quantity { get; set; }
    public ProductCheckDTO()
    {

    }

    public ProductCheckDTO(Guid productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    }
}

public sealed record IngredientCheckDTO(Guid IngredientId, decimal QuantityNeeded, decimal TotalQuantity);

public sealed record ComboCheckDTO(Guid ComboId, int Quantity);

