using Application.Interfaces.DropDownServicesInterfaces;
using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;

namespace Application.Services.DropDownServices;

public class RequestDropDownService : IRequestDropDownService
{
    private readonly IRequestLocationRepository _requestLocationRepository;
    private readonly IRequestStatusRepository _requestStatusRepository;
    private readonly IRequestTypeRepository _requestTypeRepository;
    public RequestDropDownService(IRequestLocationRepository requestLocationRepository,
        IRequestStatusRepository requestStatusRepository,
        IRequestTypeRepository requestTypeRepository)
    {
        _requestLocationRepository = requestLocationRepository;
        _requestStatusRepository = requestStatusRepository;
        _requestTypeRepository = requestTypeRepository;

    }

    //Read all location data
    public async Task<List<RequestLocation>> ReadRequestLocationsAsync()
    {
        return await _requestLocationRepository.ReadRequestLocationsAsync();
    }

    //Read single instance of location data by id
    public async Task<RequestLocation> ReadRequestLocationByIdAsync(int requestLocationId)
    {
        return await _requestLocationRepository.ReadRequestLocationByIdAsync(requestLocationId);
    }

    //Read all status data
    public async Task<List<RequestStatus>> ReadRequestStatusAsync()
    {
        return await _requestStatusRepository.ReadRequestStatusAsync();
    }

    //Read single instance of status data by id
    public async Task<RequestStatus> ReadRequestStatusByIdAsync(int requestStatusId)
    {
        return await _requestStatusRepository.ReadRequestStatusByIdAsync(requestStatusId);
    }

    //Read all request type data
    public async Task<List<RequestType>> ReadRequestTypesAsync()
    {
        return await _requestTypeRepository.ReadRequestTypesAsync();
    }

    //Read single instance of type data by id
    public async Task<RequestType> ReadRequestTypeByIdAsync(int requestTypeId)
    {
        return await _requestTypeRepository.ReadRequestTypeByIdAsync(requestTypeId);
    }

    public async Task<bool> UpdateRequestStatusAsync(int requestId, int requestStatusId)
    {
       return await _requestStatusRepository.UpdateRequestStatusAsync(requestId, requestStatusId);
    }
}
