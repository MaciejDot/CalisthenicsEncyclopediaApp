using Dapper;
using SimpleCQRS.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WorkoutExecutionService.DataAccess.Database.Query;
using WorkoutExecutionService.DataAccess.DTO;

namespace WorkoutExecutionService.DataAccess.Database.QueryHandler
{
    class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserDTO>
    {
        private readonly SqlConnection _sqlConnection;
        public GetUserQueryHandler(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public Task<UserDTO> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            return _sqlConnection.QueryFirstOrDefaultAsync<UserDTO>("[Security].[sp_User_Get]", query, commandType: CommandType.StoredProcedure);
        }
    }
}
