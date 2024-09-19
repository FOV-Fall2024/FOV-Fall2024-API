using FOV.Domain.Common;
using FOV.Domain.Entities.NewProductRecommendAggregator.Enums;
using FOV.Domain.Entities.UserAggregator;

namespace FOV.Domain.Entities.NewProductRecommendAggregator;
public class NewProductRecommendLog : BaseAuditableEntity
{
    public string Note { get; set; } = string.Empty;

    public NewProductRecommend? NewProductRecommend { get; set; }    

    public Guid NewProductRecommendId { get; set; }

    public DateTimeOffset LogDate { get; set; }

    public LogType LogType { get; set; }

    public NewProductRecommendLogStatus NewProductRecommendLogStatus { get; set; }


    public string UserId { get; set; }

    public User  User { get; set; } 




    public NewProductRecommendLog()
    {
        
    }

    public NewProductRecommendLog(string note,Guid newProductRecommendId,LogType logType,string userId)
    {
        Note = note;
        NewProductRecommendId = newProductRecommendId;
        LogType = logType;
        UserId = userId;
        LogDate = DateTimeOffset.Now;
    }

    //? add New 



}
