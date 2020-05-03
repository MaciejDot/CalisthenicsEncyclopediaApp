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
    public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, IEnumerable<UserDTO>>
    {
        private readonly SqlConnection _sqlConnection;
        public GetUsersQueryHandler(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public Task<IEnumerable<UserDTO>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
        {
            return _sqlConnection.QueryAsync<UserDTO>("[Security].[sp_User_GetAll]", commandType: CommandType.StoredProcedure);
        }
    }
}
