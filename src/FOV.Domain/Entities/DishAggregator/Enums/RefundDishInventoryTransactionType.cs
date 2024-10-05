namespace FOV.Domain.Entities.DishAggregator.Enums;
public enum RefundDishInventoryTransactionType : byte
{
    //? Add New to Amount
    Add = 0,
    //? Transfer to Expired 
    Remove = 1,
    //? Using in Order
    Using = 2,
}
