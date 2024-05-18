namespace Domain.Models;

public class RequestDoc
{
    public int RequestDocumentId { get; set; }
    public int RequestId { get; set; }
    public string? RequestTicketId { get; set; }
    public string? FileName { get; set;}
}
