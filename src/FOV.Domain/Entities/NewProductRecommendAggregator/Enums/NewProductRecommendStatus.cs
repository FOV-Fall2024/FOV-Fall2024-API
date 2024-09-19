namespace FOV.Domain.Entities.NewProductRecommendAggregator.Enums;
public enum NewProductRecommendStatus : byte
{
    Pending = 0,       // The recommendation is submitted and awaiting review
    Approved = 1,      // The recommendation has been approved
    Denied = 2,        // The recommendation has been denied
    NeedsUpdate = 3    // The recommendation requires additional information or changes before approval
}

