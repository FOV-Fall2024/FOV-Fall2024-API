namespace FOV.Domain.Entities.IngredientGeneralAggregator.Enums;
public enum IngredientMeasure : byte
{
    g = 0,
    ml = 1,
    can = 2,
    pack = 3,
}


public static class TransferType
{
    public static IngredientMeasure Transfer(this int type) => type switch
    {
        1 => IngredientMeasure.g,
        2 => IngredientMeasure.ml,
        3 => IngredientMeasure.can,
        4 => IngredientMeasure.pack,
        _ => throw new NotImplementedException(),
    };
}

