using FOV.Domain.Common;
using FOV.Domain.Entities.UserAggregator;

namespace FOV.Domain.Entities.GroupChatAggregator;
public class GroupChat : BaseAuditableEntity
{
    public required string GroupName { get; set; }

    public virtual ICollection<GroupUser> GroupUsers { get; set; }




}
