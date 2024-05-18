using Application.Interfaces.ReqTicketServiceInterfaces;
using Domain.Models;
using Infrastructure.Interfaces;

namespace Application.Services.ReqTicketServices
{
    public class ReqTicketService : IReqTicketService
    {
        private readonly IRequestTicketRepository _requestTicketRepository;

        public ReqTicketService(IRequestTicketRepository requestTicketRepository)
        {
            _requestTicketRepository = requestTicketRepository;
        }

        public async Task<bool> CloseRequestTicketAsync(int requestId, int employeeId, bool requestClosed)
        {
            return await _requestTicketRepository.CloseRequestTicketAsync(requestId, employeeId,requestClosed);
        }

        //Create New Request Ticket

        public async Task<int> CreateRequestTicketAsync(Request request, int employeeId, int requestLocationId,
            int requestTypeId, bool requestPriority, string requestTitle, string requestDetails,
            DateTime requestRequiredDate, string requestedForEmpUserId, bool requestSafetyIssue, bool requestDocs)
        {
            return await _requestTicketRepository.CreateRequestTicketAsync(request, employeeId, requestLocationId,
                requestTypeId, requestPriority, requestTitle, requestDetails, requestRequiredDate, requestedForEmpUserId,
                requestSafetyIssue, requestDocs);
        }

        public Task<IEnumerable<Request>> ReadOpenRequestAsync()
        {
            return _requestTicketRepository.ReadOpenRequestAsync();
        }

        public async Task<bool> UpdateRequestCbreRefAsync(int requestId, string requestRefNumber)
        {
            return await _requestTicketRepository.UpdateRequestCbreRefAsync(requestId, requestRefNumber);
        }

        public async Task<Request> ReadOpenRequestByIdAsync(int requestId)
        {
            return await _requestTicketRepository.ReadOpenRequestByIdAsync(requestId);
        }

        public async Task<bool> CreateRequestComments(int requestId, int employeeId, string commentUpdate)
        {
            return await _requestTicketRepository.CreateRequestComments(requestId, employeeId, commentUpdate);
        }

        public Task<IEnumerable<RequestComment>> ReadRequestCommentsById(int requestId)
        {
            return _requestTicketRepository.ReadRequestCommentsById(requestId);
        }

        public Task<IEnumerable<Request>> ReadClosedRequestAsync()
        {
            return _requestTicketRepository.ReadClosedRequestAsync();
        }

        public async Task<bool> OpenRequestTicketAsync(int requestId)
        {
            return await _requestTicketRepository.OpenRequestTicketAsync(requestId);
        }

        public async Task UpdateRequestCbreRefAsyncgrid(Request request)
        {
            await _requestTicketRepository.UpdateRequestCbreRefAsyncgrid(request);
        }

        public Task<IEnumerable<CloseTicketStatusId>> ReadCloseTicketStatusIdAsync()
        {
            return _requestTicketRepository.ReadCloseTicketStatusIdAsync();
        }
    }
}
