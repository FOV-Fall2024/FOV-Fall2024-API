using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Common;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace FOV.Domain.Entities.IngredientGeneralAggregator;
public class IngredientMeasure : BaseAuditableEntity
{
    public string IngredientMeasureName { get; set; } = string.Empty;
    public virtual ICollection<IngredientGeneral> IngredientGenerals { get; set; }

    public IngredientMeasure()
    {
        
    }

    public IngredientMeasure(string ingredientMeasureName)
    {
        IngredientMeasureName = ingredientMeasureName;
    }
}
