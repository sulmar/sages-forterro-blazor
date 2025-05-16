using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs;

public class DashboardHub(ILogger<DashboardHub> logger) : Hub
{
    public override Task OnConnectedAsync()
    {
        // zła praktyka
        // logger.LogInformation($"ConnectionId: {Context.ConnectionId}");

        // dobra praktyka
         logger.LogInformation("Client Connected: {ConnectionId}", Context.ConnectionId);

        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        logger.LogInformation("Client Disconnected: {ConnectionId}", Context.ConnectionId);


        return base.OnDisconnectedAsync(exception);
    }
}
