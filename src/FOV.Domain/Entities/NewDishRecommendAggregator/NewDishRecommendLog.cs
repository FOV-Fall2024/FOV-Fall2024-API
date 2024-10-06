using FOV.Domain.Common;
using FOV.Domain.Entities.NewDishRecommendAggregator.Enums;
using FOV.Domain.Entities.UserAggregator;

namespace FOV.Domain.Entities.NewDishRecommendAggregator;
public class NewDishRecommendLog : BaseAuditableEntity
{
    public string Note { get; set; } = string.Empty;
    public NewDishRecommend? NewDishRecommend { get; set; }
    public Guid NewProductRecommendId { get; set; }
    public DateTime? LogDate { get; set; } = DateTime.UtcNow;
    public LogType LogType { get; set; }
    public NewProductRecommendLogStatus NewProductRecommendLogStatus { get; set; }
    public string UserId { get; set; }
    public User? User { get; set; }
    public NewDishRecommendLog()
    {

    }

    public NewDishRecommendLog(string note, Guid newProductRecommendId, LogType logType, string userId)
    {
        Note = note;
        NewProductRecommendId = newProductRecommendId;
        LogType = logType;
        UserId = userId;
        LogDate = DateTime.UtcNow;
    }

    //? add New 



}
