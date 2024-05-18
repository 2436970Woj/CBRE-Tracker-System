using Dapper;
using Domain.Models;
using Infrastructure.DataAccess;
using Infrastructure.Interfaces;
using System.Data;

namespace Infrastructure.Repositories;

public class RequestLocationRepository : IRequestLocationRepository
{
    private readonly ISqlDapperData _db;

    public RequestLocationRepository(ISqlDapperData db)
    {
        _db = db;

    }

    //READ all active Request Locations
    public async Task<List<RequestLocation>> ReadRequestLocationsAsync()
    {
        var parameters = new DynamicParameters();

        //return all roles
        var requestLocations = await _db.LoadSpData<RequestLocation, DynamicParameters>("dbo.hsp_ReadRequestLocations", parameters);
        return requestLocations.ToList();
    }

    //READ single instance of Request Locations by Id
    public async Task<RequestLocation> ReadRequestLocationByIdAsync(int requestLocationId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("RequestLocationId", requestLocationId, DbType.Int32);

        var requestLocation = await _db.LoadSpData<RequestLocation, DynamicParameters>("dbo.hsp_ReadRequestLocationById", parameters);
        return requestLocation.FirstOrDefault()!;
    }
}
