namespace FOV.Domain.Entities.IngredientAggregator.Enums;
public enum IngredientTransactionType : byte
{
    //? Add New to Amount
    Add = 0,
    //? Transfer to Expired 
    Remove = 1,
    //? Using in Order
    Using = 2,
}
