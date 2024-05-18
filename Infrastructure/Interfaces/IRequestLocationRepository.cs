using Domain.Models;

namespace Infrastructure.Interfaces
{
    public interface IRequestLocationRepository
    {
        Task<RequestLocation> ReadRequestLocationByIdAsync(int requestLocationId);
        Task<List<RequestLocation>> ReadRequestLocationsAsync();
    }
}