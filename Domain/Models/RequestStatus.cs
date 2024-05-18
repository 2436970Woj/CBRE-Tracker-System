namespace Domain.Models;

public class RequestStatus
{
    public int RequestStatusId { get; set; }
    public string? RequestStatusName { get; set;}
    public bool ActiveFlag { get; set; }
    public DateTime DateCreated { get; set; }

}
