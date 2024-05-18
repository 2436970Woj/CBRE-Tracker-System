using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IRequestTypeRepository
    {
        Task<RequestType> ReadRequestTypeByIdAsync(int requestTypeId);
        Task<List<RequestType>> ReadRequestTypesAsync();
    }
}