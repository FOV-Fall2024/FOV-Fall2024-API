using FOV.Domain.Entities.GroupChatAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
internal class GroupMessageRepository : GenericRepository<GroupMessage>, IGroupMessageRepository
{
    public GroupMessageRepository(FOVContext context) : base(context)
    {
    }
}
