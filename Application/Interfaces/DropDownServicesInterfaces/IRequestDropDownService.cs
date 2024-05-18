using Domain.Models;

namespace Application.Interfaces.DropDownServicesInterfaces
{
    public interface IRequestDropDownService
    {
        Task<RequestLocation> ReadRequestLocationByIdAsync(int requestLocationId);
        Task<List<RequestLocation>> ReadRequestLocationsAsync();
        Task<List<RequestStatus>> ReadRequestStatusAsync();
        Task<RequestStatus> ReadRequestStatusByIdAsync(int requestStatusId);
        Task<RequestType> ReadRequestTypeByIdAsync(int requestTypeId);
        Task<List<RequestType>> ReadRequestTypesAsync();
        Task<bool> UpdateRequestStatusAsync(int requestId, int requestStatusId);

    }
}