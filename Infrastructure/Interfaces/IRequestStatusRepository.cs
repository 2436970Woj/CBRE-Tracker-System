using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IRequestStatusRepository
    {
        Task<List<RequestStatus>> ReadRequestStatusAsync();
        Task<RequestStatus> ReadRequestStatusByIdAsync(int requestStatusId);
        Task<bool> UpdateRequestStatusAsync(int requestId, int requestStatusId);

    }
}