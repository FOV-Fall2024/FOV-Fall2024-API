namespace FOV.Domain.Entities.IngredientGeneralAggregator.Enums;
public static  class IngredientMeasureType 
{
    public static string gam = nameof(gam);
    public static string ml = nameof(ml);
}


public static class TransferType
{
    public static string Transfer(this int type) => type switch
    {
        1 => IngredientMeasureType.gam,
        2 => IngredientMeasureType.ml,
        _ => throw new NotImplementedException(),
    };
}

