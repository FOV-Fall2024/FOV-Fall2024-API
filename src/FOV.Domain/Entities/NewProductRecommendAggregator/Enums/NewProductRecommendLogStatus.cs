namespace FOV.Domain.Entities.NewProductRecommendAggregator.Enums;
public enum NewProductRecommendLogStatus : byte
{
    //? Manager 
    NewRequest = 0,
    UpdateRequest = 1,
    //? Admin
    Denied = 2,
    Approve = 3,
    UpdateMore = 4,
}
