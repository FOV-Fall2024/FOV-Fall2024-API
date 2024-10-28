using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace FOV.Infrastructure.Order.Setup;
public class OrderHub : Hub
{
    private readonly IDatabase _database;
    public OrderHub(IConnectionMultiplexer connectionMultiplexer)
    {
        _database = connectionMultiplexer.GetDatabase();
    }

    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("ReceiveMessage", "System", $"{Context.ConnectionId} has connected");
    }
    public async Task SendOrder(Guid OrderId)
    {
        string connectionId = Context.ConnectionId;
        await _database.StringSetAsync(OrderId.ToString(), connectionId);
        await Clients.Client(connectionId).SendAsync("ReceiveOrder", connectionId, OrderId);
    }
    public async Task UpdateOrderStatus(Guid OrderId, string status)
    {
        string connectionId = await _database.StringGetAsync(OrderId.ToString());
        await Clients.Client(connectionId).SendAsync("ReceiveOrderStatus", OrderId, status);
    }
    public async Task UpdateOrderDetailsStatus(Guid OrderId, Guid ProductIdOrComboId, string status)
    {
        string connectionId = await _database.StringGetAsync(OrderId.ToString());
        await Clients.Client(connectionId).SendAsync("ReceiveOrderDetailsStatus", ProductIdOrComboId, status);
    }
    public async Task RefundOrderDetails(Guid OrderId, Guid ProductIdOrComboId, int Quantity)
    {
        string connectionId = await _database.StringGetAsync(OrderId.ToString());
        await Clients.Client(connectionId).SendAsync("ReceiveRefundOrderDetails", ProductIdOrComboId, Quantity);
    }
}
