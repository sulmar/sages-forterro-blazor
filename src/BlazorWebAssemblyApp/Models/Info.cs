namespace BlazorWebAssemblyApp.Models;

public class Info
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Count { get; set; }
}

public class ApplicationState
{
    public string ApplicationName { get; set; }
    public string ApplicationVersion { get; set; }
    public DateTime RunnedOn { get; set; }    
}

public class FilterState
{
    public int SelectedCustomerId { get; set; }
    public int SelectedUserId { get; set; }    
}
