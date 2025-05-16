using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs;

// TODO: Wymaga włączenia autoryzacji
// [Authorize]
public class DashboardHub(ILogger<DashboardHub> logger) : Hub
{
    public override Task OnConnectedAsync()
    {
        // zła praktyka
        // logger.LogInformation($"ConnectionId: {Context.ConnectionId}");

        // dobra praktyka
         logger.LogInformation("Client Connected: {ConnectionId}", Context.ConnectionId);

        // TODO: Wymaga włączenia autoryzacji
        // var department = Context.User.Claims.SingleOrDefault(c => c.Type == "Department").Value;
        // Groups.AddToGroupAsync(Context.ConnectionId, department);

        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        logger.LogInformation("Client Disconnected: {ConnectionId}", Context.ConnectionId);


        return base.OnDisconnectedAsync(exception);
    }
}
