using Microsoft.AspNetCore.SignalR;

namespace Ecosia.SearchEngine.Api.Hubs;

public class CounterHub : Hub
{
    public async Task NotifyNewCounter(CounterNotification notification)
    {
        await Clients.All.SendAsync("ReceiveNewCounter", notification);
    } 
}

public class CounterNotification {}