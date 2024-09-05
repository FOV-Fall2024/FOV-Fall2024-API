using FOV.Domain.Common;
using FOV.Domain.Entities.UserAggregator;

namespace FOV.Domain.Entities.GroupChatAggregator;
public class GroupUser : BaseAuditableEntity
{
    public GroupChat GroupChat { get; set; }
    public Guid GroupChatId { get; set; }

    public User User { get; set; }
    public string UserId { get ; set; }
}
