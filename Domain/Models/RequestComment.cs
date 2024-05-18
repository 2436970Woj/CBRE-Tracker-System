namespace Domain.Models;

public class RequestComment
{
    public int RequestCommentId { get; set; }
    public int RequestId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime CommentDate { get; set; }
    public string? CommentUpdate { get; set; }
    public string? RequestorName { get; set; }
}
