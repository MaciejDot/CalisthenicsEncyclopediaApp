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
    public class GetFatiguesQueryHandler : IQueryHandler<GetFatiguesQuery, IEnumerable<FatigueDTO>>
    {
        private readonly SqlConnection _sqlConnection;
        public GetFatiguesQueryHandler(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public Task<IEnumerable<FatigueDTO>> Handle(GetFatiguesQuery query, CancellationToken cancellationToken)
        {
            return _sqlConnection.QueryAsync<FatigueDTO>("[Workout].[sp_Fatigue_GetAll]", commandType: CommandType.StoredProcedure);
        }
    }
}
