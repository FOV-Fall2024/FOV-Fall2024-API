using FOV.Domain.Entities.UserAggregator;

namespace FOV.Presentation.Infrastructure
{
    public static class EndPoint
    {
        public static void AuthenticationEndPoint(this WebApplication app)
        {
            app.MapIdentityApi<User>();

        }
    }
}
