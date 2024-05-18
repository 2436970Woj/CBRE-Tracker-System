using Dapper;
using Domain.Models;
using Infrastructure.DataAccess;
using Infrastructure.Interfaces;
using System.Data;

namespace Infrastructure.Repositories;

public class RequestStatusRepository : IRequestStatusRepository
{
    private readonly ISqlDapperData _db;

    public RequestStatusRepository(ISqlDapperData db)
    {
        _db = db;

    }

    //READ all active Request Status
    public async Task<List<RequestStatus>> ReadRequestStatusAsync()
    {
        var parameters = new DynamicParameters();

        //return all Request status options
        var requestStatus1 = await _db.LoadSpData<RequestStatus, DynamicParameters>("dbo.hsp_ReadRequestStatus", parameters);
        return requestStatus1.ToList();
    }


    //READ single instance of Request Status by Id
    public async Task<RequestStatus> ReadRequestStatusByIdAsync(int requestStatusId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("RequestStatusId", requestStatusId, DbType.Int32);

        var requestStatus1 = await _db.LoadSpData<RequestStatus, DynamicParameters>("dbo.hsp_ReadRequestStatusById", parameters);
        return requestStatus1.FirstOrDefault()!;
    }

    //UPDATE request status on ticket
    public async Task<bool> UpdateRequestStatusAsync(int requestId, int requestStatusId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("RequestId", requestId, DbType.Int32);
        parameters.Add("RequestStatusId", requestStatusId, DbType.Int32);
        await _db.SaveSpDate("dbo.hsp_UpdateRequestStatus", parameters);
        return true;
    }

}
