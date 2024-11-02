using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using StackExchange.Redis;

namespace FOV.Infrastructure.Notifications.Web.SignalR.Login;
public class LoginHub : Hub
{
    private readonly IDatabase _database;
    public LoginHub(IConnectionMultiplexer connectionMultiplexer)
    {
        _database = connectionMultiplexer.GetDatabase();
    }
    public async Task SendEmployeeId(string EmployeeId, string Role)
    {
        string ConnectionId = Context.ConnectionId;
        await _database.StringSetAsync(EmployeeId.ToString(), ConnectionId);
        await Clients.Client(ConnectionId).SendAsync("ReceiveEmployeeId", EmployeeId, Role);
    }
}
