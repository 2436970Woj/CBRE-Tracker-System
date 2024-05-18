using Dapper;
using Domain.Models;
using Infrastructure.DataAccess;
using Infrastructure.Interfaces;
using System.Data;

namespace Infrastructure.Repositories;

public class RequestDocRepository : IRequestDocRepository
{
    private readonly ISqlDapperData _db;
    public RequestDocRepository(ISqlDapperData db)
    {
        _db = db;

    }

    //Load files for singular tickets
    public async Task<bool> FilesUploadAsync(string requestTicketId, string fleName)
    {
        var parameters = new DynamicParameters();
        parameters.Add("RequestTicketId", requestTicketId, DbType.String);
        parameters.Add("FileName", fleName, DbType.String);
        await _db.SaveSpDate("dbo.hsp_FilesUpload", parameters);
        return true;
    }

    //Load files for singular tickets
    public async Task<bool> FilesUploadSubmitAsync(string requestTicketId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("RequestTicketId", requestTicketId, DbType.String);
        await _db.SaveSpDate("dbo.hsp_Email_Files_Success", parameters);
        return true;
    }

    //Return all files with matching requestTicketId 
    public async Task<List<RequestDoc>> FilesDisplayIdAsync(string requestTicketId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("RequestTicketId", requestTicketId, DbType.String);

        var requestFiles = await _db.LoadSpData<RequestDoc, DynamicParameters>("dbo.hsp_FilesDisplay", parameters);
        return requestFiles.ToList();
    }

    //Return all files with matching requestTicketId 
    public async Task<bool> FilesDeleteIdAsync(string requestTicketId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("RequestTicketId", requestTicketId, DbType.String);

       await _db.LoadSpData<RequestDoc, DynamicParameters>("dbo.hsp_FilesDelete", parameters);
        return true;
    }

}
