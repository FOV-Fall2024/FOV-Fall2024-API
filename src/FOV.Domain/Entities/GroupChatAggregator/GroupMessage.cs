using FOV.Domain.Common;
using FOV.Domain.Entities.UserAggregator;

namespace FOV.Domain.Entities.GroupChatAggregator;
public class GroupMessage : BaseAuditableEntity
{
    public GroupChat? GroupChat { get; set; }
    public Guid GroupChatId { get; set; } = Guid.Empty;

    public string UserId { get; set; } = string.Empty;

    public User? User { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }



}
