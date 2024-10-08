namespace FOV.Domain.Entities.IngredientGeneralAggregator.Enums;
public enum IngredientMeasure : byte
{
    gam = 0,
    ml = 1
}


public static class TransferType
{
    public static IngredientMeasure Transfer(this int type) => type switch
    {
        1 => IngredientMeasure.gam,
        2 => IngredientMeasure.ml,
        _ => throw new NotImplementedException(),
    };
}

