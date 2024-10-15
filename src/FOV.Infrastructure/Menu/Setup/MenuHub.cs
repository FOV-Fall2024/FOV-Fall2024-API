using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace FOV.Infrastructure.Menu.Setup;
public class MenuHub : Hub
{
    public async Task NotifyDishAvailability(Guid dishId, bool isAvailable)
    {
        await Clients.All.SendAsync("ReceiveDishUpdate", dishId, isAvailable);
    }
}
