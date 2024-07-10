using FOV.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Domain.Entities.IngredientAggregator;

public class IngredientType : BaseEntity
{
    public string IngredientName { get; set; } = string.Empty;
    public string IngredientDescription { get; set; } = string.Empty;
    public Guid ParentId { get; private set; }

    public int Left { get;  set; }

    public int Right { get; set; }
    public int ExpiredTime { get; set; }

    public virtual ICollection<Ingredient>? Ingredients { get; set; } 

    public virtual ICollection<IngredientGeneral>? IngredientGenerals { get; set; }
    
}
