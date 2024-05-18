using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IRequestTicketRepository
    {
        Task<int> CreateRequestTicketAsync(Request request, int employeeId, int requestLocationId, 
            int requestTypeId, bool requestPriority, string requestTitle, string requestDetails, 
            DateTime requestRequiredDate, string requestedForEmpUserId, 
            bool requestSafetyIssue, bool requestDocs);
        Task<IEnumerable<Request>> ReadOpenRequestAsync();
        Task<bool> CloseRequestTicketAsync(int requestId, int employeeId, bool requestClosed);
        Task<bool> UpdateRequestCbreRefAsync(int requestId, string requestRefNumber);
        Task<Request> ReadOpenRequestByIdAsync(int requestId);
        Task<bool> CreateRequestComments(int requestId, int employeeId, string commentUpdate);
        Task<IEnumerable<RequestComment>> ReadRequestCommentsById(int requestId);
        Task<IEnumerable<Request>> ReadClosedRequestAsync();
        Task<bool> OpenRequestTicketAsync(int requestId);
        Task UpdateRequestCbreRefAsyncgrid(Request request);
        Task<IEnumerable<CloseTicketStatusId>> ReadCloseTicketStatusIdAsync();
    }
}