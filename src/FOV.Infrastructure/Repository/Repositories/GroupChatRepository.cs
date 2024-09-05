using FOV.Domain.Entities.GroupChatAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
internal class GroupChatRepository : GenericRepository<GroupChat>, IGroupChatRepository
{
    public GroupChatRepository(FOVContext context) : base(context)
    {
    }
}
