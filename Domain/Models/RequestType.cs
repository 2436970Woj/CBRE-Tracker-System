namespace Domain.Models;

public class RequestType
{
    public int RequestTypeId { get; set; }
    public string? RequestTypeName { get; set; }
    public bool ActiveFlag {  get; set; }
    public DateTime DateCreated { get; set; }
}
