using FOV.Domain.ElasticEntities;
using FOV.Infrastructure.Configuration;
using FOV.Infrastructure.Elastic.IService;
using Microsoft.Extensions.Options;

namespace FOV.Infrastructure.Elastic.Service;
public class UserElasticService : ElasticGenericService<UserDomain>, IUserElasticService
{
    public UserElasticService(IOptions<ElasticSettings> optionsMonitor) : base(optionsMonitor)
    {
    }
}
