using FOV.Domain.Entities.GroupChatAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;
internal class GroupUserRepository : GenericRepository<GroupUser>, IGroupUserRepository
{
    public GroupUserRepository(FOVContext context) : base(context)
    {
    }
}
