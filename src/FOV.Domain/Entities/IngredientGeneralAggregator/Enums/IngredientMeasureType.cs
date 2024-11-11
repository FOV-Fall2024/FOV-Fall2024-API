namespace FOV.Domain.Entities.IngredientGeneralAggregator.Enums;
public static  class IngredientMeasureType 
{
    public static string Gam = nameof(Gam);
    public static string Ml = nameof(Ml);
}


public static class TransferType
{
    public static string Transfer(this int type) => type switch
    {
        1 => IngredientMeasureType.Gam,
        2 => IngredientMeasureType.Ml,
        _ => throw new NotImplementedException(),
    };
}

