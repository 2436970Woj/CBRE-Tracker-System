namespace Domain.Models
{
    public class Request
    {
        public int RequestId { get; set; }
        public int EmployeeId { get; set; }
        public int RequestLocationId { get; set; }
        public RequestLocation? RequestLocation { get; set; }
        public int RequestTypeId { get; set; }
        public RequestType? RequestType { get; set; }
        public int RequestStatusId { get; set; }
        public RequestStatus? RequestStatus { get; set; }
        public bool RequestPriority { get; set; }
        public string? RequestTitle { get; set; }
        public string? RequestDetails { get; set; }
        public string? RequestRefNumber { get; set; }
        public DateTime RequestCreatedDate { get; set; }
        public DateTime RequestRequiredDate { get; set; }
        public DateTime RequestCompletedDate { get; set; }
        public int RequestCompletedBy { get; set; }
        public bool RequestClosed { get; set; }
        public bool RequestInvoiced { get; set; }
        public bool RequestInvoicePaid { get;set; }
        public DateTime RequestInvoicePayDT { get; set; }
        public decimal RequestInvoiceCost { get; set; }
        public string? RequestedForEmpUserId { get; set; }
        public bool RequestSafetyIssue { get; set; }
        public string? RequestTicketId { get; set; }
        public bool? RequestDocs {  get; set; }
        public decimal Delta { get; set; }
        public Employee? Employee { get; set; }
        public string? RequestStatusName { get; set; }
        public string? RequestLocationName { get; set; }
        public string? RequestTypeName { get; set; }
        public string? RequestorName { get; set; }
        public bool RequestComments { get; set; }
        public string? ClosedBy { get; set; }
        public int FacilityId { get; set; }

    }
}
