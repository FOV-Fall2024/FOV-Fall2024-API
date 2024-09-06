using FOV.Domain.Common;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Domain.Entities.UserAggregator;

namespace FOV.Domain.Entities.GroupChatAggregator;
public class GroupChat : BaseAuditableEntity
{
    public required string GroupName { get; set; }

    public Restaurant? Restaurant { get; set; }

    public Guid? RestaurantId { get; set; }
    public virtual ICollection<GroupUser> GroupUsers { get; set; } = [];

    public virtual ICollection<GroupMessage> GroupMessages { get; set; } = [];


    public GroupChat()
    {

    }

    public GroupChat(string groupName, Guid restaurantId)
    {
        GroupName = groupName;
        RestaurantId = restaurantId;
    }

}
