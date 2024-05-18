using Dapper;
using Domain.Models;
using Infrastructure.DataAccess;
using Infrastructure.Interfaces;
using System.Data;

namespace Infrastructure.Repositories
{
    public class RequestTypeRepository : IRequestTypeRepository
    {
        private readonly ISqlDapperData _db;

        public RequestTypeRepository(ISqlDapperData db)
        {
            _db = db;
        }

        //READ all active Request types
        public async Task<List<RequestType>> ReadRequestTypesAsync()
        {
            var parameters = new DynamicParameters();

            //return all Request type active options
            var requestType1 = await _db.LoadSpData<RequestType, DynamicParameters>("dbo.hsp_ReadRequestTypes", parameters);
            return requestType1.ToList();
        }

        //READ single instance of Request Type by Id
        public async Task<RequestType> ReadRequestTypeByIdAsync(int requestTypeId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("RequestTypeId", requestTypeId, DbType.Int32);

            var requestType1 = await _db.LoadSpData<RequestType, DynamicParameters>("dbo.hsp_ReadRequestTypesById", parameters);
            return requestType1.FirstOrDefault()!;
        }
    }
}
