using Dapper;
using Domain.Models;
using Infrastructure.DataAccess;
using Infrastructure.Interfaces;
using System.Data;

namespace Infrastructure.Repositories;

public class RequestTicketRepository : IRequestTicketRepository
{
    private readonly ISqlDapperData _db;

     public RequestTicketRepository(ISqlDapperData db)
    {
        _db = db;
    }

    public async Task<bool> CloseRequestTicketAsync(int requestId, int employeeId, bool requestClosed)
    {
        var parameters = new DynamicParameters();
        parameters.Add("RequestId", requestId, DbType.Int32);
        parameters.Add("EmployeeId", employeeId, DbType.Int32);
        parameters.Add("RequestClosed", requestClosed, DbType.Boolean);
        await _db.SaveSpDate("dbo.hsp_UpdateCloseRequest", parameters);
        return true;
    }

    //Open closed ticket
    public async Task<bool> OpenRequestTicketAsync(int requestId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("RequestId", requestId, DbType.Int32);
        await _db.SaveSpDate("dbo.hsp_UpdateOpenClosedRequest", parameters);
        return true;
    }

    //add comments/updates to ticket
    public async Task<bool> CreateRequestComments(int requestId, int employeeId, string commentUpdate)
    {
        var parameters = new DynamicParameters();
        parameters.Add("RequestId", requestId, DbType.Int32);
        parameters.Add("EmployeeId", employeeId, DbType.Int32);
        parameters.Add("CommentUpdate", commentUpdate, DbType.String);
        await _db.SaveSpDate("dbo.hsp_CreateRequestComments", parameters);
        return true;

    }

    //CREATE New Request Ticket
    public async Task<int> CreateRequestTicketAsync(Request request,
        int employeeId, 
        int requestLocationId, 
        int requestTypeId, 
        bool requestPriority,
        string requestTitle, 
        string requestDetails, 
        DateTime requestRequiredDate,
        string requestedForEmpUserId, 
        bool requestSafetyIssue,
        bool requestDocs)
    {
        var parameters = new DynamicParameters();
        parameters.Add("EmployeeId", employeeId, DbType.Int32);
        parameters.Add("RequestLocationId", requestLocationId, DbType.Int32);
        parameters.Add("RequestTypeId ", requestTypeId, DbType.Int32);
        parameters.Add("RequestPriority", requestPriority, DbType.Boolean);
        parameters.Add("RequestTitle", requestTitle, DbType.String);
        parameters.Add("RequestDetails", requestDetails, DbType.String);
        parameters.Add("RequestRequiredDate", requestRequiredDate, DbType.DateTime);
        parameters.Add("RequestedForEmpUserId", requestedForEmpUserId, DbType.String);
        parameters.Add("RequestSafetyIssue", requestSafetyIssue, DbType.Boolean);
        parameters.Add("RequestDocs", requestDocs, DbType.Boolean);
        parameters.Add("NewId", request.RequestId, DbType.Int32, ParameterDirection.Output);
        await _db.SaveSpDate("dbo.hsp_CreateNewRequestTicket", parameters);
        return parameters.Get<int>("NewId");
    }

    //Read all open Requests
    public async Task<IEnumerable<Request>> ReadOpenRequestAsync()
    {
        IEnumerable<Request> requests;

        var parameters = new DynamicParameters();

        //return all open requests
        requests = await _db.LoadSpData<Request, DynamicParameters>("hsp_ReadOpenRequests", parameters);
        return requests;
    }

    //Get request data by Id
    public async Task<Request> ReadOpenRequestByIdAsync(int requestId)
    {
        Request request;
        var parameters = new DynamicParameters();
        parameters.Add("RequestId", requestId, DbType.Int32);
        var requestList = await _db.LoadSpData<Request, DynamicParameters>("dbo.hsp_ReadOpenRequestById", parameters);
        request = requestList?.FirstOrDefault()!; // Assuming it should only return one item
        return request;
    }

    public async Task<IEnumerable<RequestComment>> ReadRequestCommentsById(int requestId)
    {
        IEnumerable<RequestComment> requestComments;
        var parameters = new DynamicParameters();
        parameters.Add("RequestId", requestId, DbType.Int32);
        requestComments = await _db.LoadSpData<RequestComment, DynamicParameters>("dbo.hsp_ReadRequestCommentsById", parameters);
        return requestComments;
    }

    public async Task<bool> UpdateRequestCbreRefAsync(int requestId, string requestRefNumber)
    {
        var parameters = new DynamicParameters();
        parameters.Add("RequestId", requestId, DbType.Int32);
        parameters.Add("RequestRefNumber", requestRefNumber, DbType.String);
        await _db.SaveSpDate("dbo.hsp_UpdateRequestCbreRef", parameters);
        return true;
    }

    public async Task UpdateRequestCbreRefAsyncgrid(Request request)
    {
        var parameters = new DynamicParameters();
        parameters.Add("RequestId", request.RequestId, DbType.Int32);
        parameters.Add("RequestRefNumber", request.RequestRefNumber, DbType.String);
        await _db.SaveSpDate("dbo.hsp_UpdateRequestCbreRef", parameters);
    }


    //Read all closed Requests
    public async Task<IEnumerable<Request>> ReadClosedRequestAsync()
    {
        IEnumerable<Request> requests;

        var parameters = new DynamicParameters();

        //return all open requests
        requests = await _db.LoadSpData<Request, DynamicParameters>("dbo.hsp_ReadClosedRequests", parameters);
        return requests;

    }

    public async Task<IEnumerable<CloseTicketStatusId>> ReadCloseTicketStatusIdAsync()
    {
        IEnumerable<CloseTicketStatusId> closeTicketStatusIds;
        var parameters = new DynamicParameters();

        closeTicketStatusIds = await _db.LoadSpData<CloseTicketStatusId, DynamicParameters>("dbo.hsp_ReadCloseTicketStatusId", parameters);
        return closeTicketStatusIds;
    }
}
