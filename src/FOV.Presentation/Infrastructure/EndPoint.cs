using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Data.Configurations;

namespace FOV.Presentation.Infrastructure
{
    public static class EndPoint
    {
        public static async Task AuthenticationEndPoint(this WebApplication app)
        {
            app.MapIdentityApi<User>();

        }
    }
}
