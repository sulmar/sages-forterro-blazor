using Api.Hubs;
using Domain.Models;
using Microsoft.AspNetCore.SignalR;

namespace Api.BackgroundServices;

public class DashboardBackgroundService(
    ILogger<DashboardBackgroundService> logger,
    IHubContext<DashboardHub> hubContext) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var item = new DashboardItem
                (
                    Random.Shared.Next(1, 1000),
                    Random.Shared.Next(50, 200),
                    (SystemStatus)Random.Shared.Next(0, 2)
                );

            logger.LogInformation(item.ToString());

            await hubContext.Clients.All.SendAsync("UpdateDashboard", item, stoppingToken);

            await Task.Delay(Random.Shared.Next(100, 1000), stoppingToken);
        }

    }
}
