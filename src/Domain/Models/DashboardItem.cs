namespace Domain.Models;

public record DashboardItem(int CustomersCount, int ProductsCount, SystemStatus Status);



public enum SystemStatus
{
    Online,
    Offline
}