using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using StackExchange.Redis;

namespace FOV.Infrastructure.Notifications.Web.SignalR.Notification.Setup;
public class NotificationHub : Hub
{
    private readonly IDatabase _database;
    public NotificationHub(IConnectionMultiplexer connectionMultiplexer)
    {
        _database = connectionMultiplexer.GetDatabase();
    }
    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("ReceiveMessage", "System", $"{Context.ConnectionId} has connected");
    }
    public async Task SendEmployeeId(string EmployeeId, string Role)
    {
        string ConnectionId = Context.ConnectionId;
        await _database.StringSetAsync(EmployeeId.ToString(), ConnectionId);
        await Clients.Client(ConnectionId).SendAsync("ReceiveEmployeeId", EmployeeId, Role);
    }
    public async Task SendOrderToHeadChef(Guid HeadchefId)
    {
        string connectionId = await _database.StringGetAsync(HeadchefId.ToString());
        await Clients.Client(connectionId).SendAsync("ReceiveNewOrder", HeadchefId);
    }
    public async Task SendNotificationToWaiter(Guid WaiterId, Guid OrderId, Guid OrderDetailId)
    {
        string connectionId = await _database.StringGetAsync(WaiterId.ToString());
        await Clients.Client(connectionId).SendAsync("ReceiveNotificationToWaiter", OrderId, OrderDetailId);
    }
    public async Task SendPaymentNotificationToWaiter(Guid WaiterId, Guid OrderId)
    {
        string connectionId = await _database.StringGetAsync(WaiterId.ToString());
        await Clients.Client(connectionId).SendAsync("ReceivePaymentNotificationToWaiter", OrderId);
    }
}
