namespace Domain.Models;

public class RequestLocation
{
    public int RequestLocationId { get; set; }
    public string? RequestLocationName { get; set;}
    public bool ActiveFlag { get; set; }
    public DateTime DateCreated { get; set; }
}
